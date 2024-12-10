using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMigracion.ClssDatos
{
    public class Entradas
    {
        public int IDEntrada { get; set; }
        public int IDViajero { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int IDPaisOrigen { get; set; }
        public int IDUsuarioRegistro { get; set; }
    }
}