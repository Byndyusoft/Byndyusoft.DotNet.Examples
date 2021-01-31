using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Diagnostics;
using OpenTracing;
using OpenTracing.Tag;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource
{
    public class TraceOrderDiagnosticObserver : OrderDiagnosticObserver
    {
        private readonly ITracer _tracer;
        private static readonly IDictionary<Guid, ISpan> Spans = new ConcurrentDictionary<Guid, ISpan>();

        public TraceOrderDiagnosticObserver(ITracer tracer)
        {
            _tracer = tracer;
        }

        protected override void OnCreating(CreateOrderPayload payload)
        {
            var scope = _tracer.BuildSpan("Create order").StartActive();
            scope.Span.Log(new Dictionary<string, object>()
            {
                {"dto", payload.Dto}
            });

            Spans.Add(payload.OperationId, scope.Span);
        }

        protected override void OnCreated(CreateOrderPayload payload)
        {
            var span = Spans[payload.OperationId];
            span.Finish();
            Spans.Remove(payload.OperationId);
        }

        protected override void OnCreationError(CreateOrderPayload payload)
        {
            var span = Spans[payload.OperationId];
            var e = payload.Exception;
            span.SetTag(Tags.Error, true);
            span.Log(new Dictionary<string, object>(3)
            {
                { LogFields.Event, Tags.Error.Key },
                { LogFields.ErrorKind, e.GetType().Name },
                { LogFields.ErrorObject, e }
            });
            Spans.Remove(payload.OperationId);
        }
    }
}