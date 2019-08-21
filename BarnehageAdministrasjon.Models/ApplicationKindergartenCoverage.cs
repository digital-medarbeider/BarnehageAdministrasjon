using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public class ApplicationKindergartenCoverage
    {
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
        public string WeekType { get; set; }
        public int WeekId { get; set; }
        public WeekDay WeekDay { get; set; }
    }
}
