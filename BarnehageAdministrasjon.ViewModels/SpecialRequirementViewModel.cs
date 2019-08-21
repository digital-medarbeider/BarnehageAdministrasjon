using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.ViewModels
{
    public class SpecialRequirementViewModel
    {
        [JsonProperty("specialRequirementId")]
        public int SpecialRequirementId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("applicationSpecRequirements")]
        public List<ApplicationSpecRequirementViewModel> ApplicationSpecRequirements { get; set; }
    }
}
