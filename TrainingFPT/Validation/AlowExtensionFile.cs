using System.ComponentModel.DataAnnotations;

namespace TrainingFPT.Validation
{
    public class AlowExtensionFile : ValidationAttribute
    {
        private readonly string[] _extension;

        public AlowExtensionFile(string[] extension)
        {
            _extension = extension;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!_extension.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }

            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"This file extension is not allowed!";
        }
    }
}
