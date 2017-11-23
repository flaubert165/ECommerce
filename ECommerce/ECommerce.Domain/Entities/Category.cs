namespace ECommerce.Domain.Entities
{
    public class Category
    {
        protected Category() { }

        public Category(string title)
        {
            this.Title = title;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }

    }
}