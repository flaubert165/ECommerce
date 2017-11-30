using System;
using System.Collections.Generic;
using AutoMapper;
using ECommerce.Domain.Dtos;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Application.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]ProductDto productDto)
        {

            var product = _mapper.Map<Product>(productDto);

            try
            {
                _productService.Create(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            var productDtos = _mapper.Map<IList<ProductDto>>(products);

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;

            try
            {
                _productService.Update(product);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody]ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            _productService.Delete(product);

            return Ok();
        }
    }
}
