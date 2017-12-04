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
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]CategoryDto categoryDto)
        {

            var category = _mapper.Map<Category>(categoryDto);

            try
            {
                _categoryService.Create(category);
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
            var categories = _categoryService.GetAll();
            var categoryDtos = _mapper.Map<IList<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.Id = id;

            try
            {
                _categoryService.Update(category);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);

            return Ok();
        }
    }
}
