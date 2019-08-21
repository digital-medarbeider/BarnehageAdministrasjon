using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.ViewModels
{
    public class ApplicationKindergartenCoverageViewModel
    {
        [JsonProperty("applicationId")]
        public Guid ApplicationId { get; set; }

        //[JsonProperty("application")]
        //public ApplicationViewModel Application { get; set; }

        [JsonProperty("weekType")]
        public string WeekType { get; set; }

        [JsonProperty("weekId")]
        public int WeekId { get; set; }

        [JsonProperty("weekDay")]
        public WeekDayViewModel WeekDay { get; set; }
    }
}
