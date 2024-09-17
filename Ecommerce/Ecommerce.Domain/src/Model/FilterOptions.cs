using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.src.Model
{
    public class FilterOptions
    {
        public CategoryName? Category { get; set; }
        public string? Brand { get; set; }
        public SubCategoryName? SubCategory { get; set; }
        public SizeValue? Size { get; set; }
    }
}