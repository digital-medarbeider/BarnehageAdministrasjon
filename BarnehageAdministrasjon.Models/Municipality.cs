using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public class Municipality
    {
        [Key]
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
    }
}
