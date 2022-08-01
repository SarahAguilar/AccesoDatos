using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Acceso;

namespace LogicaNegocios
{
    public class LN
    {
        public ClassAccSQL acceso;
        private string conexion;

        public LN(string cdn) //Constructor
        {
            conexion = cdn;
            acceso = new ClassAccSQL(cdn);
        }
        public string Open() //Metodo abrir conexion
        {
            string msj = "";
            acceso.AbrirConexion(ref msj);
            return msj;
        }
        
        public DataTable VerProfesor( ref string msj)
        {
            string query = "SELECT * FROM Profesor;";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

        public DataTable VerAlumnos(ref string msj)
        {
            string query = "SELECT * FROM Alumno;";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

        public DataTable InfoProfe(ref string msj, string id)
        {
            //string query = "SELECT Id_PosProfe 'ID', FechaConfirmado,Comprobacion, Riesgo, Doc_Prueba, PeriodoIncapacidad, Dias_Incapacidad, Doc_Incapacidad FROM PositivoProfe where F_Profe = " + id;
            string query = "SELECT  pos.Id_posProfe 'ID', pos.FechaConfirmado 'Fecha', pos.Comprobacion, "
                + "pos.Antecedentes, pos.Riesgo, pos.NumContaio 'Contagios', pos.Doc_Prueba 'Documento Prueba', "
                + "pos.PeriodoIncapacidad 'N° Incapacidad', pos.Dias_Incapacidad 'N° días', pos.Doc_Incapacidad 'Documento Incapacidad', "
                + "seg.Form_Comunica 'Comunica', seg.Reporte, med.Nombre 'Medico', med.Telefono 'Tel medico', med.especialidad 'Especialidad' "
                + "FROM PositivoProfe pos "
                + "INNER JOIN SeguimientoPRO seg "
                + "ON pos.Id_posProfe = seg.F_positivoProfe "
                + "INNER JOIN Medico med "
                + "ON seg.F_medico = med.ID_Dr "
                + " where F_Profe = " + id;
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }
        public DataTable InfoAlumnos(ref string msj, string id)
        {
            string query = "SELECT * FROM PositivoAlumno where F_Alumno = " + id;
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaP = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaP);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }


        public void SubirPrueba(string id, string ruta)
        {
            string query = "UPDATE PositivoProfe SET Doc_Prueba= @ruta where Id_posProfe = @id";
            string msj = "";
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "ruta",
                SqlDbType = SqlDbType.VarChar,
                Value = ruta,
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });
            acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
        }

        public void SubirIncapacidad(string id, string ruta)
        {
            string query = "UPDATE PositivoProfe SET Doc_Incapacidad= @ruta where Id_posProfe = @id";
            string msj = "";
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "ruta",
                SqlDbType = SqlDbType.VarChar,
                Value = ruta,
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });
            acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
        }

        public DataTable SelectProgEdu(ref string msj)
        {
            string query = "SELECT * FROM ProgramaEducativo;";//consulta en la tabla programa educativo
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaPro = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaPro);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }
        
        public DataTable SelectProgEdu2(ref string msj)
        {
            string query = "SELECT * FROM ProgramaEducativo;";//consulta en la tabla programa educativo
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaPro = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaPro);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

        public DataTable SelectCuatri(ref string msj)
        {
            string query = "SELECT * FROM Cuatrimestre;";//consulta en la tabla cuatrimestre
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaPro = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaPro);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

        public DataTable SelectGru(ref string msj)
        {
            string query = "SELECT * FROM Grupo;";//consulta en la tabla grupo
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaPro = new List<SqlParameter>();
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaPro);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

        public Boolean BorrarSeguimientoPro(string id)
        {
            string query = "DELETE FROM SeguimientoPRO where F_positivoProfe = " + id;
            string msj = "";
            Boolean salida = false;
            List<SqlParameter> listaP = new List<SqlParameter>();
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

        public Boolean BorrarPositivoProfe(string id)
        {
            string query = "DELETE FROM PositivoProfe where Id_posProfe = " + id;
            string msj = "";
            Boolean salida = false;
            List<SqlParameter> listaP = new List<SqlParameter>();
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

    }
}
