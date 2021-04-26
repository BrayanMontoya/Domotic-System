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
        //Este método GET lo que hace es consultar en la base de datos que los datos 
        // de usuario y contraseña coincidad, si lo hacen, regresa TRUE sino FALSE
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
        //Este método GET lo que hace es que al pasar el login de la aplicación, consulta en la base de datos
        // con que estado se había quedado tanto el enchufe como el contacto, para que se refleje
        // a través de las imagenes que representarán al dispositivo si están prendidos o apagados.
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

        // Este método POST lo que hace es que al momento de seleccionar la luminosidad
        // del foco, actualiza en la base de datos.
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

        //Este método POST lo que hace es actualizar en la base de datos si es que se prende/apaga el
        //enchufe
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
