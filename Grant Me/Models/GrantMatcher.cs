using System;
using System.Collections.Generic;
using System.Linq;
using Grant_Me.Data;
using Grant_Me.Models;

namespace Grant_Me.Services
{
    public class GrantMatcher
    {
        private readonly GrantDbContext _context;

        public GrantMatcher(GrantDbContext context)
        {
            _context = context;
        }

        public (List<Grant> eligibleGrants, List<(Grant grant, string reason)> nearMissGrants) MatchUserToGrants(UserResponse userResponse)
        {
            var eligibleGrants = new List<Grant>();
            var nearMissGrants = new List<(Grant, string)>();

            foreach (var grant in _context.Grants.ToList())
            {
                var eligibilityCriteria = grant.EligibilityCriteria.ToLower();
                bool eligible = true;
                List<string> nearMissReasons = new List<string>();

                // Personal Eligibility
                if (eligibilityCriteria.Contains("income") && userResponse.AnnualIncome > 50000)
                {
                    eligible = false;
                    nearMissReasons.Add("Your income exceeds the grant’s maximum threshold.");
                }
                if (eligibilityCriteria.Contains("disability") && !userResponse.HasDisability)
                {
                    eligible = false;
                    nearMissReasons.Add("This grant is for individuals receiving disability benefits.");
                }

                // Business Eligibility
                if (eligibilityCriteria.Contains("business") && string.IsNullOrEmpty(userResponse.BusinessName))
                {
                    eligible = false;
                    nearMissReasons.Add("This grant is for registered businesses.");
                }
                if (eligibilityCriteria.Contains("revenue") && userResponse.BusinessRevenue > 5000000)
                {
                    eligible = false;
                    nearMissReasons.Add("Your business revenue exceeds the grant limit.");
                }

                // Non-Profit Eligibility
                if (eligibilityCriteria.Contains("non-profit") && !userResponse.IsNonProfit)
                {
                    eligible = false;
                    nearMissReasons.Add("This grant is for registered non-profits or charities.");
                }

                // Categorizing the grant
                if (eligible)
                {
                    eligibleGrants.Add(grant);
                }
                else if (nearMissReasons.Count > 0)
                {
                    nearMissGrants.Add((grant, string.Join(" ", nearMissReasons)));
                }
            }

            return (eligibleGrants, nearMissGrants);
        }
    }
}
