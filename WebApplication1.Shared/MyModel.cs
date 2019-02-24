using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication1.Shared
{
    public class MyModel : IValidatableObject
    {
        public MyModel()
        {
            Console.WriteLine("MyModel Constructor");
        }

        [Required(ErrorMessage = "My String 1 is required.")]
        public string MyString1 { get; set; } = "";

        [MaxLength(length: 10, ErrorMessage = "My String 2 must be 10 characters or less.")]
        public string MyString2 { get; set; } = "";

        [Required(ErrorMessage = "My Int 1 is required.")]
        [Range(minimum: 5, maximum: 10, ErrorMessage = "My Int 1 must be between 5 and 10.")]
        public int? MyInt1 { get; set; }

        public int? MyInt2 { get; set; }

        private bool ShouldValidateMyString1(ValidationContext validationContext)
        {
            return validationContext.MemberName == nameof(MyString1) || string.IsNullOrWhiteSpace(validationContext.MemberName);
        }

        private bool ShouldValidateMyString2(ValidationContext validationContext)
        {
            return validationContext.MemberName == nameof(MyString2) || string.IsNullOrWhiteSpace(validationContext.MemberName);
        }

        private bool ShouldValidateMyInt1(ValidationContext validationContext)
        {
            return validationContext.MemberName == nameof(MyInt1) || string.IsNullOrWhiteSpace(validationContext.MemberName);
        }

        private bool ShouldValidateMyInt2(ValidationContext validationContext)
        {
            return validationContext.MemberName == nameof(MyInt2) || string.IsNullOrWhiteSpace(validationContext.MemberName);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Console.WriteLine("MyModel.Validate");
            var attributeValidationResults = new List<ValidationResult>();

            if (ShouldValidateMyString1(validationContext))
            {
                Validator.TryValidateProperty(MyString1, validationContext, attributeValidationResults);
                if (attributeValidationResults.Any())
                {
                    foreach (var validationResult in attributeValidationResults)
                    {
                        yield return validationResult;
                    }
                }
            }

            if (ShouldValidateMyString2(validationContext))
            {
                if (MyString1.Length <= MyString2.Length)
                { 
                    yield return new ValidationResult("My String 2 must be shorter than My String 1.", new string[] { nameof(MyString2) });
                }
                Validator.TryValidateProperty(MyString2, validationContext, attributeValidationResults);
                if (attributeValidationResults.Any())
                {
                    foreach (var validationResult in attributeValidationResults)
                    {
                        yield return validationResult;
                    }
                }
            }

            if (ShouldValidateMyInt1(validationContext))
            {
                Validator.TryValidateProperty(MyInt1, validationContext, attributeValidationResults);
                if (attributeValidationResults.Any())
                {
                    foreach (var validationResult in attributeValidationResults)
                    {
                        yield return validationResult;
                    }
                }
            }

            if (ShouldValidateMyInt2(validationContext))
            {
                if (MyInt2 >= MyInt1)
                {
                    yield return new ValidationResult("My Int 2 must be smaller than My Int 1.", new string[] { nameof(MyInt2) });
                }
                Validator.TryValidateProperty(MyInt2, validationContext, attributeValidationResults);
                if (attributeValidationResults.Any())
                {
                    foreach (var validationResult in attributeValidationResults)
                    {
                        yield return validationResult;
                    }
                }
            }
        }
    }
}
