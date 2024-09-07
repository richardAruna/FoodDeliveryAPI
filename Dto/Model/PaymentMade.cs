using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Dto.Model
{
    public class PaymentMade
    {
        [Key]
        public int Id { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpiryDate { get; set; }
        public string? CVC { get; set; }
    }
}
