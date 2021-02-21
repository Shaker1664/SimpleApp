using api.Authentication;
using api.Models;
using api.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Product
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _service.GetAll();

            var mappedProducts = _mapper.Map<IEnumerable<ProductIndex>>(products);

            return Ok(mappedProducts);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetProduct(Guid id)
        {
            if (id==null)
            {
                return BadRequest(new { Message = "Id cannot be null" });
            }
            var product = await _service.GetById(id);

            if (product == null)
            {
                return NotFound(new { Message = "Product not found!" });
            }

            var mappedUser = _mapper.Map<ProductDetails>(product);

            return Ok(mappedUser);
        }

        // POST: api/Product
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<CreateProduct>> Create(CreateProduct product)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.CreateAsync(product);

                if (response == null)
                {
                    return BadRequest(new { Message = "Product creation failed! Please check product details and try again" });
                }
                return Ok(response);
            }
            return BadRequest(new { Message = "Invalid Product Object" });
        }

        //PUT: api/Product
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<EditProduct>> Update(EditProduct product)
        {
            if (product != null)
            {
                var response = await _service.UpdateAsync(product);
                if (response == null)
                {
                    return BadRequest(new { Message = "Product Update failed!" });
                }
                else
                    return Ok(response);
            }
            else
                return BadRequest(new { Message = "Product cannot be null object!" });
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> DeleteProduct(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            if (result == null)
            {
                return NotFound(new { Message = "Product not found" });
            }
            return Ok(new { Message = $"Product {result} deleted successfully" });
        }
    }
}
