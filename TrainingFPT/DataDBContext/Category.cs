using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TrainingFPT.DataDBContext
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column("Name", TypeName = "nvarchar(50)"), Required]
        public string? Name { get; set; }

        [Column("Description", TypeName = "text")]
        public string? Description { get; set; }

        [Column("Poster", TypeName = "nvarchar(MAX)"), Required]
        public IFormFile? Poster { get; set; }

        [Column("ParentId", TypeName = "nvarchar(50)"), Required]
        public string? ParentId { get; set; }

        [Column("Status", TypeName = "varchar(20)"), Required]
        public string? Status { get; set; }

        [AllowNull]
        public DateTime? Created_at { get; set; }

        [AllowNull]
        public DateTime? Updated_at { get; set; }

        [AllowNull]
        public DateTime? Deleted_at { get; set; }

    }
}
