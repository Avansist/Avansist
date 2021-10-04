using Avansist.DAL;
using Avansist.Models.Entities;
using Avansist.Services.Abstract;
using Avansist.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.Servicies
{
    public class CalendarioServices : ICalendarioServices
    {
        private readonly AvansistDbContext _context;

        public CalendarioServices(AvansistDbContext context)
        {
            _context = context;
        }
        public async Task GuardarEvento(AgendaDto agendaDto)
        {
            Agenda agenda = new()
            {
                AgendaId = agendaDto.AgendaId,
                NombreEvento = agendaDto.NombreEvento,
                EmpleadoEncargado = agendaDto.EmpleadoEncargado,
                NumeroDocumento = agendaDto.NumeroDocumento,
                Telefono = agendaDto.Telefono,
                Direccion = agendaDto.Direccion,
                HoraInicioEvento = agendaDto.HoraInicioEvento,
                HoraFinEvento = agendaDto.HoraFinEvento,
                FechaInicioEvento = agendaDto.FechaInicioEvento
                //FechaFinEvento = agendaDto.FechaFinEvento
            };

            _context.Add(agenda);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<AgendaDto> ListarEvento()
        {
            List<AgendaDto> listaAgendaDto = new();

            _context.Agendas.ToList().ForEach(ca =>
            {
                AgendaDto agendaDto = new()
                {
                    AgendaId = ca.AgendaId,
                    NombreEvento = ca.NombreEvento,
                    EmpleadoEncargado = ca.EmpleadoEncargado,
                    NumeroDocumento = ca.NumeroDocumento,
                    Telefono = ca.Telefono,
                    Direccion = ca.Direccion,
                    FechaInicioEvento = ca.FechaInicioEvento,
                    //FechaFinEvento = ca.FechaFinEvento,
                    HoraInicioEvento = ca.HoraInicioEvento,
                    HoraFinEvento = ca.HoraFinEvento
                };
                listaAgendaDto.Add(agendaDto);
            });
            return listaAgendaDto;
        }

        public async Task EditarEvento(AgendaDto agendaDto)
        {
            Agenda agenda = new()
            {
                AgendaId = agendaDto.AgendaId,
                NombreEvento = agendaDto.NombreEvento,
                EmpleadoEncargado = agendaDto.EmpleadoEncargado,
                NumeroDocumento = agendaDto.NumeroDocumento,
                Telefono = agendaDto.Telefono,
                Direccion = agendaDto.Direccion,
                HoraInicioEvento = agendaDto.HoraInicioEvento,
                HoraFinEvento = agendaDto.HoraFinEvento,
                FechaInicioEvento = agendaDto.FechaInicioEvento
                //FechaFinEvento = agendaDto.FechaFinEvento
            };

            _context.Update(agenda);
            await _context.SaveChangesAsync();
        }

        public async Task<AgendaDto> ObtenerAgendaPorId(int id)
        {
            var a = await _context.Agendas.Where(be => be.AgendaId == id).FirstAsync();
            AgendaDto agendaDto = new()
            {
                AgendaId = a.AgendaId,
                NombreEvento = a.NombreEvento,
                EmpleadoEncargado = a.EmpleadoEncargado,
                NumeroDocumento = a.NumeroDocumento,
                Telefono = a.Telefono,
                Direccion = a.Direccion,
                HoraInicioEvento = a.HoraInicioEvento,
                HoraFinEvento = a.HoraFinEvento,
                FechaInicioEvento = a.FechaInicioEvento
                //FechaFinEvento = a.FechaFinEvento
            };
            return agendaDto;
        }

        public async Task EliminarEvento(Agenda agenda)
        {
            try
            {
                _context.Remove(agenda);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Agenda> ObtenerIdParaEliminar(int id)
        {
            var agenda = await _context.Agendas.FirstOrDefaultAsync(a => a.AgendaId == id);
            return agenda;
        }

    }

}
