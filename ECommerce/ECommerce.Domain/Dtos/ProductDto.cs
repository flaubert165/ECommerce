using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Dtos
{
    public class ProductDto
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; private set; }
        public int CategoryId { get; private set; }
        public string Image { get; private set; }
        public Category Category { get; private set; }

        public ProductDto()
        {
        }
    }
}
