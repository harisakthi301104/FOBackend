namespace FOBackend.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Cart Cart { get; set; } = null!;
        // public Item Item { get; set; }
    }
}
