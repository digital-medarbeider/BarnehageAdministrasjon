using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public class Application
    {
        public Guid ApplicationId { get; set; }
        public string ChildId { get; set; }
        public Person Child { get; set; }
        public string FatherId { get; set; }
        public Person Father { get; set; }
        public string MotherId { get; set; }
        public Person Mother { get; set; }
        public int MunicipalityId { get; set; }
        public string ChildName { get; set; }
        public string ChildAddress { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FirstLanguage { get; set; }
        public string LevelOfSpoken { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public bool IsReducedFee { get; set; }
        public bool IsChooseDiffDays { get; set; }
        public DateTime ApplicationSubmitDate { get; set; }
        public int KindergartenCoverage { get; set; }
        public string Status { get; set; }
        public virtual Municipality Municipality { get; set; }
        public List<ApplicationSpecRequirement> ApplicationSpecRequirements { get; set; }
        public List<ApplicationKindergartenCoverage> ApplicationKindergartenCoverages { get; set; }
    }
}