using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_dotnet.Data;
using Pizza_dotnet.Models;

namespace Pizza_dotnet.Pages
{
    public class MenuModel : PageModel
    {
        public List<PizzaModel> Pizzas = new List<PizzaModel>();
        public List<OrderModel> Orders = new List<OrderModel>();

        [BindProperty]
        public PizzaModel Pizza { get; set; }

        public int Quantity { get; private set; }
        public string PizzaName { get; private set; }

        private readonly ApplicationDbContext _context;
        public MenuModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Pizzas = _context.Pizzas.ToList();
            Orders = _context.Orders.ToList();
        }

        public IActionResult OnPostAdd()
        {
            OrderModel order = new OrderModel();
            order.PizzaName = PizzaName;
            order.Quantity = Quantity;

            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToPage("/Menu");
        }
    }
}
