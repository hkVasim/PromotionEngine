using Promotion.Model;
using System.Collections.Generic;

namespace Promotion.BAL
{
    public interface IProductService
    {
        void GetPriceByType(Product product);
        int GetTotalPrice(List<Product> products);
    }
}