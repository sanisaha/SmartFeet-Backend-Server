using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : AppController<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        private readonly ICategoryManagement _categoryManagement;

        public CategoryController(ICategoryManagement categoryManagement) : base(categoryManagement)
        {
            _categoryManagement = categoryManagement;
        }

        //[Authorize]
        public override async Task<ActionResult<CategoryReadDto>> CreateAsync(CategoryCreateDto entity)
        {
            var existingCategory = await _categoryManagement.GetCategoryByNameAsync(entity.CategoryName);
            if (existingCategory != null)
            {
                return Conflict(new { message = "A category with this name already exists." });
            }
            return await base.CreateAsync(entity);
        }
        //[Authorize]
        public override async Task<ActionResult<CategoryReadDto>> UpdateAsync(Guid id, CategoryUpdateDto entity)
        {
            return await base.UpdateAsync(id, entity);
        }
        //[Authorize]
        public override async Task<ActionResult> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }

        [HttpGet("{userId}")]
        //[Authorize]
        public async Task<IEnumerable<CategoryReadDto>> GetCategoryByIdAsync(Guid userId)
        {
            return await _categoryManagement.GetCategoryByIdAsync(userId);
        }
        [HttpGet("categoryName/{categoryName}")]
        public async Task<IActionResult> GetCategoryByNameAsync(string categoryName)
        {
            if (!Enum.TryParse(categoryName, true, out CategoryName categoryEnum))
            {
                return BadRequest("Invalid category name");
            }
            var category = await _categoryManagement.GetCategoryByNameAsync(categoryEnum);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }
    }
}
