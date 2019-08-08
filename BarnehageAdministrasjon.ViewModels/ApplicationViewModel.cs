using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.ViewModels
{
    public class ApplicationViewModel
    {
        //applicationId: string;
        //childName: string;
        //childAddress: string;
        //fatherName: string;
        //motherName: string;

        [JsonProperty("applicationId")]
        public Guid Id { get; set; }

        [JsonProperty("childName")]
        public string ChildName { get; set; }

        [JsonProperty("childAddress")]
        public string ChildAddress { get; set; }

        [JsonProperty("fatherName")]
        public string FatherName { get; set; }

        [JsonProperty("motherName")]
        public string MotherName { get; set; }
    }
}
