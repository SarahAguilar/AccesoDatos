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

        public ClassAccSQL(string cadcon)//Constructor
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

        public DataSet ConsultaDS(string querySql, SqlConnection conAbierta, ref string mensaje, List<SqlParameter> parametros)
        {
            SqlCommand instruccion = null; //Crea el comando
            SqlDataAdapter trailer = null;
            DataSet dataset = new DataSet();

            if (conAbierta == null)
            {
                mensaje = "Error al conectarse a la BD";
                dataset = null;
            }
            else
            {
                instruccion = new SqlCommand(); //instancia el comando
                instruccion.CommandText = querySql;
                instruccion.Connection = conAbierta;

                //Agregar posibles parametros
                foreach (SqlParameter p in parametros)
                {
                    instruccion.Parameters.Add(p); //Al carrito le aqregamos los parametros
                }

                trailer = new SqlDataAdapter(); //Instancia
                trailer.SelectCommand = instruccion;

                try
                {
                    trailer.Fill(dataset, "Consulta1"); //Agregamos al dataset y asignamos un nombre
                    mensaje = "Consulta Correcta en DataSet";
                }
                catch (Exception a)
                {
                    dataset = null;
                    mensaje = "Error!" + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return dataset;

        }

        public bool Modificar(SqlConnection conAbierta, string sentenciaSQL, ref string msj, List<SqlParameter> lista)
        {
            SqlCommand carrito = null; //Crea el comando
            Boolean salida = false;
            AbrirConexion(ref msj);
            if (conAbierta != null)
            {
                carrito = new SqlCommand();
                carrito.CommandText = sentenciaSQL;
                carrito.Connection = conAbierta;
                foreach (SqlParameter temp in lista)
                {
                    carrito.Parameters.Add(temp);
                }
                try
                {
                    carrito.ExecuteNonQuery(); //Realiza cambios de la base
                    salida = true;
                    // msj = "Modificación correcta";
                }
                catch (Exception e)
                {
                    salida = false;
                    // msj = "Error" + e.Message;
                }
            }
            else
            {
                salida = false;
            }
            return salida;
        }

    


    }
}
