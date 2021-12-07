﻿// <auto-generated />
using System;
using Avansist.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Avansist.DAL.Migrations
{
    [DbContext(typeof(AvansistDbContext))]
    partial class AvansistDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Avansist.Models.Entities.Agenda", b =>
                {
                    b.Property<int>("AgendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmpleadoEncargado")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaFinEvento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicioEvento")
                        .HasColumnType("datetime2");

                    b.Property<string>("HoraFinEvento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraInicioEvento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEvento")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AgendaId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("Avansist.Models.Entities.AgendaBeneficiario", b =>
                {
                    b.Property<int>("AgendaBeneficiarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmpleadoEncargado")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaFinEvento")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaInicioEvento")
                        .HasColumnType("date");

                    b.Property<string>("NombreEvento")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PreinscripcionId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("AgendaBeneficiarioId");

                    b.HasIndex("PreinscripcionId");

                    b.ToTable("AgendaBeneficiarios");
                });

            modelBuilder.Entity("Avansist.Models.Entities.ControlAsistencia", b =>
                {
                    b.Property<int>("ControlAsistenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AutorizacionSalida")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<string>("ObservacionIngreso")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ObservacionSalida")
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PreinscripcionId")
                        .HasColumnType("int");

                    b.HasKey("ControlAsistenciaId");

                    b.HasIndex("PreinscripcionId");

                    b.ToTable("ControlAsistencias");
                });

            modelBuilder.Entity("Avansist.Models.Entities.DetalleSalida", b =>
                {
                    b.Property<int>("DetalleSalidaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AutorizacionSalidaExtracurricular")
                        .HasColumnType("bit");

                    b.Property<int>("PreinscripcionId")
                        .HasColumnType("int");

                    b.Property<int>("SalidaExtracurricularId")
                        .HasColumnType("int");

                    b.HasKey("DetalleSalidaId");

                    b.HasIndex("PreinscripcionId");

                    b.HasIndex("SalidaExtracurricularId");

                    b.ToTable("DetalleSalidas");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreEstado")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Etnia", b =>
                {
                    b.Property<int>("EtniaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreEtnia")
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("EtniaId");

                    b.ToTable("Etnias");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreGenero")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Avansist.Models.Entities.GrupoSanguineo", b =>
                {
                    b.Property<int>("GrupoSanguineoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rh")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("GrupoSanguineoId");

                    b.ToTable("GrupoSanguineos");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Jornada", b =>
                {
                    b.Property<int>("JornadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreJornada")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("JornadaId");

                    b.ToTable("Jornadas");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Modalidad", b =>
                {
                    b.Property<int>("ModalidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreModalidad")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ModalidadId");

                    b.ToTable("Modalidads");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Padrino", b =>
                {
                    b.Property<int>("PadrinoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoPadrino")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombrePadrino")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Ocupacion")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("PadrinoId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Padrinos");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Preinscripcion", b =>
                {
                    b.Property<int>("PreinscripcionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AntecedenteMedico")
                        .HasColumnType("bit");

                    b.Property<bool>("AntecedentePsicologico")
                        .HasColumnType("bit");

                    b.Property<string>("ApellidoAcudiente")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ApellidoMadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ApellidoPadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("AporteEconomicoPadrino")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("AutorizacionData")
                        .HasColumnType("bit");

                    b.Property<bool>("AutorizacionFoto")
                        .HasColumnType("bit");

                    b.Property<string>("BarrioAcudiente")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BarrioMadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BarrioPadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustodiaBeneficiario")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("DescripcionEnfermedad")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DescripcionPsicologica")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DireccionAcudiente")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DireccionMadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DireccionPadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DireccionResidencia")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Edad")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int>("EtniaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaMatricula")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaRetiro")
                        .HasColumnType("date");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoSanguineoId")
                        .HasColumnType("int");

                    b.Property<string>("GrupoSisben")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("IngresoEconomicoAcudiente")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IngresoEconomicoMadre")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IngresoEconomicoPadre")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("InstitucionEducativa")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("JornadaId")
                        .HasColumnType("int");

                    b.Property<string>("LugarExpedicionDocumento")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LugarExpedicionDocumentoAcudiente")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LugarExpedicionDocumentoMadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LugarExpedicionDocumentoPadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LugarNacimiento")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ModalidadId")
                        .HasColumnType("int");

                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MunicipioAcudiente")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MunicipioMadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MunicipioPadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NivelEscolaridad")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NivelEscolaridadAcudiente")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NivelEscolaridadMadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NivelEscolaridadPadre")
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("NombreAcudiente")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreEps")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreImagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombrePadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NumeroDocumentoAcudiente")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NumeroDocumentoMadre")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NumeroDocumentoPadre")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ObservacionRetiro")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("OcupacionAcudiente")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("OcupacionMadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OcupacionPadre")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PadrinoId")
                        .HasColumnType("int");

                    b.Property<int?>("PreinscripcionsPreinscripcionId")
                        .HasColumnType("int");

                    b.Property<string>("PrimerApellidoBeneficiario")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PrimerNombreBeneficiario")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SegundoApellidoBeneficiario")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SegundoNombreBeneficiario")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TallaCamisa")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TallaPantalon")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TallaZapatos")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TelefonoAcudiente")
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("TelefonoMadre")
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("TelefonoPadre")
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("PreinscripcionId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("EtniaId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("GrupoSanguineoId");

                    b.HasIndex("JornadaId");

                    b.HasIndex("ModalidadId");

                    b.HasIndex("PadrinoId");

                    b.HasIndex("PreinscripcionsPreinscripcionId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Preinscripcions");
                });

            modelBuilder.Entity("Avansist.Models.Entities.SalidaExtracurricular", b =>
                {
                    b.Property<int>("SalidaExtracurricularId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DocumentoResponsable")
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("EstadoEvento")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegresoEvento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalidadEvento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreSalidadEvento")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PreinscripcionId")
                        .HasColumnType("int");

                    b.Property<string>("ResponsableEvento")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SalidaExtracurricularId");

                    b.HasIndex("PreinscripcionId");

                    b.ToTable("SalidaExtracurriculars");
                });

            modelBuilder.Entity("Avansist.Models.Entities.TipoDocumento", b =>
                {
                    b.Property<int>("TipoDocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreTipoDocumento")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TipoDocumentoId");

                    b.ToTable("TipoDocumentos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Avansist.Models.Entities.UsuarioIdentity", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("CambiarEstado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("UsuarioIdentity");
                });

            modelBuilder.Entity("Avansist.Models.Entities.AgendaBeneficiario", b =>
                {
                    b.HasOne("Avansist.Models.Entities.Preinscripcion", "Preinscripcion")
                        .WithMany("AgendaBeneficiarios")
                        .HasForeignKey("PreinscripcionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Preinscripcion");
                });

            modelBuilder.Entity("Avansist.Models.Entities.ControlAsistencia", b =>
                {
                    b.HasOne("Avansist.Models.Entities.Preinscripcion", "Preinscripcion")
                        .WithMany("ControlAsistencias")
                        .HasForeignKey("PreinscripcionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Preinscripcion");
                });

            modelBuilder.Entity("Avansist.Models.Entities.DetalleSalida", b =>
                {
                    b.HasOne("Avansist.Models.Entities.Preinscripcion", "Preinscripcions")
                        .WithMany("DetalleSalidas")
                        .HasForeignKey("PreinscripcionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Avansist.Models.Entities.SalidaExtracurricular", "SalidaExtracurricular")
                        .WithMany("DetalleSalidas")
                        .HasForeignKey("SalidaExtracurricularId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Preinscripcions");

                    b.Navigation("SalidaExtracurricular");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Padrino", b =>
                {
                    b.HasOne("Avansist.Models.Entities.TipoDocumento", "TipoDocumento")
                        .WithMany("Padrino")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Preinscripcion", b =>
                {
                    b.HasOne("Avansist.Models.Entities.Estado", "Estado")
                        .WithMany("Preinscripcions")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Avansist.Models.Entities.Etnia", "Etnia")
                        .WithMany("Preinscripcions")
                        .HasForeignKey("EtniaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Avansist.Models.Entities.Genero", "Genero")
                        .WithMany("Preinscripcions")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Avansist.Models.Entities.GrupoSanguineo", "GrupoSanguineo")
                        .WithMany("Preinscripcions")
                        .HasForeignKey("GrupoSanguineoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Avansist.Models.Entities.Jornada", "Jornada")
                        .WithMany("Preinscripcions")
                        .HasForeignKey("JornadaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Avansist.Models.Entities.Modalidad", "Modalidad")
                        .WithMany("Preinscripcions")
                        .HasForeignKey("ModalidadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Avansist.Models.Entities.Padrino", "Padrino")
                        .WithMany("Preinscripcions")
                        .HasForeignKey("PadrinoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Avansist.Models.Entities.Preinscripcion", "Preinscripcions")
                        .WithMany()
                        .HasForeignKey("PreinscripcionsPreinscripcionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Avansist.Models.Entities.TipoDocumento", "TipoDocumento")
                        .WithMany("Preinscripcions")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Etnia");

                    b.Navigation("Genero");

                    b.Navigation("GrupoSanguineo");

                    b.Navigation("Jornada");

                    b.Navigation("Modalidad");

                    b.Navigation("Padrino");

                    b.Navigation("Preinscripcions");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("Avansist.Models.Entities.SalidaExtracurricular", b =>
                {
                    b.HasOne("Avansist.Models.Entities.Preinscripcion", "Preinscripcion")
                        .WithMany("SalidaExtracurricular")
                        .HasForeignKey("PreinscripcionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Preinscripcion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Avansist.Models.Entities.Estado", b =>
                {
                    b.Navigation("Preinscripcions");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Etnia", b =>
                {
                    b.Navigation("Preinscripcions");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Genero", b =>
                {
                    b.Navigation("Preinscripcions");
                });

            modelBuilder.Entity("Avansist.Models.Entities.GrupoSanguineo", b =>
                {
                    b.Navigation("Preinscripcions");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Jornada", b =>
                {
                    b.Navigation("Preinscripcions");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Modalidad", b =>
                {
                    b.Navigation("Preinscripcions");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Padrino", b =>
                {
                    b.Navigation("Preinscripcions");
                });

            modelBuilder.Entity("Avansist.Models.Entities.Preinscripcion", b =>
                {
                    b.Navigation("AgendaBeneficiarios");

                    b.Navigation("ControlAsistencias");

                    b.Navigation("DetalleSalidas");

                    b.Navigation("SalidaExtracurricular");
                });

            modelBuilder.Entity("Avansist.Models.Entities.SalidaExtracurricular", b =>
                {
                    b.Navigation("DetalleSalidas");
                });

            modelBuilder.Entity("Avansist.Models.Entities.TipoDocumento", b =>
                {
                    b.Navigation("Padrino");

                    b.Navigation("Preinscripcions");
                });
#pragma warning restore 612, 618
        }
    }
}
