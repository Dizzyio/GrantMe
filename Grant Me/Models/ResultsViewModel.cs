using Grant_Me.Models;
using System.Collections.Generic;

namespace Grant_Me.Models
{
    public class ResultsViewModel
    {
        public List<Grant> EligibleGrants { get; set; } = new List<Grant>();
        public List<NearMissGrant> NearMissGrants { get; set; } = new List<NearMissGrant>();
    }

    public class NearMissGrant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string NearMissReason { get; set; }
    }
}
