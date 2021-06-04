using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Promotion.DTO;
using Promotion.Repository;

namespace Promotion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionController(IPromotionRepository promotionRepository)
        {
            this._promotionRepository = promotionRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeOfPromotion"> Enter String ex. ABCD</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTotal")]
        public ActionResult GetAllProducts(string typeOfPromotion)
        {
            return Ok(this._promotionRepository.GetTotal(typeOfPromotion.ToCharArray()));
        }
    }
}