using Avansist.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.DAL
{
    public class AvansistDbContext : IdentityDbContext
    {
        public AvansistDbContext(DbContextOptions<AvansistDbContext> options) :
            base(options)
        {

        }

        public virtual DbSet<Agenda> Agendas { get; set; }
        public virtual DbSet<Preinscripcion> Preinscripcions  { get; set; }
        public virtual DbSet<ControlAsistencia> ControlAsistencias { get; set; }
        public virtual DbSet<DetalleSalida> DetalleSalidas { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Etnia> Etnias { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<GrupoSanguineo> GrupoSanguineos { get; set; }
        public virtual DbSet<Jornada> Jornadas { get; set; }
        public virtual DbSet<Modalidad> Modalidads { get; set; }
        public virtual DbSet<Padrino> Padrinos { get; set; }
        public virtual DbSet<SalidaExtracurricular> SalidaExtracurriculars { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<AgendaBeneficiario> AgendaBeneficiarios { get; set; }

        //IdentityUser
        public DbSet<UsuarioIdentity> UsuariosIdentity { get; set; }


        // Evitar borrado en cascada cuando se agrega una migracion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
