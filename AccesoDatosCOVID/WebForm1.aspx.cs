﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocios;
using System.Configuration;

namespace AccesoDatosCOVID
{
    public partial class WebForm1 : System.Web.UI.Page
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
            mostrarProfs();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        public void mostrarProfs()
        {
            string msj = "";
            GridView1.DataSource = bl.VerProfesor(ref msj);
            GridView1.DataBind();
        }
    }
}