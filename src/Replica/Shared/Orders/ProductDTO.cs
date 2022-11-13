using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica.DTO.Orders
{
    public class ProductDTO : DTOBase
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public SubcategoryDTO? Subcategory { get; set; }
    }
}
