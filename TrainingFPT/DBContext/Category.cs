using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingFPT.DBContext
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column("Name", TypeName = "nvarchar(50)"), Required]
        public string Name { get; set; }

        [Column("Description", TypeName = "text")]
        public string? Description { get; set; }

        [Column("Poster", TypeName = "nvarchar(MAX)"), Required]
        public string? Poster { get; set; }

        [Column("ParentId", TypeName = "nvarchar(50)"), Required]
        public int ParentId { get; set; }

        [Column("Status", TypeName = "varchar(20)"), Required]
        public bool Status { get; set; }
    }
}
