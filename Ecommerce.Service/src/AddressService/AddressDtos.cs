
using System.ComponentModel.DataAnnotations;
using Ecommerce.Domain.src.Shared;
using Ecommerce.Service.src.Shared;
namespace Ecommerce.Service.src.AddressService
{
    public class Address : BaseEntity
    {
        [Required]
        public string UnitNumber { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "Unit number name must be up to {1} characters long.")]

        public string StreetNumber { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "Street number name must be up to {1} characters long.")]
        public string AddressLine1 { get; set; } = string.Empty;

        public string? AddressLine2 { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "City must be up to {1} characters long.")]
        public string? City { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "Postal code must be up to {1} characters long.")]
        public string? PostalCode { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "Country name must be up to {1} characters long.")]
        public string? Country { get; set; } = string.Empty;
    }

    // public class Address mainly stay in the domain layer, need to remove

    public class AddressReadDto : BaseReadDto<Address>
    {
        public string UnitNumber { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }
        public string? City { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;

        public override void FromEntity(Address entity)
        {
            base.FromEntity(entity);
            UnitNumber = entity.UnitNumber;
            StreetNumber = entity.StreetNumber;
            AddressLine1 = entity.AddressLine1;
            AddressLine2 = entity.AddressLine2;
            City = entity.City;
            PostalCode = entity.PostalCode;
            Country = entity.Country;
        }
    }
    public class AddressCreateDto : ICreateDto<Address>
    {
        public string UnitNumber { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }
        public string? City { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;

        public Address CreateEntity()
        {
            return new Address
            {
                UnitNumber = UnitNumber,
                StreetNumber = StreetNumber,
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                City = City,
                PostalCode = PostalCode,
                Country = Country
            };
        }
    }
    public class AddressUpdateDto : IUpdateDto<Address>
    {
        public Guid Id { get; set; }
        public string UnitNumber { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }
        public string? City { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;

        public Address UpdateEntity(Address entity)
        {
            entity.UnitNumber = UnitNumber;
            entity.StreetNumber = StreetNumber;
            entity.AddressLine1 = AddressLine1;
            entity.AddressLine2 = AddressLine2;
            entity.City = City;
            entity.PostalCode = PostalCode;
            entity.Country = Country;
            return entity;
        }
    }
}