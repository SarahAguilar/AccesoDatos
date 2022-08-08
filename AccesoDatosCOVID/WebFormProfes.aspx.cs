using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocios;

namespace AccesoDatosCOVID
{
	public partial class WebFormProfes : System.Web.UI.Page
	{
		LN bl = null;
		string idProfe = null;
		string idDetalle = null;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack == false)
            {
				string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
				bl = new LN(cdn);
				Session["bl"] = bl;
				idProfe = (string)Session["ID_Profe"];
            } else
            {
				bl = (LN)Session["bl"];
				idProfe = (string)Session["ID_Profe"];
			}
			mostrarSeleccion();
			NoVisibles();
			mostrarProfs2();
		}
		public void mostrarProfs2()
		{
			string msj = "";
			GridViewUnProfe.DataSource = bl.VerProfesor2(idProfe, ref msj);
			GridViewUnProfe.DataBind();
		}
		public void mostrarSeleccion()
		{
			string msj = "";
			
			GridView1.DataSource = bl.InfoProfe(ref msj, idProfe);
			GridView1.DataBind();
		}

		public void NoVisibles()
        {
			
			LabelPrueba.Visible = false;
			FileUploadPrueba.Visible = false;
			ButtonPrueba.Visible = false;
			LabelIncapacidad.Visible = false;
			FileUploadIncapacidad.Visible = false;
			ButtonIncapacidad.Visible = false;
			LabelMsj.Visible = false;
			TextBoxStatus.Visible = false;
			ButtonEliminar.Visible = false;

		}
		public void Visibles()
		{

			idDetalle = GridView1.SelectedRow.Cells[1].Text;
			LabelMsj.Text = "Se editara el profesor con el Id " + idDetalle;
			LabelMsj.Visible = true;
			LabelPrueba.Visible = true;
			FileUploadPrueba.Visible = true;
			ButtonPrueba.Visible = true;
			LabelIncapacidad.Visible = true;
			FileUploadIncapacidad.Visible = true;
			ButtonIncapacidad.Visible = true;
			TextBoxStatus.Visible = true;
			ButtonEditar.Visible = true;
			ButtonEliminar.Visible = true;
		}

		protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
			Visibles();
			

		}

        protected void ButtonPrueba_Click(object sender, EventArgs e)
        {
			idDetalle = GridView1.SelectedRow.Cells[1].Text;
            if (FileUploadPrueba.HasFile == true) //Si el control tiene archivos
            {
                try
                {
                    if (FileUploadPrueba.PostedFile.ContentType == "image/jpeg" || FileUploadPrueba.PostedFile.ContentType == "image/png" || FileUploadPrueba.PostedFile.ContentType == "application/pdf")
                    {//Si el archivo es de tipo imagen p pdf
                        if (FileUploadPrueba.PostedFile.ContentLength < 102400) //Y si el archivo es menor al tamaño indicado
                        {

                            string filename = Path.GetFileName(FileUploadPrueba.FileName); //Devuelve en nombre del archivo
                            
							FileUploadPrueba.PostedFile.SaveAs(Server.MapPath("~/imgs/" + filename)); //Se guarda en la ruta especificada
							bl.SubirPrueba(idDetalle, filename);


							TextBoxStatus.Text = "El archivo se agrego correctamente!";
                        }
                        else
							TextBoxStatus.Text = "Es demasiado grande, debe pesar menos de 100 kb!";
                    }
                    else
						TextBoxStatus.Text = "Error! El archivo debe ser imagen o PDF";
                }
                catch (Exception ex)
                {
					TextBoxStatus.Text = "Error! El archivo no se pudo subir " + ex.Message;
                } 
			}
			else
			{
				TextBoxStatus.Text = "Error! Es necesario seleccionar un documento.";
			}
            Visibles();
        }

        protected void ButtonIncapacidad_Click(object sender, EventArgs e)
        {
			idDetalle = GridView1.SelectedRow.Cells[1].Text;
			if (FileUploadIncapacidad.HasFile == true) //Si el control tiene archivos
			{
				try
				{
					if (FileUploadIncapacidad.PostedFile.ContentType == "image/jpeg" || FileUploadIncapacidad.PostedFile.ContentType == "image/png" || FileUploadIncapacidad.PostedFile.ContentType == "application/pdf")
					{//Si el archivo es de tipo imagen p pdf
						if (FileUploadIncapacidad.PostedFile.ContentLength < 102400) //Y si el archivo es menor al tamaño indicado
						{

							string filename = Path.GetFileName(FileUploadIncapacidad.FileName); //Devuelve en nombre del archivo

							FileUploadIncapacidad.PostedFile.SaveAs(Server.MapPath("~/imgs/" + filename)); //Se guarda en la ruta especificada
							bl.SubirIncapacidad(idDetalle, filename);


							TextBoxStatus.Text = "El archivo se agrego correctamente!";
						}
						else
							TextBoxStatus.Text = "Es demasiado grande, debe pesar menos de 100 kb!";
					}
					else
						TextBoxStatus.Text = "Error! El archivo debe ser imagen o PDF";
				}
				catch (Exception ex)
				{
					TextBoxStatus.Text = "Error! El archivo no se pudo subir " + ex.Message;
				}
			} 
			else
            {
				TextBoxStatus.Text = "Error! Es necesario seleccionar un documento.";
			}
			Visibles();
		}

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
			idDetalle = GridView1.SelectedRow.Cells[1].Text;
			string resp = "";
			Boolean recibe = false;
			Boolean recibe2 = false;
			recibe = bl.BorrarSeguimientoPro(idDetalle);
			recibe2 = bl.BorrarPositivoProfe(idDetalle);

			if (recibe && recibe2)
			{
				TextBoxStatus.Text = "Se elimino exitosamente";
				Response.Redirect("WebFormProfes.aspx"); //Redireccionamos
			}
			else
			{
				TextBoxStatus.Text = "ERROR! No se pudo eliminar";
			}
			Visibles();
			
		}

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
			Response.Redirect("WebFormEditarProfes.aspx"); //Redireccionamos
		}

        protected void Modificar_Click(object sender, EventArgs e)
        {
            
        }

       
        protected void GridViewUnProfe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}