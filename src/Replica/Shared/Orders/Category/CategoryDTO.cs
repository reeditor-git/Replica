using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica.DTO.Orders.Category
{
    public class CategoryDTO : DTOBase
    {
        public string Name { get; set; }

        public ICollection<SubcategoryDTO>? Subcategories { get; set; }
    }
}
