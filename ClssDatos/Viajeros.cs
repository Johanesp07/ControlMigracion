using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMigracion.ClssDatos
{
    public class Viajeros
    {
        public int IDViajero { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroPasaporte { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Nacionalidad { get; set; }
       
    }
}

