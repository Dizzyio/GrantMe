using System;
using System.ComponentModel.DataAnnotations;

namespace Grant_Me.Models
{
    public class UserResponse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Citizenship { get; set; } = string.Empty;

        [Required]
        public decimal AnnualIncome { get; set; }

        public bool HasDisability { get; set; }

        public bool IsBusiness { get; set; }
        public bool IsNonProfit { get; set; }

        [RequiredIf(nameof(IsBusiness), true, ErrorMessage = "Business Structure is required if you are a business.")]
        public string? BusinessStructure { get; set; }


        [RequiredIf(nameof(IsBusiness), true, ErrorMessage = "Business Name is required if you are a business.")]
        public string? BusinessName { get; set; }

        [RequiredIf(nameof(IsBusiness), true, ErrorMessage = "Business Revenue is required if you are a business.")]
        public decimal? BusinessRevenue { get; set; }

        [RequiredIf(nameof(IsNonProfit), true, ErrorMessage = "Charity Number is required if you are a non-profit.")]
        public string? CharityNumber { get; set; }

        // ** NEW: Link to User Account (for saving info between logins) **
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }

    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _conditionProperty;
        private readonly object _expectedValue;

        public RequiredIfAttribute(string conditionProperty, object expectedValue)
        {
            _conditionProperty = conditionProperty;
            _expectedValue = expectedValue;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var conditionProperty = validationContext.ObjectType.GetProperty(_conditionProperty);
            if (conditionProperty == null)
                return new ValidationResult($"Unknown property: {_conditionProperty}");

            var conditionValue = conditionProperty.GetValue(validationContext.ObjectInstance);

            if (conditionValue?.Equals(_expectedValue) == true && value == null)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
