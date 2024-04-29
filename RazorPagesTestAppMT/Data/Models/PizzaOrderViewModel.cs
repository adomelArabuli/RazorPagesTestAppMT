using System.Text;

namespace RazorPagesTestAppMT.Data.Models
{
    public class PizzaOrderViewModel
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public StringBuilder Ingredients { get; set; }
    }
}
