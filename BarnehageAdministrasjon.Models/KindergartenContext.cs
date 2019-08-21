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

        public DbSet<Application> Applications { get; set; }
        public DbSet<SpecialRequirement> SpecialRequirements { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationSpecRequirement>()
            .HasKey(pt => new { pt.ApplicationId, pt.SpecialRequirementId });

            modelBuilder.Entity<ApplicationSpecRequirement>()
           .HasOne(pt => pt.Application)
           .WithMany(p => p.ApplicationSpecRequirements)
           .HasForeignKey(pt => pt.ApplicationId);

            modelBuilder.Entity<ApplicationSpecRequirement>()
           .HasOne(pt => pt.SpecialRequirement)
           .WithMany(t => t.ApplicationSpecRequirements)
           .HasForeignKey(pt => pt.SpecialRequirementId);

            modelBuilder.Entity<ApplicationKindergartenCoverage>()
          .HasKey(pt => new { pt.ApplicationId, pt.WeekId });

            modelBuilder.Entity<ApplicationKindergartenCoverage>()
           .HasOne(pt => pt.Application)
           .WithMany(p => p.ApplicationKindergartenCoverages)
           .HasForeignKey(pt => pt.ApplicationId);

            modelBuilder.Entity<ApplicationKindergartenCoverage>()
           .HasOne(pt => pt.WeekDay)
           .WithMany(t => t.ApplicationKindergartenCoverages)
           .HasForeignKey(pt => pt.WeekId);

            modelBuilder.Seed();

        }
    }
}
