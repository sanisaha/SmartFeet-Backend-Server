using Ecommerce.Domain.src.CategoryAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManagement _categoryManagement;

        public CategoryController(ICategoryManagement categoryManagement)
        {
            _categoryManagement = categoryManagement;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryReadDto>> GetCategoryByIdAsync(Guid userId)
        {
            return await _categoryManagement.GetCategoryByIdAsync(userId);
        }
    }
}
