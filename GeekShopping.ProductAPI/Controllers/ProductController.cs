﻿using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if(product == null) return NotFound();
            return Ok(product);
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpPost()]
        public async Task<ActionResult<ProductVO>> Create(ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var products = await _repository.Create(vo);
            return Ok(products);
        }        
        [HttpPut()]
        public async Task<ActionResult<ProductVO>> Update(ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var products = await _repository.Update(vo);
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteById(id);
            if(!status) return BadRequest();
            return Ok(status);
        }
    }
}
