using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public class Person
    {
        [Key]
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string FirstLanguage { get; set; }
        public string LevelOfSpoken { get; set; }
        //[InverseProperty("Child")]
        //public List<Application> ChildApplications { get; set; }
        //[InverseProperty("Father")]
        //public List<Application> FatherApplications { get; set; }
        //[InverseProperty("Mother")]
        //public List<Application> MotherApplications { get; set; }


    }
}
