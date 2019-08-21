using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.ViewModels
{
    public class ApplicationSpecRequirementViewModel
    {
        [JsonProperty("applicationId")]
        public Guid ApplicationId { get; set; }

        //[JsonProperty("application")]
        //public ApplicationViewModel Application { get; set; }

        [JsonProperty("specialRequirementId")]
        public int SpecialRequirementId { get; set; }

        [JsonProperty("specialRequirement")]
        public SpecialRequirementViewModel SpecialRequirement { get; set; }
    }
}
