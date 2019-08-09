using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public class Application: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string ChildName { get; set; }
        public string ChildAddress{ get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string HomeLanguage  { get; set; }
        public string LevelOfSpoken { get; set; }

    }
}
