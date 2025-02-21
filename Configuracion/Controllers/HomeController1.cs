using Microsoft.AspNetCore.Mvc;
using System;

namespace Configuracion.Controllers
{
    [Route("api/[controller]")]

    /// <summary>
    /// otra cosa
    /// </summary>
    /// <returns></returns>
    public class HomeController1 : ControllerBase
    {
        /// <summary>
        /// Pruebas de algo para doucmn
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perso>>> GetPeople()
        {
            List <Perso> persona = new List<Perso>();
            for (int i = 0; i < 10; i++)
            {
                Perso spersona = new Perso
                {
                    Id = i,
                    Name = "s"+i,
                    Description = "1sda"+i
                };
                persona.Add(spersona);  
            }

            return persona;
        }
        public class Perso
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

        }
    }
}
