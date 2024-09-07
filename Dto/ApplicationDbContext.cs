using FoodDeliveryAPI.Dto.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Dto
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<FoodDelivery> FoodDeliverys { get; set; }
        public DbSet<PaymentMade> PaymentMades { get; set; }

    }
}
