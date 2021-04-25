using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaDomotico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {

        // GET api/<DispositivoController>/5
        [HttpGet("{id}")]
        public Models.Dispositivo Get(int id)
        {
            using (var db = new Models.SistemaDomoticoContext())
            {
                return db.Dispositivos.FirstOrDefault(x => x.IdDispositivo == id);
            }
        }

        // POST api/<DispositivoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    
    }
}
