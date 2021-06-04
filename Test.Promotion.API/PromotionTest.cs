using NUnit.Framework;
using Promotion.API.Controllers;
using Promotion.Repository;

namespace Test.Promotion.API
{
    public class PromotionTest
    {
        /// <summary>
        /// Tet cases not completed need to work on this
        /// </summary>
        private PromotionContext promotionContext;
        private PromotionController promotionController;
        private IPromotionRepository promotionRepository;
        private IProductRepository productRepository;

        [SetUp]
        public void Setup()
        {
            productRepository = new ProductRepository(promotionContext);
            promotionRepository = new PromotionRepository(promotionContext, productRepository);
            promotionController = new PromotionController(promotionRepository);
        }

        [Test]
        [TestCase("ABC")]
        [TestCase("AAAAABBBBBC")]
        [TestCase("AAABBBBBCD")]
        public void Test1(string inputString)
        {
            var result = promotionController.GetTotal(inputString);
            Assert.AreEqual(100, result);
            Assert.Pass();
        }
    }
}
