namespace ECommerce.Domain.Entities
{
    public class OrderItem
    {
        public OrderItem() { }

        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public int OrderId { get; private set; }
        public Order Order { get; private set; }
    }
}
