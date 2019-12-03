namespace SportsStore.Models
{
    public class CartLine
    {
        public int CartLineID { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string Description
        {
            get
            {
                return $"{Quantity}x {Product.Name} ({Product.Price:C2})";
            }
        }
    }
}