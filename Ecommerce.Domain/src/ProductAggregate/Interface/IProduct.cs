using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.src.ProductAggregate.Interface
{
    public interface IProduct
    {
        Guid Id { get; set; }
        string Title { get; set; }
        Guid CategoryId { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        int Stock { get; set; }
        string ProductLine { get; set; }

        // Navigation property
        Category Category { get; set; }

        bool IsInStock();
        void UpdateStock(int quantity);
    }
}