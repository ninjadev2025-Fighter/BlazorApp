using System.ComponentModel.DataAnnotations;

namespace NinjaDev.Domain
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        public string? Description { get; set; }

    }
}
