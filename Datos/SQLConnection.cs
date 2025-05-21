using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AsistControl.Datos
{
    public class SQLConnection
    {
        public static string conexion = @"Data source=DESKTOP-GF05E8G\SQLEXPRESS; Initial Catalog=ASISTIA; Integrated Security=true";
        public static SqlConnection sqlconexion = new SqlConnection(conexion);

        public static void Abrir()
        {
            if (sqlconexion.State == ConnectionState.Closed)
            {
                sqlconexion.Open();
            }
        }

        public static void Cerrar()
        {
            if(sqlconexion.State == ConnectionState.Open)
            {
                sqlconexion.Close();
            }
        }
    }
}
