using BarnehageAdministrasjon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.ViewModels
{
    public class ApplicationViewModel
    {
        [JsonProperty("applicationId")]
        public Guid ApplicationId { get; set; }

        [JsonProperty("childId")]
        public string ChildId { get; set; }

        [JsonProperty("child")]
        public PersonViewModel Child { get; set; }

        [JsonProperty("fatherId")]
        public string FatherId { get; set; }

        [JsonProperty("father")]
        public PersonViewModel Father { get; set; }

        [JsonProperty("motherId")]
        public string MotherId { get; set; }

        [JsonProperty("mother")]
        public PersonViewModel Mother { get; set; }

        [JsonProperty("municipalityId")]
        public int MunicipalityId { get; set; }

        [JsonProperty("childName")]
        public string ChildName { get; set; }

        [JsonProperty("childAddress")]
        public string ChildAddress { get; set; }

        [JsonProperty("fatherName")]
        public string FatherName { get; set; }

        [JsonProperty("motherName")]
        public string MotherName { get; set; }

        [JsonProperty("firstLanguage")]
        public string FirstLanguage { get; set; }

        [JsonProperty("levelOfSpoken")]
        public string LevelOfSpoken { get; set; }

        [JsonProperty("applicationStartDate")]
        public DateTime ApplicationStartDate { get; set; }

        [JsonProperty("isReducedFee")]
        public bool IsReducedFee { get; set; }

        [JsonProperty("isChooseDiffDays")]
        public bool IsChooseDiffDays { get; set; }

        [JsonProperty("applicationSubmitDate")]
        public DateTime ApplicationSubmitDate { get; set; }

        [JsonProperty("kindergartenCoverage")]
        public int KindergartenCoverage { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("municipality")]
        public MunicipalityViewModel Municipality { get; set; }

        [JsonProperty("applicationSpecRequirements")]
        public List<ApplicationSpecRequirementViewModel> ApplicationSpecRequirements { get; set; }

        [JsonProperty("applicationKindergartenCoverages")]
        public List<ApplicationKindergartenCoverageViewModel> ApplicationKindergartenCoverages { get; set; }
    }
}
