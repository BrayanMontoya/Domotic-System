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
        // GET api/Usario/usario/contraseña
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
       
    }
}
