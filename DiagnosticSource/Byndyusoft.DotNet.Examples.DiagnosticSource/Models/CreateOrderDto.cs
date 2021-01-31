using System.Runtime.Serialization;

namespace Byndyusoft.DotNet.Examples.DiagnosticSource.Models
{
    [DataContract]
    public class CreateOrderDto
    {
        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public string DeliveryAddress { get; set; }

        [DataMember]
        public decimal TotalCost { get; set; }
    }
}