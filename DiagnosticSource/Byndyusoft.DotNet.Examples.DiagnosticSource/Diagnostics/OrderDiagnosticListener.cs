using System;
using System.Diagnostics;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Domain;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Models;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Diagnostics
{
    public class OrderDiagnosticListener : DiagnosticListener
    {
        public const string ListenerName = nameof(OrderDiagnosticListener);

        public static class EventNames
        {
            public const string Creating = "Byndyusoft.Examples.Orders.Creating";
            public const string Created = "Byndyusoft.Examples.Orders.Created";
            public const string CreationError = "Byndyusoft.Examples.Orders.CreationError";
        }

        public OrderDiagnosticListener() : base(ListenerName)
        {
        }

        internal Guid OnCreating(CreateOrderDto dto)
        {
            if (!IsEnabled(EventNames.Creating)) return Guid.Empty;
            var operationId = Guid.NewGuid();
            Write(EventNames.Creating, new CreateOrderPayload {OperationId = operationId, Dto = dto});
            return operationId;
        }

        internal void OnCreated(Guid operationId, Order order)
        {
            if (!IsEnabled(EventNames.Created)) return;
            Write(EventNames.Created, new CreateOrderPayload {OperationId = operationId, Order = order});
        }

        internal void OnCreatingError(Guid operationId, CreateOrderDto dto, Exception exception)
        {
            if (!IsEnabled(EventNames.CreationError)) return;
            Write(EventNames.CreationError, new CreateOrderPayload {OperationId = operationId, Dto = dto, Exception = exception});
        }
    }
}