using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TrainingFPT.DBContext
{
    public class UserDBContext
    {
        [Key]
        public int Id { get; set; }

        [Column("Name", TypeName ="varchar(50)"), Required]
        public required string Name { get; set; }

        [Column("RoleId", TypeName = "int"), Required]
        public required int RoleId { get; set; }

        [Column("Username", TypeName = "varchar(50)"), Required]
        public required string Username { get; set; }

        [Column("Password", TypeName = "varchar(50)"), Required]
        public required string Password { get; set; }

        [Column("FirstName", TypeName = "varchar(50)"), Required]
        public required string FirstName { get; set; }

        [Column("LastName", TypeName = "varchar(50)"), Required]
        public required string LastName { get; set; }

        [Column("Gender", TypeName = "varchar(50)"), Required]
        public required string Gender { get; set; }

        [Column("Email", TypeName = "varchar(50)"), Required]
        public required string Email { get; set; }

        [Column("Address", TypeName = "varchar(50)"), Required]
        public required string Address { get; set; }

        [Column("DoB", TypeName = "date"), Required]
        public required DateOnly DoB { get; set; }

        [Column("Education", TypeName = "varchar(50)"), Required]
        public required string Education { get; set; }

        [Column("ProLang", TypeName = "text"), Required]
        public required string ProLang { get; set; }

        [Column("TOEIC", TypeName = "int"), Required]
        public required int TOEIC { get; set; }

        [Column("Skills", TypeName = "text"), Required]
        public required string Skills { get; set; }

        [Column("Phone", TypeName = "varchar(50)"), Required]
        public required string Phone { get; set; }

        [Column("IpClient", TypeName = "varchar(50)"), Required]
        public required string IpClient { get; set; }

        [Column("LastLogin", TypeName = "datetime"), Required]
        public required DateTime LastLogin { get; set; }

        [Column("LastLogout", TypeName = "datetime"), Required]
        public required DateTime LastLogout { get; set; }

        [AllowNull]
        public DateTime? CreatedAt { get; set; }

        [AllowNull]
        public DateTime? UpdatedAt { get; set; }

        [AllowNull]
        public DateTime? DeletedAt { get; set; }
    }
}
