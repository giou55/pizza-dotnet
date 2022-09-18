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
        public bool Feta { get; private set; }
        public bool Pepperoni { get; private set; }
        public bool Mushroom { get; private set; }
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
            if (Pizza.Tomato) Price += 1;
            if (Pizza.Feta) Price += 1;
            if (Pizza.Pepperoni) Price += 1;
            if (Pizza.Mushroom) Price += 1;
            if (Pizza.Ham) Price += 1;

            PizzaModel pizza = new PizzaModel();
            // pizzaOrder.id will be created automatically
            pizza.Name = Pizza.Name;
            pizza.Description = Pizza.Description;
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
                pizza.Description = Pizza.Description;
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
