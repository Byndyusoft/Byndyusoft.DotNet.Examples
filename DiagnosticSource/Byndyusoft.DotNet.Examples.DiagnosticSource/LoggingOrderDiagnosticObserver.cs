using System.Text.Json;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource
{
    public class LoggingOrderDiagnosticObserver : OrderDiagnosticObserver
    {
        private readonly ILogger<LoggingOrderDiagnosticObserver> _logger;

        public LoggingOrderDiagnosticObserver(ILogger<LoggingOrderDiagnosticObserver> logger)
        {
            _logger = logger;
        }

        protected override void OnCreating(CreateOrderPayload payload)
        {
            _logger.LogInformation($"Creating order ${JsonSerializer.Serialize(payload.Dto)}");
        }

        protected override void OnCreated(CreateOrderPayload payload)
        {
            _logger.LogInformation($"Order ${payload.Order.Id} created");
        }

        protected override void OnCreationError(CreateOrderPayload payload)
        {
            _logger.LogError(payload.Exception, $"Order ${JsonSerializer.Serialize(payload.Dto)} creation error");
        }
    }
}