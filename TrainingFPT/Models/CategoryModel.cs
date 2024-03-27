using System.ComponentModel.DataAnnotations;
using TrainingFPT.Validation;

namespace TrainingFPT.Models
{
    public class CategoryModel
    {
        public List<CategoryDetail>? CategoryDetailsList { get; set; }
    }

    public class CategoryDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Poster is required!")]
        [AlowExtensionFile(new string[] { ".png", ".jpg", ".jpeg" })]
        [AlowSizeFile(1024 * 1024 * 10)]
        public IFormFile? Poster { get; set; }

        public string? PosterName { get; set; }

        [Required(ErrorMessage = "ParentId is required!")]
        public int ParentId { get; set; }

        [Required(ErrorMessage = "Status is required!")]
        public string? Status { get; set; }

        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }

        public DateTime? Deleted_at { get; set; }

    }
}
