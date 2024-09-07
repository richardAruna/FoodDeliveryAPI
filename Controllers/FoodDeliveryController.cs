using FoodDeliveryAPI.Dto;
using FoodDeliveryAPI.Dto.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FoodDeliveryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodDeliveryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDelivery()
        {
            var FoodDeliverys = await _context.FoodDeliverys.ToListAsync();
            return Ok(FoodDeliverys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleDelivery(int id)
        {
            var fd = await _context.FoodDeliverys.FindAsync(id);
            if (fd is null)
                return BadRequest("Delivery Not Found");
            return Ok(fd);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<FoodDelivery>> AddDelivery(FoodDeliveryDto fooddeliverydto)
        {
           
            var newCharacter = new FoodDelivery
            {
                Id = fooddeliverydto.id,
                ProductName = fooddeliverydto.ProductName,
                ImgUrl = fooddeliverydto.ImgUrl,
                Amount = fooddeliverydto.Amount,
            };
            _context.FoodDeliverys.Add(newCharacter);
            await _context.SaveChangesAsync();
            return Ok(new Response { Data = "record added successfully", Status = "Success", Message = "Food Delivery Updated Successfully" });

        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateDelivery([FromBody] FoodDelivery hos)
        {
            var existingDelivery = await _context.FoodDeliverys.FindAsync(hos.Id);
            if (existingDelivery is null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Delivery Room  not found." });

            existingDelivery.ProductName = hos.ProductName;
            existingDelivery.ImgUrl = hos.ImgUrl;
            existingDelivery.Amount = hos.Amount;

            await _context.SaveChangesAsync();
            return Ok(new Response { Data = existingDelivery.ToString(), Status = "Success", Message = "Food Delivery Updated Successfully" });

        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var fd = await _context.FoodDeliverys.FindAsync(id);
            if (fd is null)
                return BadRequest("Food Delivery Not Found");

            _context.FoodDeliverys.Remove(fd);
            await _context.SaveChangesAsync();
            return Ok(new Response { Data = GetAllDelivery().ToString(), Status = "Success", Message = "Food Delivery Updated Successfully" });

        }
    }
}
