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
    public class UsuarioController : ControllerBase
    {
        // GET api/Usario/usuario/contraseña
        // GET api/Usario/brayan/123
        [HttpGet("{userName}/{password}")]
        public bool Get(string userName, string password)
        {
            using (var db = new Models.SistemaDomoticoContext())
            {
                if(db.Usuarios.Any(x=> x.Nombre == userName && x.Contraseña == password))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            
        }
        //Enchufe y foco
        // GET api/<DispositivoController>/5
        [HttpGet("{id}")]
        public Models.Dispositivo Get(int id)
        {
            using (var db = new Models.SistemaDomoticoContext())
            {
                return db.Dispositivos.FirstOrDefault(x => x.IdDispositivo == id);
            }
        }

        //Foco
        // POST api/<DispositivoController>/5
        [HttpPost("{id}/{dimmer}")]
        public void Post(int id,  int dimmer)
        {

            using (var db = new Models.SistemaDomoticoContext())
            {
                var datos = db.Dispositivos.FirstOrDefault(x => x.IdDispositivo == id);
                if(dimmer == 0 )
                {
                    if(datos.EstadoFoco == 0)
                    {
                        datos.EstadoFoco = 255;
                    }
                    else
                    {
                        datos.EstadoFoco = 0;
                    }
                }
                else
                {
                    datos.EstadoFoco = dimmer;
                }
                db.SaveChanges();
            }
        }

        //Enchufe
        // POST api/<DispositivoController>/5
        [HttpPost("{id}")]
        public void Post(int id)
        {

            using (var db = new Models.SistemaDomoticoContext())
            {
                var datos = db.Dispositivos.FirstOrDefault(x => x.IdDispositivo == id);                    
                if(datos.EstadoEnchufe == 1)
                {
                    datos.EstadoEnchufe = 0;
                }
                else
                {
                    datos.EstadoEnchufe = 1;
                }
                db.SaveChanges();
            }
        }


    }
}
