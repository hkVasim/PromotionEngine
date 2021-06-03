using Promotion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(PromotionContext promotionContext)
          : base(promotionContext)
        {

        }

        public void CreateProduct(Product product)
        {
            this.Create(product);
        }

        public void UpdateProduct(Product product)
        {
            this.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            this.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            return this.FindAll();
        }

        public Product GetProductById(int id)
        {
            return this.FindByCondition(item => item.Id == id).FirstOrDefault();
        }
    }
}
