
 using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace InternKYCApplication.Helpers
{
    public class MyCustomValidation : ValidationAttribute
    {
        public class ImageValidation : ValidationAttribute
        {
            private readonly string field_Name;

            public ImageValidation(string fieldName)
            {
                field_Name = fieldName;
            }

            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string input = value.ToString();
                    if (!IsBase64StringValidJpeg(input))
                    {
                        return new ValidationResult($"{field_Name} is not a valid JPEG image in Base64 format.");
                    }
                }
                return ValidationResult.Success;
            }

            // Method to validate image format
            private bool IsBase64StringValidJpeg(string input)
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(input);

                    // Check if the decoded bytes start with the JPEG file signature (FF D8)
                    return true;
                }
                catch (FormatException)
                {
                    // Invalid Base64 string
                    return false;
                }

            }
        }
    }
}
