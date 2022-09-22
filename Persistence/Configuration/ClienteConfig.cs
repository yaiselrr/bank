using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration // POR CADA ENTIDAD SE CREA UNA CLASE CONFIG
{
    // VA A MAPEAR TODAS LAS CARACTERISTICAS DE  NUESTRA TABLA EN BASE DE DATOS
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // VAMOS A PONER TODOS LOS CAMPOS DE LA TABLA
            builder.ToTable("Cliente");

            builder.HasKey(p => p.Id); // CLAVE PRIMARIA CAMPO ID

            builder.Property(p => p.Nombre) //CAMPO NOMBRE
                   .HasMaxLength(80) // TIENE UN MAXIMO DE 80 CARACTERES
                   .IsRequired(); // ES REQUERIDO
            
            builder.Property(p => p.Apellido) //CAMPO APELLIDO
                   .HasMaxLength(80) // TIENE UN MAXIMO DE 80 CARACTERES
                   .IsRequired(); // ES REQUERIDO

            builder.Property(p => p.FechaNacimiento) //CAMPO FECHA NACIMIENTO
                   .IsRequired(); // ES REQUERIDO

            builder.Property(p => p.Telefono) //CAMPO TELEFONO
                   .HasMaxLength(9) // TIENE UN MAXIMO DE 9 CARACTERES
                   .IsRequired(); // ES REQUERIDO

            builder.Property(p => p.Email) //CAMPO EMAIL
                   .HasMaxLength(100); // TIENE UN MAXIMO DE 100 CARACTERES

            builder.Property(p => p.Direccion) //CAMPO DIRECCION
                   .HasMaxLength(120) // TIENE UN MAXIMO DE 120 CARACTERES
                   .IsRequired(); // ES REQUERIDO

            builder.Property(p => p.Edad); //CAMPO EDAD

            builder.Property(p => p.CreatedBy) //CAMPO CreatedBy
                   .HasMaxLength(30); // TIENE UN MAXIMO DE 30 CARACTERES

            builder.Property(p => p.LastModifiedBy) //CAMPO LastModifiedBy
                   .HasMaxLength(30); // TIENE UN MAXIMO DE 30 CARACTERES


        }
    }
}
