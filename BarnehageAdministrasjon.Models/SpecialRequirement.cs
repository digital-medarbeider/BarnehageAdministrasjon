using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public class SpecialRequirement
    {
        [Key]
        public int SpecialRequirementId { get; set; }
        public string Name { get; set; }
        public List<ApplicationSpecRequirement> ApplicationSpecRequirements { get; set; }
    }
}
