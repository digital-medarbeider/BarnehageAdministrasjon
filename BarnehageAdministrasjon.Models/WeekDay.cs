using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public class WeekDay
    {
        [Key]
        public int WeekId { get; set; }
        public string Keyword { get; set; }
        public string Day { get; set; }
        public List<ApplicationKindergartenCoverage> ApplicationKindergartenCoverages { get; set; }
    }
}
