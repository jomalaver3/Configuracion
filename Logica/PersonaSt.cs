using Datos;
using Entidades;
using Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PersonaSt : IPersona
    {
        private readonly ApplicationDbContext context;
        public PersonaSt(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> InsertarPersona(Persona entidad)
        {
            var parametroId = new SqlParameter("@id", SqlDbType.Int);
            parametroId.Direction = ParameterDirection.Output;
            await context.Database
                .ExecuteSqlInterpolatedAsync($@"Exec spInsertarPersona @nombre={entidad.Nombre},@apellido={entidad.Apellido}, @id={parametroId} OUTPUT");
            var id = (int)parametroId.Value;
            return id;
        }

        //public async Task<List<Persona>> ObtenerPersonas(int id)
        //{
        //    var personas = context.Personas
        //        FromSqlInterpolated($"EXEC PersonasObtenerPorId @id={id}");

        //    { }
        //    var clientes = new List<Cliente>();
        //    var dataTable = _context.ExecuteStoredProcedure("sp_ObtenerClientes");

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        clientes.Add(new Cliente
        //        {
        //            Id = Convert.ToInt32(row["Id"]),
        //            Nombre = row["Nombre"].ToString(),
        //            Email = row["Email"].ToString()
        //        });
        //    }
        //    return await Task.FromResult(clientes);
        //}

        public async Task<Persona> ObtenerPorId(int id)
        {
            var personas = context.Personas
                .FromSqlInterpolated($"EXEC PersonasObtenerPorId @id={id}")
                .AsAsyncEnumerable();
            await foreach (var persona in personas)
            {
                return persona;
            }
            return null ;
        }
    }
}
