using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Acceso
{
    public class ClassAccSQL
    {

        private string conexion;

        public ClassAccSQL(string cadcon)
        {
            conexion = cadcon;
        }
        public SqlConnection AbrirConexion(ref string mensaje) 
        {
            SqlConnection conAbierta = new SqlConnection(); //Conexion a la base de datos Covid 
            conAbierta.ConnectionString = conexion;

            try
            {
                conAbierta.Open(); //Abre BD
                mensaje = "Conexión abierta CORRECTAMENTE";
            }
            catch (Exception r)
            {
                conAbierta = null; //Devuelve una conexion nula
                mensaje = "Error: " + r.Message;
            }
            return conAbierta;
        }
    }
}
