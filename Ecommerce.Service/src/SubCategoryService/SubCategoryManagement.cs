using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.SubCategoryAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.SubCategoryService
{
    public class SubCategoryManagement : BaseService<SubCategory, SubCategoryReadDto, SubCategoryCreateDto, SubCategoryUpdateDto>, ISubCategoryManagement
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryManagement(ISubCategoryRepository subCategoryRepository) : base(subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IEnumerable<SubCategoryReadDto>> GetSubCategoryByIdAsync(Guid userId)
        {
            var subCategory = await _subCategoryRepository.GetSubCategoryByIdAsync(userId);
            return subCategory.Select(x => new SubCategoryReadDto
            {
                Id = x.Id,
                SubCategoryName = x.SubCategoryName,
                CategoryId = x.CategoryId,
                Products = x.Products
            });
        }
        public async Task<SubCategoryReadDto?> GetSubCategoryByNameAndCategoryIdAsync(SubCategoryName subCategoryName, Guid categoryId)
        {
            var subCategory = await _subCategoryRepository.GetSubCategoryByNameAndIdAsync(subCategoryName.ToString(), categoryId);
            if (subCategory == null)
            {
                return null;
            }
            return new SubCategoryReadDto
            {
                Id = subCategory.Id,
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId = subCategory.CategoryId,
                Products = subCategory.Products
            };
        }
    }

}