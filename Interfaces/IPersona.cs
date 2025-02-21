using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPersona
    {
        Task<Persona> ObtenerPorId(int id);
        Task<int> InsertarPersona(Persona entidad);

    }
}
