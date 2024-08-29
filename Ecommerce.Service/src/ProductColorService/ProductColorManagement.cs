using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.ProductAggregate;
using Ecommerce.Domain.src.Interface;
using Ecommerce.Domain.src.Interface.ProductInterface;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductColorService
{
    public class ProductColorManagement : BaseService<ProductColor, ProductColorReadDto, ProductColorCreateDto, ProductColorUpdateDto>, IProductColorManagement
    {
        private readonly IProductColorRepository _productColorRepository;
        private readonly IProductRepository _productRepository;

        public ProductColorManagement(IProductColorRepository productColorRepository, IProductRepository productRepository)
        {
            _productColorRepository = productColorRepository;
            _productRepository = productRepository;
        }
        public async Task<ProductColor> CreateAsync(ProductColorCreateDto createDto)
        {
            try
            {
                var product = await _productRepository.GetAsync(p => p.Id == createDto.ProductId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                if (string.IsNullOrWhiteSpace(createDto.ColorName))
                    throw new ArgumentException("Color name is required.");

                var productColor = createDto.CreateEntity();

                return await _productColorRepository.CreateAsync(productColor);
            }
            catch
            {
                throw new Exception("Error creating product color!");
            }

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var productColor = await _productColorRepository.GetAsync(pc => pc.Id == id);
                if (productColor == null)
                    throw new ArgumentException("Product color not found.");

                return await _productColorRepository.DeleteByIdAsync(id);
            }
            catch
            {
                throw new Exception("Error deleting product color!");
            }
        }

        public async Task<bool> UpdateAsync(Guid id, ProductColorUpdateDto updateDto)
        {
            try
            {
                var existingColor = await _productColorRepository.GetAsync(pc => pc.Id == id);

                if (existingColor == null)
                    throw new ArgumentException("Product color not found.");

                if (string.IsNullOrWhiteSpace(updateDto.ColorName))
                    throw new ArgumentException("Color name is required.");

                var product = await _productRepository.GetAsync(p => p.Id == updateDto.ProductId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                var productColorToUpdate = updateDto.UpdateEntity(existingColor);

                return await _productColorRepository.UpdateByIdAsync(productColorToUpdate);
            }
            catch
            {
                throw new Exception("Error Updating Product color!.");
            }
        }
        public async Task<IEnumerable<ProductColorReadDto>> GetColorsByProductIdAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetAsync(p => p.Id == productId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                var productColors = await _productColorRepository.GetColorsByProductIdAsync(productId);
                var productColorsDtos = productColors.Select(Color =>
                {
                    var dto = new ProductColorReadDto();
                    dto.FromEntity(Color);
                    return dto;
                });

                return productColorsDtos;
            }
            catch
            {
                throw new Exception("Error Retrieving Product Colors!.");
            }
        }
        public async Task<ProductColorReadDto> GetColorByNameAsync(string colorName)
        {
            try
            {
                if (!Enum.TryParse<ColorName>(colorName, true, out var colorEnum))
                {
                    throw new ArgumentException("Invalid color name.");
                }

                var productColor = await _productColorRepository.GetAsync(pc => pc.ColorName == colorEnum);
                if (productColor == null)
                {
                    throw new ArgumentException("Product color not found.");
                }

                var productColorReadDto = new ProductColorReadDto();
                productColorReadDto.FromEntity(productColor);

                return productColorReadDto;

            }
            catch
            {
                throw new Exception("Error Retrieving Product Color!.");
            }
        }
    }
}