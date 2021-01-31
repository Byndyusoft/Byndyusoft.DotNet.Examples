using System;
using System.Threading;
using Byndyusoft.DotNet.Examples.DiagnosticSource.Models;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Domain
{
    public class OrderService
    {
        private static long _counter;

        public Order CreateOrder(CreateOrderDto dto)
        {
            var id = Interlocked.Increment(ref _counter);
            if (id % 2 == 0)
                throw new InvalidOperationException();

            return new Order
            {
                AccountId = dto.AccountId,
                DeliveryAddress = dto.DeliveryAddress,
                Id = id,
                TotalCost = dto.TotalCost
            };
        }
    }
}