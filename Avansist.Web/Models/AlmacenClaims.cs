using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Avansist.Web.Models
{
    public class AlmacenClaims
    {
        public static List<Claim> todosLosClaims = new()
        {
            new Claim("Crear Preinscripcion","Crear Preinscripcion"),
            new Claim("Editar Preinscripcion", "Editar Preinscripcion"),
            new Claim("Ver Preinscripcion", "Ver Preinscripcion"),
            new Claim("Crear Matricula", "Crear Matricula"),
            new Claim("Editar Matricula", "Editar Matricula"),
            new Claim("Ver Matricula", "Ver Matricula"),
            new Claim("Crear Retiro", "Crear Retiro"),
            new Claim("Editar Retiro", "Editar Retiro"),
            new Claim("Ver Retiro", "Ver Retiro"),
            new Claim("Crear Entrada", "Crear Entrada"),
            new Claim("Crear Salida", "Crear Salida"),
            new Claim("Ver Asistencia", "Ver Asistencia"),
            new Claim("Crear Salida Extracurricular", "Crear Salida Extracurricular"),
            new Claim("Editar Salida Extracurricular", "Crear Salida Extracurricular"),
            new Claim("Agregar Beneficiario a Salida Extracurriculas", "Agregar Beneficiario a Salida Extracurriculas"),
            new Claim("Generar reporte aprobados VS No aprobados", "Generar reporte aprobados VS No aprobados"),
            new Claim("Generar reporte matriculados VS retirados", "Generar reporte matriculados VS retirados"),
            new Claim("Generar reporte solicitudes aprobadas VS matriculados", "Generar reporte matriculados VS retirados")
        };
    }
}
