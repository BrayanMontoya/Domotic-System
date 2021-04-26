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

        // GET api/Dispositivo/id/temperatura/humedad/estadoFoco
        [HttpGet("{id}/{temperatura}/{humedad}/{estadoFoco}")]
        public Models.Dispositivo Get(int id, float temperatura, float humedad, int estadoFoco)
        {
            using (var db = new Models.SistemaDomoticoContext())
            {
                var dispositivo = db.Dispositivos.FirstOrDefault(x => x.IdDispositivo == id);
                if(estadoFoco == 1)
                {
                    if(dispositivo.EstadoFoco > 0)
                    {
                        dispositivo.EstadoFoco = 0;
                    }
                    else
                    {
                        dispositivo.EstadoFoco = 255;
                    }
                }
                dispositivo.Temperatura = temperatura;
                dispositivo.Humedad = humedad;
                db.SaveChanges();
                return dispositivo;
            }
        }



      

    
    }
}
