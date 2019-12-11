
using System;
using Cooperchip.ITDeveloper.Data.Mapping;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cooperchip.ITDeveloper.Data.ORM
{
    public class ITDeveloperDbContext : DbContext
    {
        public ITDeveloperDbContext(DbContextOptions<ITDeveloperDbContext> options)
            :base(options)
        {}

        public DbSet<Mural> Mural { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<EstadoPaciente> EstadoPaciente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // onde não tiver setado varchar e a propriedade for do tipo string fica valendo varchar(valor)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                //property.Relational().ColumnType = "varchar(100)";
                property.SetColumnType("varchar(90)");
            }



            //modelBuilder.ApplyConfiguration(new EstadoPacienteMap());
            //modelBuilder.ApplyConfiguration(new PacienteMap());

            // Impl033: Busca os Mapppings de uma vez só
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ITDeveloperDbContext).Assembly);

            //remover delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);

        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCadastro").IsModified = false;
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}


    }
}
