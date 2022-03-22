using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public Product()
        {
        }

        public string Name { get; private set; }
        public string Description { private get; set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. To short, minimum 3 characteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. description is required.");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description. To short, minimum 5 characteres.");
            DomainExceptionValidation.When(price < 0, "Invalid price value.");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");
            DomainExceptionValidation.When(image.Length > 250, "Invalid image name, too long, maximun 250 characteres");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
