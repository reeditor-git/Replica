using Replica.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica.Domain.Entities.Hookahs
{
    public class Tobacco : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TobaccoType Type { get; set; }

        public decimal Price { get; set; }
    }
}
