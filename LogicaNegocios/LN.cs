using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Acceso;
using LogicaNegocios.Entidades;

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

        public DataTable VerProfesor(ref string msj)
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

            public DataTable VerProfesor2(string id , ref string msj)
            {
                string query = "SELECT * FROM Profesor where ID_Profe = " + id;
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

        public List<Profesores> SelectProfesor(ref string msj)
        {
            string query = "SELECT * FROM Profesor;";//consulta en la tabla cuatrimestre

            SqlDataReader atrapaDatos = null;

            atrapaDatos = acceso.ConsultarReader(query, acceso.AbrirConexion(ref msj), ref msj);

            List<Profesores> listSalida = new List<Profesores>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Entidades.Profesores
                    {
                        ID_Profe = (int)atrapaDatos[0],
                        Nombre = (string)atrapaDatos[2]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            return listSalida;
        }
        public List<Medico> SelectMedico(ref string msj)
        {
            string query = "SELECT * FROM Medico;";//consulta en la tabla cuatrimestre
            SqlDataReader atrapaDatos = null;

            atrapaDatos = acceso.ConsultarReader(query, acceso.AbrirConexion(ref msj), ref msj);

            List<Medico> listSalida = new List<Medico>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Medico
                    {
                        ID_Dr = (int)atrapaDatos[0],
                        Nombre = (string)atrapaDatos[1]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            return listSalida;
        }

        public int F_PositivoProfe(ref string msj)
        {
            string query = "select MAX(Id_posProfe) from PositivoProfe;";//consulta en la tabla cuatrimestre
            SqlDataReader readerData = null;
            readerData = acceso.ConsultarReader(query, acceso.AbrirConexion(ref msj), ref msj);
            int salida  = 0;

            //Verificamos que tenga datos el DataReader
            if (readerData != null)
            {
                while (readerData.Read())
                {
                    salida = (int)readerData[0];
                }
            }



            return salida;

        }

        public Boolean InsertarProfePositivo(string fecha, string com, string ant, string ries, int cont, string ex, int Fprf, string docP, int inca, int dias, string docI)
        {
            Boolean salida = false;
            string msj = "";
            string query = "INSERT INTO PositivoProfe (FechaConfirmado, Comprobacion, Antecedentes, Riesgo, NumContaio, Extra, F_Profe, Doc_Prueba, PeriodoIncapacidad, Dias_Incapacidad, Doc_Incapacidad)" +
                           "VALUES (@fechaC, @com, @ant, @rie, @conta, @ex, @fpro, @docP, @inca, @dias, @docI);";
            List<SqlParameter> listaP = new List<SqlParameter>();
            //listaP.Add(new SqlParameter()
            //{
            //    ParameterName = "id",
            //    SqlDbType = SqlDbType.Int,
            //    Value = id
            //});
            listaP.Add(new SqlParameter()
            {
                ParameterName = "fechaC",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = fecha
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "com",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = com
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "ant",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = ant
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "rie",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Value = ries
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "conta",
                SqlDbType = SqlDbType.Int,
                Value = cont
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "ex",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Value = ex
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "fpro",
                SqlDbType = SqlDbType.Int,
                Value = Fprf
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "docP",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = docP
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "inca",
                SqlDbType = SqlDbType.Int,
                Value = inca
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "dias",
                SqlDbType = SqlDbType.Int,
                Value = dias
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "docI",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = docI
            });
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

        public Boolean InsertarSeguimientoPro(int fpp, int fm, string fe, string com, string rep, string ent, string ex)
        {
            Boolean salida = false;
            string msj = "";
            List<SqlParameter> listaP = new List<SqlParameter>();
            string query = "INSERT INTO SeguimientoPRO (F_positivoProfe, F_medico, Fecha, Form_Comunica, Reporte, Entrevista, Extra)" +
                           "VALUES (@fPoPrf, @fMed, @f, @com, @rep, @ent, @ex);";
            //listaP.Add(new SqlParameter()
            //{
            //    ParameterName = "id",
            //    SqlDbType = SqlDbType.Int,
            //    Value = id
            //});
            listaP.Add(new SqlParameter()
            {
                ParameterName = "fPoPrf",
                SqlDbType = SqlDbType.Int,
                Value = fpp
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "fMed",
                SqlDbType = SqlDbType.Int,
                Value = fm
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "f",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = fe
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "com",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = com
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "rep",
                SqlDbType = SqlDbType.VarChar,
                Size = 250,
                Value = rep
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "ent",
                SqlDbType = SqlDbType.VarChar,
                Size = 250,
                Value = ent
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "ex",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Value = ex
            });
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

        public Boolean InsertarPositivoAlumno(int id, string fecha, string comp, string ante, string ries, int cont, string ext, int fAlu)
        {
            Boolean salida = false;
            string msj = "";
            List<SqlParameter> listaP = new List<SqlParameter>();
            string query = "INSERT INTO PositivoAlumno (ID_posAl, FechaConfirmado, Comprobacion, Antecedentes, Riesgo, NumContagio, Extra, F_Alumno)" +
                           "VALUES (@id, @fecha, @comp, @ante, @ries, @cont, @ext, @fAlu);";
            listaP.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Value = id
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "fecha",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = fecha
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "comp",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = comp
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "ante",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = ante
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "ries",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Value = ries
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "cont",
                SqlDbType = SqlDbType.Int,
                Value = cont
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "ext",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Value = ext
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "fAlu",
                SqlDbType = SqlDbType.Int,
                Value = fAlu
            });
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
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

        public void ModificarProfe(string id, int RegEm, string Nom, string Ap, string Am, string Gene, string Cate, string Corre, string Celu)
        {
            string query = "UPDATE Profesor SET RegistroEmpleado = @RegEm, Nombre = @Nom, Ap_pat = @Ap, Ap_Mat = @Am, " +
                "Genero = @Gene, Categoria = @Cate, Correo = @Corre, Celular = @Celu where ID_Profe = @id";
            string msj = "";
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "RegEm",
                SqlDbType = SqlDbType.VarChar,
                Value = RegEm,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "Nom",
                SqlDbType = SqlDbType.VarChar,
                Value = Nom,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "Ap",
                SqlDbType = SqlDbType.VarChar,
                Value = Ap,
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "Am",
                SqlDbType = SqlDbType.VarChar,
                Value = Am,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "Gene",
                SqlDbType = SqlDbType.VarChar,
                Value = Gene,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "Cate",
                SqlDbType = SqlDbType.VarChar,
                Value = Cate,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "Corre",
                SqlDbType = SqlDbType.VarChar,
                Value = Corre,
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "Celu",
                SqlDbType = SqlDbType.VarChar,
                Value = Celu,
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Value = id,
            });
            acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
        }


    }
}
