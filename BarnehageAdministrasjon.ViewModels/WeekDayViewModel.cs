using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.ViewModels
{
    public class WeekDayViewModel
    {
        [JsonProperty("weekId")]
        public int WeekId { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("applicationKindergartenCoverages")]
        public List<ApplicationKindergartenCoverageViewModel> ApplicationKindergartenCoverages { get; set; }
    }
}
