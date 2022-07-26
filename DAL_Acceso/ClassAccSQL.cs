using System;
using System.Collections.Generic;
using System.Data;
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

        public void CerrarConexion(SqlConnection conAbierta)
        {
            if (conAbierta != null) //Si la conexion es diferente de null
            {
                if (conAbierta.State == ConnectionState.Open) //Si el estado de la conexion es igual a abierta
                {
                    conAbierta.Close();//Cierra la conexion
                    conAbierta.Dispose();//Se destruye
                }
            }

        }

        public DataSet BuscaProfesor(string querySql, SqlConnection conAbierta, ref string mensaje, List<SqlParameter> parametros)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet DS_salida = new DataSet();

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                DS_salida = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                //Agregar posibles parametros
                foreach (SqlParameter p in parametros)
                {
                    carrito.Parameters.Add(p); //Al carrito le aqregamos los parametros
                }

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(DS_salida, "Consulta1");
                    mensaje = "Consulta Correcta en DataSet";
                }
                catch (Exception a)
                {
                    DS_salida = null;
                    mensaje = "Error!" + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return DS_salida;
        }
    }
}
