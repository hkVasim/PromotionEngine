using Promotion.Model;
using System.Collections.Generic;
using System.Linq;

namespace Promotion.Repository
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProduct(Product product);
    }
}