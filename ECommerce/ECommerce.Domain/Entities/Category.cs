using ECommerce.Helpers.Validation;

namespace ECommerce.Domain.Entities
{
    public class Category : Entity
    {
        public string Title { get; private set; }

        protected Category() { }

        public Category(string title)
        {
            SetTitle(title);
        }

        public void SetTitle(string title)
        { 
            Guard.ForNullOrEmpty(title, "");
            Guard.StringLength("", title, 50);
            this.Title = title;
        }
    }
}