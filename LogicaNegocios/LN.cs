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
            string query = "SELECT Id_PosProfe 'ID', FechaConfirmado,Comprobacion, Riesgo, Doc_Prueba, PeriodoIncapacidad, Dias_Incapacidad, Doc_Incapacidad FROM PositivoProfe where F_Profe = " + id;
            //string query = "SELECT  pos.Id_posProfe, pos.FechaConfirmado, pos.Comprobacion, pos.Antecedentes," +
            //    "pos.Riesgo, pos.NumContaio, pos.Doc_Prueba, pos.PeriodoIncapacidad, " +
            //    "pos.Dias_Incapacidad, pos.Doc_Incapacidad," +
            //    "seg.Form_Comunica, seg.Reporte, med.Nombre, med.Telefono, med.especialidad" +
            //    "FROM PositivoProfe " +
            //    "INNER JOIN SeguimientoPRO seg" +
            //    "ON pos.Id_posProfe = seg.F_positivoProfe " +
            //    "INNER jOIN Medico med" +
            //    "ON seg.F_medico = med.ID_Dr where F_Profe = " + id;
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

        //Consulta Profesor 
        public DataTable ConsultaPro(ref string msj, ref string idPE, ref string idCU)
        {
            
            string query = "SELECT P.ID_Profe, Nombre, Ap_pat, Ap_Mat, PE.ProgramaEd, C.Periodo " +
                "From Profesor P, PositivoProfe PP, ProfeGRupo PG, GrupoCuatrimestre GC, ProgramaEducativo PE, Cuatrimestre C " +
                "WHERE PP.F_Profe = P.id_Profe AND P.id_Profe = PG.F_Profe AND PG.F_GruCuat = GC.id_GruCuat AND GC.F_ProgEd = PE.id_pe AND GC.F_Cuatri = C.id_Cuatrimestre; " ; 
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaPro = new List<SqlParameter>();
            listaPro.Add(new SqlParameter()
            {
                ParameterName = "idPe",
                SqlDbType = SqlDbType.VarChar,
                Value = idPE,
            });
            listaPro.Add(new SqlParameter()
            {
                ParameterName = "idCua",
                SqlDbType = SqlDbType.VarChar,
                Value = idCU,
            });
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaPro);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }

        //Consulta Alumno 
        public DataTable ConsultaAl(ref string msj, ref string idPE, ref string idCU, ref string idGR)
        {

            string query = "SELECT A.ID_Alumno, Matricula, Nombre, Ap_pat, Ap_Mat, PE.ProgramaEd, C.Periodo, G.Grado " +
                "From Alumno A, AlumnoGrupo AG, GrupoCuatrimestre GC,ProgramaEducativo PE, Cuatrimestre C, Grupo G " +
                "WHERE A.ID_Alumno = AG.F_Alumn AND GC.Id_GruCuat = AG.F_GruCuat AND GC.F_Cuatri = C.id_Cuatrimestre AND GC.F_ProgEd = PE.Id_pe AND GC.F_Grupo = G.Id_grupo; ";
            DataTable salida = null;
            DataSet ds = null;
            List<SqlParameter> listaPro = new List<SqlParameter>();
            listaPro.Add(new SqlParameter()
            {
                ParameterName = "idPe",
                Value = idPE,
                
            });
            listaPro.Add(new SqlParameter()
            {
                ParameterName = "idCua",
                SqlDbType = SqlDbType.VarChar,
                Value = idCU,
            });
            listaPro.Add(new SqlParameter()
            {
                ParameterName = "idGru",
                SqlDbType = SqlDbType.VarChar,
                Value = idGR,
            });
            ds = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msj), ref msj, listaPro);
            if (ds != null) //Si el DataSet no esta vacio
            {
                salida = ds.Tables[0]; //Obtiene las tablas del DataSet
            }
            return salida;
        }
    }
}
