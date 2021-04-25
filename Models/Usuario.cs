using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaDomotico.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Dispositivos = new HashSet<Dispositivo>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Dispositivo> Dispositivos { get; set; }
    }
}
