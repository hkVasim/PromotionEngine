using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promotion.Model;
using Promotion.Repository;
using PromotionDTO;

namespace Promotion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get All Product.
        /// </summary>
        /// <returns>List of Product.</returns>
        [HttpGet]
        [Route("GetAllProducts")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return this._productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get Empployee by Id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Product.</returns>
        [HttpGet]
        [Route("GetProductById")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = this._productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        /// <summary>
        /// Update Product.
        /// </summary>
        /// <param name="product">product.</param>
        /// <returns>Update Product.</returns>
        [HttpPut]
        public IActionResult Update(Product product)
        {
            try
            {
                var result = this._productRepository.GetProductById(product.Id);
                if (result != null)
                {
                    this._productRepository.UpdateProduct(product);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Add Product.
        /// </summary>
        /// <param name="productDTO">productModel.</param>
        /// <returns>Product.</returns>
        [HttpPost]
        public ActionResult<Product> Create([FromBody] ProductForCreateDTO productForCreateDTO)
        {
            var product = this._mapper.Map<Product>(productForCreateDTO);
            this._productRepository.CreateProduct(product);
            return this.Ok();
        }

        /// <summary>
        /// Delete Product by Id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Delete Record.</returns>
        [HttpDelete]
        public ActionResult<Product> Delete(int id)
        {
            var user = this._productRepository.GetProductById(id);
            if (user == null)
            {
                return NotFound();
            }

            this._productRepository.DeleteProduct(user);
            return user;
        }
    }
}