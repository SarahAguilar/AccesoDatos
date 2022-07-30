using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocios;

namespace AccesoDatosCOVID
{
    public partial class WebFormAlumnos : System.Web.UI.Page
    {
        LN bl = null;
        string idAlumno = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == false)
            {
                string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
                bl = new LN(cdn);
                Session["bl"] = bl;
                idAlumno = (string)Session["ID_Alumno"];
            }
            else
            {
                bl = (LN)Session["bl"];
                idAlumno = (string)Session["ID_Alumno"];
            }
            mostrarSeleccion();
        }
        public void mostrarSeleccion()
        {
            string msj = "";

            GridView1.DataSource = bl.InfoAlumnos(ref msj, idAlumno);
            GridView1.DataBind();
        }

        
    }
}