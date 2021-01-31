using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Diagnostics;
using Prometheus;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource
{
    public class PrometheusOrderDiagnosticObserver : OrderDiagnosticObserver
    {
        private static readonly Counter OrderTotal =
            Metrics.CreateCounter("orders_total", "Created order total count");
        private static readonly Counter OrderCreationErrorTotal =
            Metrics.CreateCounter("orders_creation_error_total", "Order creation error total count");
        private static readonly Histogram OrderCreationDuration = Metrics
            .CreateHistogram("order_creation_duration", "Histogram of order creation duration");

        private static readonly IDictionary<Guid, DateTimeOffset> Operations = new ConcurrentDictionary<Guid, DateTimeOffset>();

        protected override void OnCreating(CreateOrderPayload payload)
        {
            Operations.Add(payload.OperationId, payload.Timestamp);
        }
        
        protected override void OnCreated(CreateOrderPayload payload)
        {
            OrderTotal.Inc();

            if (Operations.TryGetValue(payload.OperationId, out var startedAt))
            {
                var duration = payload.Timestamp.Subtract(startedAt).TotalMilliseconds;
                OrderCreationDuration.Observe(duration);
                Operations.Remove(payload.OperationId);
            }
        }

        protected override void OnCreationError(CreateOrderPayload payload)
        {
            OrderCreationErrorTotal.Inc();

            if (Operations.TryGetValue(payload.OperationId, out var startedAt))
            {
                var duration = payload.Timestamp.Subtract(startedAt).TotalMilliseconds;
                OrderCreationDuration.Observe(duration);
                Operations.Remove(payload.OperationId);
            }
        }
    }
}