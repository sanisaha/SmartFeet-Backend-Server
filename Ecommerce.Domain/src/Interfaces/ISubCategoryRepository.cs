using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Entities.SubCategoryAggregate;
using Ecommerce.Domain.src.Interface;

namespace Ecommerce.Domain.src.Interfaces
{
    public interface ISubCategoryRepository : IBaseRepository<SubCategory>
    {
        Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(Guid userId);
    }
}