using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_dotnet.Data;
using Pizza_dotnet.Models;

namespace Pizza_dotnet.Pages
{
    public class MenuModel : PageModel
    {
        public List<PizzaModel> Pizzas = new List<PizzaModel>();

        private readonly ApplicationDbContext _context;
        public MenuModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Pizzas = _context.Pizzas.ToList();
        }
    }
}
