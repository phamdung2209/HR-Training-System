using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TrainingFPT.DBContext
{
    public class CategoryDBContext
    {
        [Key]
        public int Id { get; set; }

        [Column("CategoryId", TypeName = "int"), Required]
        public int CategoryId { get; set; }

        [Column("Name", TypeName = "string"), Required]
        public required string Name { get; set; }

        [Column("Description", TypeName = "varchar(250)"), Required]
        public required string Description { get; set; }

        [Column("ImageUrl", TypeName = "varchar(250)"), AllowNull]
        public string ImageUrl { get; set; }

        [Column("LikeCourse", TypeName = "int")]
        public int LikeCourse { get; set; }

        [Column("StarCourse", TypeName = "int")]
        public int StarCourse { get; set; }

        [Column("Status", TypeName = "varchar(50)"), AllowNull]
        public string Status { get; set; }

        [AllowNull]
        public DateTime? CreatedAt { get; set; }

        [AllowNull]
        public DateTime? UpdatedAt { get; set; }

        [AllowNull]
        public DateTime? DeletedAt { get; set; }
    }
}
