using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_dotnet.Data;
using Pizza_dotnet.Models;

namespace Pizza_dotnet.Pages
{
    public class OrdersModel : PageModel
    {
        public List<OrderModel> Orders = new List<OrderModel>();

        private readonly ApplicationDbContext _context;
        public OrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Orders = _context.Orders.ToList();
        }
    }
}
