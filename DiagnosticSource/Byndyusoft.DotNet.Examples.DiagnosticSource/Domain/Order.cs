namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Domain
{
    public class Order
    {
        public long Id { get; set; }

        public int AccountId { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal TotalCost { get; set; }
    }
}