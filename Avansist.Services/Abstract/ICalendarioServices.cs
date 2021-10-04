using Avansist.Models.Entities;
using Avansist.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.Abstract
{
    public interface ICalendarioServices
    {
        Task GuardarEvento(AgendaDto agendaDto);
        IEnumerable<AgendaDto> ListarEvento();
        Task EditarEvento(AgendaDto agendaDto);
        Task<AgendaDto> ObtenerAgendaPorId(int id);
        Task EliminarEvento(Agenda agenda);
        Task<Agenda> ObtenerIdParaEliminar(int id);
    }
}
