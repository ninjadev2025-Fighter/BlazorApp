using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDev.Domain
{
    public class BaseEntity
    {
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }  
    }
}
