using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ControlMigracion.ClssDatos
{
    public static class DBcon
    {
        public static string conexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
    }
}