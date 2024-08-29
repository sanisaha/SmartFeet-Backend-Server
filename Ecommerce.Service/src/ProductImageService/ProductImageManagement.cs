using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.ProductAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.ProductImageService
{
    public class ProductImageManagement : BaseService<ProductImage, ProductImageReadDto, ProductImageCreateDto, ProductImageUpdateDto>, IProductImageManagement
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductRepository _productRepository;

        public ProductImageManagement(IProductImageRepository productImageRepository, IProductRepository productRepository) : base(productImageRepository)
        {
            _productImageRepository = productImageRepository;
            _productRepository = productRepository;
        }
        public async Task<ProductImage> CreateAsync(ProductImageCreateDto createDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(createDto.ImageURL))
                    throw new ArgumentException("Image URL is required.");

                var product = await _productRepository.GetAsync(p => p.Id == createDto.ProductId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                var productImage = createDto.CreateEntity();

                return await _productImageRepository.CreateAsync(productImage);

            }
            catch (Exception)
            {
                throw new Exception("Error creating product image!");
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var productImage = await _productImageRepository.GetAsync(pi => pi.Id == id);
                if (productImage == null)
                    throw new ArgumentException("Product image not found.");

                return await _productImageRepository.DeleteByIdAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("Error deleting product image!");
            }
        }

        public async Task<ProductImageReadDto> GetByIdAsync(Guid id)
        {
            try
            {
                var productImage = await _productImageRepository.GetAsync(p => p.Id == id);
                if (productImage == null)
                    throw new ArgumentException("Product Image not found.");

                var productImageReadDto = new ProductImageReadDto();
                productImageReadDto.FromEntity(productImage);

                return productImageReadDto;
            }
            catch (Exception)
            {
                throw new Exception("Error Retrieving Product Image!.");
            }
        }

        public async Task<IEnumerable<ProductImageReadDto>> GetImagesByProductIdAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetAsync(p => p.Id == productId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                var productImages = await _productImageRepository.GetImagesByProductIdAsync(productId);
                var productImageDtos = productImages.Select(Image =>
                {
                    var dto = new ProductImageReadDto();
                    dto.FromEntity(Image);
                    return dto;
                });

                return productImageDtos;
            }
            catch (Exception)
            {
                throw new Exception("Error Retrieving Product Images!.");
            }
        }

        public async Task<bool> UpdateAsync(Guid id, ProductImageUpdateDto updateDto)
        {
            try
            {
                var existingImage = await _productImageRepository.GetAsync(p => p.Id == id);

                if (existingImage == null)
                    throw new ArgumentException("Product image not found.");

                if (string.IsNullOrWhiteSpace(updateDto.ImageURL))
                    throw new ArgumentException("Image URL is required.");

                var product = await _productRepository.GetAsync(p => p.Id == updateDto.ProductId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                var productImageToUpdate = updateDto.UpdateEntity(existingImage);

                return await _productImageRepository.UpdateByIdAsync(productImageToUpdate);
            }
            catch (Exception)
            {
                throw new Exception("Error Updating Product image!.");
            }
        }

        public async Task<ProductImageReadDto> GetMainImageForProductAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetAsync(p => p.Id == productId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                var productMainImage = await _productImageRepository.GetMainImageForProductAsync(productId);

                var productImageReadDto = new ProductImageReadDto();
                productImageReadDto.FromEntity(productMainImage);

                return productImageReadDto;
            }
            catch
            {
                throw new Exception("Error Retrieving Product Image!.");
            }
        }

        public async Task<int> GetImageCountByProductIdAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetAsync(p => p.Id == productId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                return await _productImageRepository.GetImageCountByProductIdAsync(productId);
            }
            catch
            {
                throw new Exception("Error Retrieving the Image count!.");
            }
        }

        public async Task<bool> DeleteImagesByProductIdAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetAsync(p => p.Id == productId);
                if (product == null)
                    throw new ArgumentException("Invalid product.");

                return await _productImageRepository.DeleteImagesByProductIdAsync(productId);
            }
            catch
            {
                throw new Exception("Error Deleting images!.");
            }
        }
    }
}