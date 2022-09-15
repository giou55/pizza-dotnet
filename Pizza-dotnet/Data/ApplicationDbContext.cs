using Microsoft.EntityFrameworkCore;
using Pizza_dotnet.Models;

namespace Pizza_dotnet.Data

{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<PizzaModel> Pizzas { get; set; }
        public object PizzaModel { get; internal set; }
        public object Pizza { get; internal set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
