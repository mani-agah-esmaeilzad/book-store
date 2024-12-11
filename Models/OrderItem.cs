namespace bookstore.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
