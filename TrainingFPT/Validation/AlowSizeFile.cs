using System.ComponentModel.DataAnnotations;

namespace TrainingFPT.Validation
{
    public class AlowSizeFile : ValidationAttribute
    {
        private readonly int _size;

        public AlowSizeFile(int size)
        {
            _size = size;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _size)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"This file size is not allowed!";
        }
    }
}
