namespace ECommerce.Domain.Entities
{
    public class Category : Entity
    {
        protected Category() { }

        public Category(string title)
        {
            this.Title = title;
        }

        public string Title { get; private set; }

    }
}