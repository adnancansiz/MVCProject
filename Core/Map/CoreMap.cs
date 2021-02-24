using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map
{
    public class CoreMap<T>:EntityTypeConfiguration<T> where T:BaseEntity
    {
        public CoreMap()
        {
            Property(x => x.CreatedDate).IsOptional();
            Property(x => x.UpdatedDate).IsOptional();
            Property(x => x.CreatedDate).HasColumnType("datetime2");
            Property(x => x.UpdatedDate).HasColumnType("datetime2");
        }
    }
}
