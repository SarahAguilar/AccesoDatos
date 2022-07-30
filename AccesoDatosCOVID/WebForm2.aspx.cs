using LogicaNegocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccesoDatosCOVID
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        LN bl = null;
        //public LN bl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) //Si es la primera ves que carga la aplicación
            {
                string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
                bl = new LN(cdn);
                Session["bl"] = bl;
            }
            else //Si viene de un postBack
            {

                bl = (LN)Session["bl"];
            }
            mostrarAlum();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        public void mostrarAlum()
        {
            string msj = "";
            GridView1.DataSource = bl.VerAlumnos(ref msj);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_Alumno"] = GridView1.SelectedRow.Cells[1].Text; //Se guarda el id del profe en una variable de sesion
            Response.Redirect("WebFormAlumnos.aspx"); //Redireccionamos
        }
    }
}