namespace Pizza_dotnet.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public string Timestamp { get; set; }
    }
}
