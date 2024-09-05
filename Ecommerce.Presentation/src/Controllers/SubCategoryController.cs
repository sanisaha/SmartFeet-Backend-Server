using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.SubCategoryAggregate;
using Ecommerce.Presentation.src.Controllers;
using Ecommerce.Service.src.SubCategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SubCategoryController : AppController<SubCategory, SubCategoryReadDto, SubCategoryCreateDto, SubCategoryUpdateDto>
    {
        private readonly ISubCategoryManagement _subCategoryManagement;

        public SubCategoryController(ISubCategoryManagement subCategoryManagement) : base(subCategoryManagement)
        {
            _subCategoryManagement = subCategoryManagement;
        }

        //[Authorize]
        public override async Task<ActionResult<SubCategoryReadDto>> CreateAsync(SubCategoryCreateDto entity)
        {
            return await base.CreateAsync(entity);
        }
        //[Authorize]
        public override async Task<ActionResult<SubCategoryReadDto>> UpdateAsync(Guid id, SubCategoryUpdateDto entity)
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
        public async Task<IEnumerable<SubCategoryReadDto>> GetSubCategoryByIdAsync(Guid userId)
        {
            return await _subCategoryManagement.GetSubCategoryByIdAsync(userId);
        }
    }
}