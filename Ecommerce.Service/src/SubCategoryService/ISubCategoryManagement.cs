using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.SubCategoryAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.SubCategoryService
{
    public interface ISubCategoryManagement : IBaseService<SubCategory, SubCategoryReadDto, SubCategoryCreateDto, SubCategoryUpdateDto>
    {
        Task<IEnumerable<SubCategoryReadDto>> GetSubCategoryByIdAsync(Guid userId);
    }
}