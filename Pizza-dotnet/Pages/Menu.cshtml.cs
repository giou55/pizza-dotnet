using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_dotnet.Data;
using Pizza_dotnet.Models;
using System.Diagnostics;

namespace Pizza_dotnet.Pages
{
    public class MenuModel : PageModel
    {
        public List<PizzaModel> Pizzas = new List<PizzaModel>();

        [BindProperty]
        public PizzaModel Pizza { get; set; }

        [BindProperty]
        public OrderModel Order { get; set; }

        public string PizzaName { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerAddress { get; private set; }
        public string CustomerPhone { get; private set; }
        public int Quantity { get; private set; }
        public float TotalPrice { get; private set; }
        public string Timestamp { get; private set; }

        private readonly ApplicationDbContext _context;
        public MenuModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Pizzas = _context.Pizzas.ToList();
        }

        public IActionResult OnPostAdd()
        {
            OrderModel order = new OrderModel();
            order.PizzaName = Order.PizzaName;
            order.CustomerName = Order.CustomerName;
            order.CustomerAddress = Order.CustomerAddress;
            order.CustomerPhone = Order.CustomerPhone;
            order.Quantity = Order.Quantity;
            order.TotalPrice = 0.00f;
            order.Timestamp = DateTime.Now.ToString();

            _context.Orders.Add(order);
            _context.SaveChanges();

            Trace.WriteLine("Hello from console");
            return RedirectToPage("/Menu");
        }
    }
}
