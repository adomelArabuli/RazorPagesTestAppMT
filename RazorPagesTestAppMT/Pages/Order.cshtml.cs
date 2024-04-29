using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestAppMT.Data.Models;
using RazorPagesTestAppMT.Data.Models.DbModels;
using System.Text;

namespace RazorPagesTestAppMT.Pages
{
    public class OrderModel : PageModel
    {
        public List<PizzaOrder> PizzaOrders { get; set; }
        public List<PizzaOrderViewModel> FilterePizzaOrders { get; set; }
        private readonly ApplicationDbContext _db;

        public OrderModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            PizzaOrders = _db.PizzaOrders.ToList();

            FilterePizzaOrders = GetPizzaOrderViewModel(PizzaOrders);

            ViewData["FilteredPizzaOrders"] = FilterePizzaOrders;
            return Page();

        }

        public IActionResult OnPostDelete(int orderId)
        {
            var orderToDelete = _db.PizzaOrders.FirstOrDefault(x => x.Id == orderId);
            if (orderToDelete is null)
                return RedirectToPage("/NotFountPage");

            _db.PizzaOrders.Remove(orderToDelete);
            _db.SaveChanges();

            return RedirectToPage("Order");
        }

        public List<PizzaOrderViewModel> GetPizzaOrderViewModel(List<PizzaOrder> pizzaOrders)
        {
            var pizzaOrderViewModels = new List<PizzaOrderViewModel>();

            var ingredientProperties = typeof(PizzaOrder).GetProperties().Where(p => p.PropertyType == typeof(bool));

            foreach (var order in pizzaOrders)
            {
                var pizzaModel = new PizzaOrderViewModel()
                {
                    Id = order.Id,
                    PizzaPrice = (float)order.PizzaPrice,
                    PizzaName = order.PizzaName,
                    Ingredients = new StringBuilder()
                };

                foreach (var prop in ingredientProperties)
                {
                    var propValue = prop.GetValue(order);
                    if (propValue != null && (bool)propValue)
                    {
                        pizzaModel.Ingredients.Append($"{prop.Name}, ");
                    }
                }
                if (pizzaModel.Ingredients.Length != 0)
                {
                    pizzaModel.Ingredients.ToString().TrimEnd();
                }
                pizzaOrderViewModels.Add(pizzaModel);
            }

            return pizzaOrderViewModels;
        }

    }
}
