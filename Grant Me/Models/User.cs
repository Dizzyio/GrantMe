using Microsoft.AspNetCore.Identity;
using System;

namespace Grant_Me.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Citizenship { get; set; } = string.Empty;
        public decimal AnnualIncome { get; set; }
        public bool HasDisability { get; set; }
        public bool IsBusiness { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessStructure { get; set; }
        public decimal? BusinessRevenue { get; set; }
        public bool IsNonProfit { get; set; }
        public string? CharityNumber { get; set; }
    }
}
