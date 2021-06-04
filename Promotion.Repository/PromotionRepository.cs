using Promotion.DTO;
using Promotion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Promotion.Repository
{
    public class PromotionRepository : RepositoryBase<TypeOfPromotion>, IPromotionRepository
    {
        private readonly IProductRepository _productRepository;
        public PromotionRepository(PromotionContext promotionContext,
                                    IProductRepository productRepository)
          : base(promotionContext)
        {
            this._productRepository = productRepository;
        }
        public decimal GetTotal(char[] product)
        {
            decimal result = 0M;

            //All Productes loaded
            var getAllProducts = this._productRepository.GetAllProducts().ToList();

            // Count form Input string
            var repeatedProductWithCount = product.GroupBy(p => p)
                                                  .Select(pc => new { PromotionChar = pc.Key, Count = pc.Count() });

            //calculation
            foreach (var item in repeatedProductWithCount)
            {
                decimal total;
                var objProduct = getAllProducts.Where(p => p.Unit == Convert.ToString(item.PromotionChar)).FirstOrDefault();

                switch (item.PromotionChar)
                {
                    case 'A':
                        total = (item.Count / 3) * 130 + (item.Count % 3 * objProduct.Price);
                        result = result + total;
                        break;
                    case 'B':
                        total = (item.Count / 2) * 45 + (item.Count % 2 * objProduct.Price);
                        result = result + total;
                        break;
                    case 'C':
                        if (!product.Contains('D'))
                        {
                            total = (item.Count * objProduct.Price);
                            result = result + total;
                        }
                        break;
                    case 'D':
                        if (product.Contains('C'))
                        {
                            result = result + 30;
                        }
                        else
                        {
                            total = (item.Count * objProduct.Price);
                            result = result + total;
                        }
                        break;
                    default:
                        total = (item.Count * objProduct.Price);
                        result = result + total;
                        break;
                }
            }
            return result;
        }
    }
}
