using Core;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class AppUserRole:BaseEntity
    {
        public UserRole Role { get; set; }
        public AppUser AppUser { get; set; }
    }
}
