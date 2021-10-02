﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avansist.DAL.Migrations
{
    public partial class Tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    AgendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmpleadoEncargado = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FechaInicioEvento = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFinEvento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.AgendaId);
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
                    PrimerNombreBeneficiario = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    SegundoNombreBeneficiario = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    PrimerApellidoBeneficiario = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    SegundoApellidoBeneficiario = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Edad = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", nullable: true),
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
                    NivelEscolaridad = table.Column<string>(type: "nvarchar(20)", nullable: true),
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
                    NumeroDocumentoMadre = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    LugarExpedicionDocumentoMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    OcupacionMadre = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    NivelEscolaridadMadre = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    TelefonoMadre = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    DireccionMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BarrioMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MunicipioMadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IngresoEconomicoMadre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombrePadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ApellidoPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NumeroDocumentoPadre = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    LugarExpedicionDocumentoPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    OcupacionPadre = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    NivelEscolaridadPadre = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    TelefonoPadre = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    DireccionPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BarrioPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MunicipioPadre = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IngresoEconomicoPadre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ApellidoAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NumeroDocumentoAcudiente = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    LugarExpedicionDocumentoAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    OcupacionAcudiente = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    NivelEscolaridadAcudiente = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    TelefonoAcudiente = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    DireccionAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BarrioAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MunicipioAcudiente = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IngresoEconomicoAcudiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "date", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
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
                name: "AgendaBeneficiario",
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
                    table.PrimaryKey("PK_AgendaBeneficiario", x => x.AgendaBeneficiarioId);
                    table.ForeignKey(
                        name: "FK_AgendaBeneficiario_Preinscripcions_PreinscripcionId",
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
                    FechaIngreso = table.Column<DateTime>(type: "date", nullable: false),
                    ObservacionIngreso = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    FechaSalida = table.Column<DateTime>(type: "date", nullable: false),
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
                name: "IX_AgendaBeneficiario_PreinscripcionId",
                table: "AgendaBeneficiario",
                column: "PreinscripcionId");

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
                name: "AgendaBeneficiario");

            migrationBuilder.DropTable(
                name: "ControlAsistencias");

            migrationBuilder.DropTable(
                name: "DetalleSalidas");

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
