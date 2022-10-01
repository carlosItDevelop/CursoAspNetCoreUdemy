
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Entities.Audit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Data.ORM
{
    public class ITDeveloperDbContext : DbContext
    {
        private readonly IHttpContextAccessor _accessor;

        public ITDeveloperDbContext(DbContextOptions<ITDeveloperDbContext> options, 
                                    IHttpContextAccessor accessor)
            : base(options)
        {
            _accessor = accessor;
        }

        public DbSet<Mural> Mural { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<EstadoPaciente> EstadoPaciente { get; set; }
        public DbSet<Generico> Generico { get; set; }
        public DbSet<Cid> Cid { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

        #region: SaveChanges
        public override int SaveChanges()
        {
            try
            {
                EditableCall();
                return base.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar gravar ChangeTracker com SaveChangesAsync");
            }
        }
        #endregion

        #region: SaveChangesAsync
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                EditableCall();
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar gravar ChangeTracker com SaveChangesAsync");
            }           
        }
        #endregion

        #region: EditableCall
        private void EditableCall()
        {
            var currentTime = DateTime.Now;
            var usuario = _accessor.HttpContext.User.Identity.IsAuthenticated ? _accessor.HttpContext.User.Identity.Name : "Anônimo";

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity != null &&
                    typeof(IAuditable).IsAssignableFrom(e.Entity.GetType())))
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property(nameof(IAuditableAdd.DataInclusao)) != null)
                    {
                        entry.Property(nameof(IAuditableAdd.DataInclusao)).CurrentValue = currentTime;
                    }
                    if (entry.Property(nameof(IAuditableAdd.UsuarioInclusao)) != null)
                    {
                        entry.Property(nameof(IAuditableAdd.UsuarioInclusao)).CurrentValue = usuario;
                    }
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(IAuditableAdd.DataInclusao)).IsModified = false;
                    entry.Property(nameof(IAuditableAdd.UsuarioInclusao)).IsModified = false;

                    if (entry.Property(nameof(IAuditableUpd.DataUltimaModificacao)) != null)
                    {
                        entry.Property(nameof(IAuditableUpd.DataUltimaModificacao)).CurrentValue = currentTime;
                    }
                    if (entry.Property(nameof(IAuditableUpd.UsuarioUltimaModificacao)) != null)
                    {
                        entry.Property(nameof(IAuditableUpd.UsuarioUltimaModificacao)).CurrentValue = usuario;
                    }
                }
            }

        }
        #endregion
    }
}
