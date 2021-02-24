using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class SubCategory:BaseEntity
    {
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual Category GetCategory { get; set; }

    }
}
