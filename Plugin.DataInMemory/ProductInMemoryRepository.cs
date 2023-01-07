using CoreBusiness;
using System.Security.Cryptography.X509Certificates;
using UseCases.PluginInterfaces;

namespace Plugin.DataInMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository()
        {
            products = new List<Product>()
            {
                new Product{ProductId=1,CategoryId=1,Name="Iced-Tea",Quantity=120,Price=120.00},
                new Product{ProductId=2,CategoryId=1,Name="Canada Dry",Quantity=100,Price=100.00},
                new Product{ProductId=3,CategoryId=2,Name="Brown Bread",Quantity=60,Price=300.00},
                new Product{ProductId=3,CategoryId=2,Name="Bun",Quantity=150,Price=350.00}

            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

                products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
            
        }
        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(x => x.ProductId == productId);
        }
    }
}
