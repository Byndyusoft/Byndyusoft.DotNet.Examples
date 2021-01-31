using System;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Diagnostics;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Domain;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Models;
using Microsoft.AspNetCore.Mvc;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : Controller
    {
        private static readonly OrderDiagnosticListener DiagnosticListener = new OrderDiagnosticListener();
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDto dto)
        {
            var operationId = DiagnosticListener.OnCreating(dto);
            try
            {
                var order = _orderService.CreateOrder(dto);
                DiagnosticListener.OnCreated(operationId, order);
                return Ok(order.Id);
            }
            catch (Exception exception)
            {
                DiagnosticListener.OnCreatingError(operationId, dto, exception);
                throw;
            }
        }
    }
}