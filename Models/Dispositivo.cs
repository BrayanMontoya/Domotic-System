using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaDomotico.Models
{
    public partial class Dispositivo
    {
        public int IdDispositivo { get; set; }
        public int EstadoFoco { get; set; }
        public bool EstadoEnchufe { get; set; }
        public double Temperatura { get; set; }
        public double Humedad { get; set; }
        public int Usuario { get; set; }

        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
