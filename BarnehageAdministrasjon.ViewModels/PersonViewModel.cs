using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BarnehageAdministrasjon.ViewModels
{
    public class PersonViewModel
    {
        [JsonProperty("nationalId")]
        public string NationalId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("maritalStatus")]
        public string MaritalStatus { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public int PhoneNumber { get; set; }

        [JsonProperty("firstLanguage")]
        public string FirstLanguage { get; set; }

        [JsonProperty("levelOfSpoken")]
        public string LevelOfSpoken { get; set; }

        //[JsonProperty("childApplications")]
        //public List<ApplicationViewModel> ChildApplications { get; set; }

        //[JsonProperty("fatherApplications")]
        //public List<ApplicationViewModel> FatherApplications { get; set; }

        //[JsonProperty("motherApplications")]
        //public List<ApplicationViewModel> MotherApplications { get; set; }
    }
}
