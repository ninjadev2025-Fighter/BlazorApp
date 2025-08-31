using System.ComponentModel.DataAnnotations;

namespace NinjaDev.Domain
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "الاسم من 3 لـ 50 حرف")]
        [Required(ErrorMessage ="يجب ادخال الاسم !")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="يجب ادخال الاسم !")]
        public string? Description { get; set; }


        public List<Product> Products { get; set; } = new ();

    }
}
