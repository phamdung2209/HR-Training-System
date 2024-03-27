using System.ComponentModel.DataAnnotations;
using TrainingFPT.Validation;

namespace TrainingFPT.Models
{
    public class CourseModel
    {
        public List<CourseDetail>? CourseDetailsList { get; set; }
    }

    public class CourseDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CategoryId is required!")] public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        [Required(ErrorMessage = "Name is required!")] public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "ImageUrl is required!")]
        [AlowExtensionFile(new string[] { ".png", ".jpg", ".jpeg", "gift" })]
        [AlowSizeFile(5 * 1024 * 1024)]
        public IFormFile ImageUrl { get; set; }

        public string? ImageUrlString { get; set; }

        public int? LikeCourse { get; set; }

        public int? StarCourse { get; set; }

        [Required(ErrorMessage = "Status is required!")] public string Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
    }
}
