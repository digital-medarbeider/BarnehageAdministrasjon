using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.ViewModels
{
    public class MunicipalityViewModel
    {
        [JsonProperty("municipalityId")]
        public int MunicipalityId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
