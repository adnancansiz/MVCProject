using Core.Map;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Maps
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            Property(x => x.CategoryName).IsRequired();

        }
    }
}
