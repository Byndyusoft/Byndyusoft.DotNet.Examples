using System;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Domain;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Models;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Diagnostics
{
    public class CreateOrderPayload
    {
        public Guid OperationId { get; set; }

        public CreateOrderDto Dto { get; set; }
        
        public Order Order { get; set; }

        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
        
        public Exception Exception { get; set; }
    }
}