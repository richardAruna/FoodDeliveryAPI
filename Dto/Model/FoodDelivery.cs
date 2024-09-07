using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Dto.Model
{
    public class FoodDelivery
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Amount { get; set; }
        public string? ImgUrl { get; set; }
    }
}
