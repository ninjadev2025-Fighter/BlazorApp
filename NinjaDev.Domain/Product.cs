using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDev.Domain
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "اسم المنتج")]
        public string Name{ get; set; }


        public decimal Price { get; set; }
        public int Qty { get; set; }
    }
}
