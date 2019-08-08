using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnehageAdministrasjon.Models
{
    public class KindergartenContext: DbContext
    {
        public KindergartenContext(DbContextOptions<KindergartenContext> options): base(options)
        {
        }

        DbSet<Application> Applications { get; set; }
    }
}
