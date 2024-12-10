using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMigracion.ClssDatos
{
    public class Usuarios
    {
        public int IDUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
    }
}
