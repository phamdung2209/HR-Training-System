using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TrainingFPT.DBContext
{
    public class RoleDBContext
    {
        [Key]
        public int Id { get; set; }

        [Column("Name", TypeName ="varchar(50)"), Required]
        public required string Name { get; set; }

        [Column("Description", TypeName ="varchar(250)"), AllowNull]
        public string? Description { get; set; }

        [Column("Status", TypeName ="varchar(50)"), Required]
        public required string Status { get; set; }

        [AllowNull]
        public DateTime? CreatedAt { get; set; }

        [AllowNull]
        public DateTime? UpdatedAt { get; set; }

        [AllowNull]
        public DateTime? DeletedAt { get; set; }
    }
}
