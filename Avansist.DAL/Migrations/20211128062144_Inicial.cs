using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avansist.DAL.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    AgendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmpleadoEncargado = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HoraInicioEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraFinEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicioEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinEvento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.AgendaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CambiarEstado = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Etnias",
                columns: table => new
                {
                    EtniaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEtnia = table.Column<string>(type: "nvarchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etnias", x => x.EtniaId);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGenero = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "GrupoSanguineos",
                columns: table => new
                {
                    GrupoSanguineoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rh = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoSanguineos", x => x.GrupoSanguineoId);
                });

            migrationBuilder.CreateTable(
                name: "Jornadas",
                columns: table => new
                {
                    JornadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreJornada = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornadas", x => x.JornadaId);
                });

            migrationBuilder.CreateTable(
                name: "Modalidads",
                columns: table => new
                {
                    ModalidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreModalidad = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidads", x => x.ModalidadId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoDocumento = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "SalidaExtracurriculars",
                columns: table => new
                {
                    SalidaExtracurricularId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgendaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaExtracurriculars", x => x.SalidaExtracurricularId);
                    table.ForeignKey(
                        name: "FK_SalidaExtracurriculars_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "AgendaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Padrinos",
                columns: table => new
                {
                    PadrinoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePadrino = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ApellidoPadrino = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Ocupacion = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padrinos", x => x.PadrinoId);
                    table.ForeignKey(
                        name: "FK_Padrinos_TipoDocumentos_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumentos",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preinscripcions",
                columns: table => new
                {
                    PreinscripcionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombreBeneficiario = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SegundoNombreBeneficiario = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PrimerApellidoBeneficiario = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SegundoApellidoBeneficiario = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Edad = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LugarExpedicionDocumento = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DireccionResidencia = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    GrupoSanguineoId = table.Column<int>(type: "int", nullable: false),
                    NombreEps = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    GrupoSisben = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AntecedenteMedico = table.Column<bool>(type: "bit", nullable: false),
                    DescripcionEnfermedad = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    AntecedentePsicologico = table.Column<bool>(type: "bit", nullable: false),
                    DescripcionPsicologica = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    InstitucionEducativa = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NivelEscolaridad = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    JornadaId = table.Column<int>(type: "int", nullable: false),
                    FechaMatricula = table.Column<DateTime>(type: "date", nullable: false),
                    FechaRetiro = table.Column<DateTime>(type: "date", nullable: false),
                    ObservacionRetiro = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    TallaCamisa = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TallaPantalon = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TallaZapatos = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ModalidadId = table.Column<int>(type: "int", nullable: false),
                    EtniaId = table.Column<int>(type: "int", nullable: false),
                    CustodiaBeneficiario = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    PadrinoId = table.Column<int>(type: "int", nullable: false),
                    AporteEconomicoPadrino = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ApellidoMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NumeroDocumentoMadre = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LugarExpedicionDocumentoMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    OcupacionMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NivelEscolaridadMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TelefonoMadre = table.Column<string>(type: "nvarchar(45)", nullable: true),
                    DireccionMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BarrioMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MunicipioMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IngresoEconomicoMadre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombrePadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ApellidoPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NumeroDocumentoPadre = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LugarExpedicionDocumentoPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    OcupacionPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NivelEscolaridadPadre = table.Column<string>(type: "nvarchar(45)", nullable: true),
                    TelefonoPadre = table.Column<string>(type: "nvarchar(45)", nullable: true),
                    DireccionPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BarrioPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MunicipioPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IngresoEconomicoPadre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ApellidoAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NumeroDocumentoAcudiente = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LugarExpedicionDocumentoAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    OcupacionAcudiente = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    NivelEscolaridadAcudiente = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    TelefonoAcudiente = table.Column<string>(type: "nvarchar(45)", nullable: true),
                    DireccionAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BarrioAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MunicipioAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IngresoEconomicoAcudiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "date", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    AutorizacionFoto = table.Column<bool>(type: "bit", nullable: false),
                    AutorizacionData = table.Column<bool>(type: "bit", nullable: false),
                    NombreImagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preinscripcions", x => x.PreinscripcionId);
                    table.ForeignKey(
                        name: "FK_Preinscripcions_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preinscripcions_Etnias_EtniaId",
                        column: x => x.EtniaId,
                        principalTable: "Etnias",
                        principalColumn: "EtniaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preinscripcions_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preinscripcions_GrupoSanguineos_GrupoSanguineoId",
                        column: x => x.GrupoSanguineoId,
                        principalTable: "GrupoSanguineos",
                        principalColumn: "GrupoSanguineoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preinscripcions_Jornadas_JornadaId",
                        column: x => x.JornadaId,
                        principalTable: "Jornadas",
                        principalColumn: "JornadaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preinscripcions_Modalidads_ModalidadId",
                        column: x => x.ModalidadId,
                        principalTable: "Modalidads",
                        principalColumn: "ModalidadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preinscripcions_Padrinos_PadrinoId",
                        column: x => x.PadrinoId,
                        principalTable: "Padrinos",
                        principalColumn: "PadrinoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preinscripcions_TipoDocumentos_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumentos",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgendaBeneficiarios",
                columns: table => new
                {
                    AgendaBeneficiarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PreinscripcionId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoEncargado = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FechaInicioEvento = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFinEvento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaBeneficiarios", x => x.AgendaBeneficiarioId);
                    table.ForeignKey(
                        name: "FK_AgendaBeneficiarios_Preinscripcions_PreinscripcionId",
                        column: x => x.PreinscripcionId,
                        principalTable: "Preinscripcions",
                        principalColumn: "PreinscripcionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ControlAsistencias",
                columns: table => new
                {
                    ControlAsistenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreinscripcionId = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObservacionIngreso = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorizacionSalida = table.Column<bool>(type: "bit", nullable: false),
                    ObservacionSalida = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAsistencias", x => x.ControlAsistenciaId);
                    table.ForeignKey(
                        name: "FK_ControlAsistencias_Preinscripcions_PreinscripcionId",
                        column: x => x.PreinscripcionId,
                        principalTable: "Preinscripcions",
                        principalColumn: "PreinscripcionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleSalidas",
                columns: table => new
                {
                    DetalleSalidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaExtracurricularId = table.Column<int>(type: "int", nullable: false),
                    PreinscripcionId = table.Column<int>(type: "int", nullable: false),
                    AutorizacionSalidaExtracurricular = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleSalidas", x => x.DetalleSalidaId);
                    table.ForeignKey(
                        name: "FK_DetalleSalidas_Preinscripcions_PreinscripcionId",
                        column: x => x.PreinscripcionId,
                        principalTable: "Preinscripcions",
                        principalColumn: "PreinscripcionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleSalidas_SalidaExtracurriculars_SalidaExtracurricularId",
                        column: x => x.SalidaExtracurricularId,
                        principalTable: "SalidaExtracurriculars",
                        principalColumn: "SalidaExtracurricularId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaBeneficiarios_PreinscripcionId",
                table: "AgendaBeneficiarios",
                column: "PreinscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ControlAsistencias_PreinscripcionId",
                table: "ControlAsistencias",
                column: "PreinscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSalidas_PreinscripcionId",
                table: "DetalleSalidas",
                column: "PreinscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSalidas_SalidaExtracurricularId",
                table: "DetalleSalidas",
                column: "SalidaExtracurricularId");

            migrationBuilder.CreateIndex(
                name: "IX_Padrinos_TipoDocumentoId",
                table: "Padrinos",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Preinscripcions_EstadoId",
                table: "Preinscripcions",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Preinscripcions_EtniaId",
                table: "Preinscripcions",
                column: "EtniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Preinscripcions_GeneroId",
                table: "Preinscripcions",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Preinscripcions_GrupoSanguineoId",
                table: "Preinscripcions",
                column: "GrupoSanguineoId");

            migrationBuilder.CreateIndex(
                name: "IX_Preinscripcions_JornadaId",
                table: "Preinscripcions",
                column: "JornadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Preinscripcions_ModalidadId",
                table: "Preinscripcions",
                column: "ModalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Preinscripcions_PadrinoId",
                table: "Preinscripcions",
                column: "PadrinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Preinscripcions_TipoDocumentoId",
                table: "Preinscripcions",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaExtracurriculars_AgendaId",
                table: "SalidaExtracurriculars",
                column: "AgendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaBeneficiarios");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ControlAsistencias");

            migrationBuilder.DropTable(
                name: "DetalleSalidas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Preinscripcions");

            migrationBuilder.DropTable(
                name: "SalidaExtracurriculars");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Etnias");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "GrupoSanguineos");

            migrationBuilder.DropTable(
                name: "Jornadas");

            migrationBuilder.DropTable(
                name: "Modalidads");

            migrationBuilder.DropTable(
                name: "Padrinos");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");
        }
    }
}
