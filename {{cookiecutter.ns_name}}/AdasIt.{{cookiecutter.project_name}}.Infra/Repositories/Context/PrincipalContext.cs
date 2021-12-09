using AdasIt.__cookiecutter.project_name__.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AdasIt.__cookiecutter.project_name__.Infra.Repositories.Context
{
    public class PrincipalContext : DbContext
    {
        public PrincipalContext(DbContextOptions<PrincipalContext> options) : base(options)
        {

        }

        public DbSet<Configurations> Configurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Configurations>((v) => {
                    v.HasKey(k => k.Id);
                    v.Property(k => k.Name);
                    v.Property(k => k.Value);
                    v.Property(k => k.Description);
                });
        }
    }
}
