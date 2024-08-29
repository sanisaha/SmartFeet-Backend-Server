using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductSizeService
{
    public class ProductSizeManagement : BaseService<ProductSize, ProductSizeReadDto, ProductSizeCreateDto, ProductSizeUpdateDto>, IProductSizeManagement
    {
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IProductRepository _productRepository;

        public ProductSizeManagement(IProductSizeRepository productSizeRepository, IProductRepository productRepository) : base(productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
            _productRepository = productRepository;
        }
        public async Task<ProductSize> CreateAsync(ProductSizeCreateDto createDto)
        {
            try
            {
                if (!Enum.IsDefined(typeof(SizeValue), createDto.SizeValue))
                    throw new ArgumentException("Invalid size value.");


                var product = await _productRepository.GetAsync(p => p.Id == createDto.ProductId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                var productSizeEntity = createDto.CreateEntity();

                return await _productSizeRepository.CreateAsync(productSizeEntity);

            }
            catch (Exception ex)
            {
                throw new Exception("Error creating Product Size!.");
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var productSize = await _productSizeRepository.GetAsync(ps => ps.Id == id);
                if (productSize == null)
                    throw new ArgumentException("Product size not found.");

                return await _productSizeRepository.DeleteByIdAsync(id);

            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Product Size");
            }

        }

        public async Task<IEnumerable<ProductSizeReadDto>> GetSizesByProductIdAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetAsync(p => p.Id == productId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                var productSizes = await _productSizeRepository.GetSizesByProductIdAsync(productId);

                var productSizeDtos = productSizes.Select(Size =>
                {
                    var dto = new ProductSizeReadDto();
                    dto.FromEntity(Size);
                    return dto;
                });

                return productSizeDtos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Product Sizes!.");
            }
        }

        public async Task<bool> UpdateAsync(Guid id, ProductSizeUpdateDto updateDto)
        {
            try
            {
                var existingSize = await _productSizeRepository.GetAsync(ps => ps.Id == id);
                if (existingSize == null)
                    throw new ArgumentException("Product size not found.");

                if (!Enum.IsDefined(typeof(SizeValue), updateDto.SizeValue))
                    throw new ArgumentException("Invalid size value.");

                var product = await _productRepository.GetAsync(p => p.Id == updateDto.ProductId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                var productSizeToUpdate = updateDto.UpdateEntity(existingSize);
                return await _productSizeRepository.UpdateByIdAsync(productSizeToUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating Product Size: {ex.Message}", ex);
            }
        }
    }
}