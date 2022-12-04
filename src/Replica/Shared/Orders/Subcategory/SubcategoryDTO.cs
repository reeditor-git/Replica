﻿using Replica.Shared.Base;
using Replica.Shared.Orders.Category;
using Replica.Shared.Orders.Product;

namespace Replica.Shared.Orders.Subcategory
{
    public class SubcategoryDTO : DTOBase
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public CategoryDTO Category { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }
    }
}
