using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public class ApplicationSpecRequirement
    {
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
        public int SpecialRequirementId { get; set; }
        public SpecialRequirement SpecialRequirement { get; set; }
    }
}
