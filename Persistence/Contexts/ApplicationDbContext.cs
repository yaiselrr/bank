using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTimeService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTimeService) : base(options)
        {
            // SE HACE UN ChangeTracker POR BUENA PRACTICA
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // Controla todo a traves de entity framework

            _dateTimeService = dateTimeService;

        }
        public DbSet<Cliente> Clientes { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationTaken = new CancellationToken())
        // VAMOS A SOBREESCRIBIR EL METODO SaveChangesAsync QUE GUARDA TODO LOS CAMBIOS A NIVEL
        // DE BASE DE DATOS Y HACER UN COMMIT LUEGO QUE HACEMOS NUESTRAS TRANSACCIONES COMO
        // INSERT, DELETE, UPDATE Y TODO LO DEMAS
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTimeService.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTimeService.NowUtc;
                        break;
                }

            }
            // RETORNAMOS POR DEFECTO EL METODO SaveChangesAsync
            return base.SaveChangesAsync(cancellationTaken);

        }

        // SOBREESCRIBIMOS EL METODO PARA LAS MIGRACIONES QUE ES EL OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // TODO ESTO ESTA EN LA CARPETA INFRAESTRUCTURE/PERSISTENCE/CONFIGURATION
            modelbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
