using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizza_dotnet.Data;
using Pizza_dotnet.Models;

namespace Pizza_dotnet.Pages
{
    public class PizzasModel : PageModel
    {
        public List<PizzaModel> Pizzas = new List<PizzaModel>();

        [BindProperty]
        public PizzaModel Pizza { get; set; }
        public float Price { get; private set; }
        public bool TomatoSauce { get; private set; }
        public bool Cheese { get; private set; }
        public bool Peperoni { get; private set; }
        public bool Mushroom { get; private set; }
        public bool Tuna { get; private set; }
        public bool Pineapple { get; private set; }
        public bool Ham { get; private set; }
        public bool Beef { get; private set; }
        public string Name { get; private set; }

        private readonly ApplicationDbContext _context;
        public PizzasModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Pizzas = _context.Pizzas.ToList();
        }

        public IActionResult OnPostAdd()
        {
            if (Pizza.TomatoSauce) Price += 1;
            if (Pizza.Cheese) Price += 1;
            if (Pizza.Peperoni) Price += 1;
            if (Pizza.Mushroom) Price += 1;
            if (Pizza.Tuna) Price += 1;
            if (Pizza.Pineapple) Price += 10;
            if (Pizza.Ham) Price += 1;
            if (Pizza.Beef) Price += 1;

            PizzaModel pizza = new PizzaModel();
            // pizzaOrder.id will be created automatically
            pizza.Name = Pizza.Name;
            pizza.Price = Pizza.Price;

            if (String.IsNullOrEmpty(pizza.Name))
            {
                return RedirectToPage("/Pizzas");
            }
            else
            {
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();
                return RedirectToPage("/Pizzas");
            }
        }

        public IActionResult OnPostEdit()
        {
            var pizza = _context.Pizzas.Where(p => p.Id == Pizza.Id).SingleOrDefault();
            if (pizza != null)
            {
                pizza.Name = Pizza.Name;
                pizza.Price = Pizza.Price;
                _context.SaveChanges();
            }
            
            return RedirectToPage("/Pizzas");
        }

        public IActionResult OnPostRemove()
        {
            var pizza = _context.Pizzas.Find(Pizza.Id);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                _context.SaveChanges();
            }
            return RedirectToPage("/Pizzas");
        }
    }
}
