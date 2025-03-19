using System;
using System.ComponentModel.DataAnnotations;

namespace Grant_Me.Models
{
    public class RegisterModel
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Citizenship { get; set; } = string.Empty;

        [Required]
        public decimal AnnualIncome { get; set; }

        public bool HasDisability { get; set; } = false;

        public bool IsBusiness { get; set; } = false;
        public string? BusinessName { get; set; }
        public string? BusinessStructure { get; set; }
        public decimal? BusinessRevenue { get; set; }

        public bool IsNonProfit { get; set; } = false;
        public string? CharityNumber { get; set; }
    }
}
