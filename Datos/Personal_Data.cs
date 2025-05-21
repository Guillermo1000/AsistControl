using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AsistControl.Logica;
using System.Windows.Forms;

namespace AsistControl.Datos
{
    public class Personal_Data
    {

        public bool InsertarPersonal(Personal_Logic parametros )
        {

            try
            {
                SQLConnection.Abrir();
                SqlCommand cmd = new SqlCommand("InsertarPersonal", SQLConnection.sqlconexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                cmd.Parameters.AddWithValue("@Identificacion", parametros.Identificacion);
                cmd.Parameters.AddWithValue("@Pais", parametros.Pais);
                cmd.Parameters.AddWithValue("@Id_cargo", parametros.Id_cargo);
                cmd.Parameters.AddWithValue("@SueldoPorHora", parametros.SueldoPorHora);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                SQLConnection.Cerrar();
            }
        }

        public bool EditarPersonal(Personal_Logic parametros)
        {
            try
            {
                SQLConnection.Abrir();
                SqlCommand cmd = new SqlCommand("EditarPersonal", SQLConnection.sqlconexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_personal", parametros.Id_Persona);
                cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                cmd.Parameters.AddWithValue("@Identificacion", parametros.Identificacion);
                cmd.Parameters.AddWithValue("@Pais", parametros.Pais);
                cmd.Parameters.AddWithValue("@Id_cargo", parametros.Id_cargo);
                cmd.Parameters.AddWithValue("@SueldoPorHora", parametros.SueldoPorHora);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                SQLConnection.Cerrar();
            }
        }
        public bool EliminarPersonal(Personal_Logic parametros)
        {
            try
            {
                SQLConnection.Abrir();
                SqlCommand cmd = new SqlCommand("EliminarPersonal", SQLConnection.sqlconexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idpersonal", parametros.Id_Persona);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                SQLConnection.Cerrar();
            }
        }

        public void MostrarPersonal(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                SQLConnection.Abrir();
                SqlDataAdapter sda = new SqlDataAdapter("MostrarPersonal",SQLConnection.sqlconexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                sda.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                SQLConnection.Cerrar();
            }
        }

        public void BuscarPersonal(ref DataTable dt, int desde, int hasta, string buscador)
        {
            try
            {
                SQLConnection.Abrir();
                SqlDataAdapter sda = new SqlDataAdapter("BuscarPersonal", SQLConnection.sqlconexion);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                sda.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                sda.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                SQLConnection.Cerrar();
            }
        }
    }
}
