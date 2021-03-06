using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PZBuild.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBuild.Common.Data
{
    public class PZBuildContext : DbContext
    {
        protected PZBuildContext()
        {
        }

        public PZBuildContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType? entityType in modelBuilder.Model.GetEntityTypes())
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);

            modelBuilder.Entity<Occupation>()
                .HasOne(p => p.ExclusiveTrait)
                .WithMany(b => b.Occupations);

            modelBuilder.Entity<Occupation>()
                .HasMany(p => p.OccupationSkills)
                .WithOne(b => b.Occupation);
        }

        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<OccupationSkill> OccupationSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Trait> Traits { get; set; }
    }
}
