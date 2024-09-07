using FoodDeliveryAPI.Dto;
using FoodDeliveryAPI.Dto.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMadeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentMadeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayment()
        {
            var PaymentMades = await _context.PaymentMades.ToListAsync();
            return Ok(PaymentMades);
        }

        
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<PaymentMade>> AddPayment(PaymentDto paymentdto)
        {
            var newCharacter = new PaymentMade
            {
                Id = paymentdto.id,
                CardName = paymentdto.CardName,
                CardNumber = paymentdto.CardNumber,
                ExpiryDate = paymentdto.ExpiryDate,
                CVC = paymentdto.CVC
            };
            _context.PaymentMades.Add(newCharacter);
            await _context.SaveChangesAsync();
            return Ok(new Response { Data = "record added successfully", Status = "Success", Message = "Purchased made Successfully" });

        }
    }
}
