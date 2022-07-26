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
            mostrarPE(ref DropDownList1);
            mostrarCU(ref DropDownList2);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string msj = "";
            string id1="";
            string id2 = "";
            id1 = DropDownList1.SelectedItem.Value;
            id2 = DropDownList2.SelectedItem.Value;

            GridView1.DataSource = bl.ConsultaPro(ref msj, ref id1, ref id2);
            GridView1.DataBind();
        }

        public void mostrarProfs()
        {
            string msj = "";
            GridView1.DataSource = bl.VerProfesor(ref msj);
            GridView1.DataBind();
        }

        //Mostrar selct Carrera
        public void mostrarPE(ref DropDownList dropDownList)
        {

            string msj = "";
            DropDownList1.DataSource = bl.SelectProgEdu2(ref msj);
            DropDownList1.DataTextField = "ProgramaEd";
            DropDownList1.DataValueField = "Id_pe";
            DropDownList1.DataBind();

        }


        public void mostrarCU(ref DropDownList dropDownList)
        {

            string msj = "";
            DropDownList2.DataSource = bl.SelectCuatri(ref msj);
            DropDownList2.DataTextField = "Periodo";
            DropDownList2.DataValueField = "id_Cuatrimestre";
            DropDownList2.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_Profe"] = GridView1.SelectedRow.Cells[1].Text; //Se guarda el id del profe en una variable de sesion
            Response.Redirect("WebFormProfes.aspx"); //Redireccionamos
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           ;
        }
    }
}