﻿using Avansist.Models.Entities;
using Avansist.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.Abstract
{
    public interface IControlAsistenciaServices
    {
        Task<IEnumerable<Preinscripcion>> ObtenerListaBeneficiario();
        Task<ControlAsistenciaDto> ObtenerIngresoPorId(int id);
        IEnumerable<ControlAsistenciaResumenDto> ListarControlAsistenciaResumenDto();
        Task GuardarIngreso(ControlAsistenciaDto controlAsistenciaDto);
        Task EditarIngreso(ControlAsistenciaDto controlAsistenciaDto);
    }
}