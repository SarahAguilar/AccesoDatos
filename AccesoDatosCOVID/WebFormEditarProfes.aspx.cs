using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocios;
using LogicaNegocios.Entidades;

namespace AccesoDatosCOVID
{
    public partial class WebFormEditarProfes : System.Web.UI.Page
    {
        LN bl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
                bl = new LN(cdn);
                Session["bl"] = bl;
                mostrarProfes();
                mostrarMedico();
            }
            else
            {
                bl = (LN)Session["bl"];
                
            }
            
        }

        public void mostrarProfes()
        {

            string msj = "";
            List<Profesores> listRecibe = null;
            string msg = "";
            listRecibe = bl.SelectProfesor(ref msg);

            if (listRecibe != null)
            {
                DropDownList1IdProfesor.Items.Clear();
                foreach (Profesores item in listRecibe)
                {
                    DropDownList1IdProfesor.Items.Add(new ListItem(item.Nombre, item.ID_Profe.ToString()));
                }

            }

        }
        public void mostrarMedico()
        {
            List<Medico> listRecibe = null;
            string msg = "";
            listRecibe = bl.SelectMedico(ref msg);

            if (listRecibe != null)
            {
                DropDownListMedico.Items.Clear();
                foreach (Medico item in listRecibe)
                {
                    DropDownListMedico.Items.Add(new ListItem(item.Nombre, item.ID_Dr.ToString()));
                }

            }

        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            
            Profesores temp2 = new Profesores();
            Boolean recibe = false;
            Boolean recibe2 = false;
            string msj = "";
            int  co = 0, fp = 0, i = 0, d = 0;
            string f = "", c = "", a = "", r = "", ex = "", dp = "", di = "";

            int fpp = 0, fm = 0;
            string fe = "", com = "", rep = "", ent = "", ex2 = "";

            string filename = Path.GetFileName(FileUploadPrueba.FileName); //Devuelve en nombre del archivo
            FileUploadPrueba.PostedFile.SaveAs(Server.MapPath("~/imgs/" + filename)); //Se guarda en la ruta especificada

            string filename2 = Path.GetFileName(FileUploadPruebaI.FileName); //Devuelve en nombre del archivo
            FileUploadPruebaI.PostedFile.SaveAs(Server.MapPath("~/imgs/" + filename2)); //Se guarda en la ruta especificada

            
            co = Convert.ToInt16(TextBox6NumContagio.Text);
            fp = Convert.ToInt16(ViewState["ID_Profe"]);
            i = Convert.ToInt16(TextBox1PeriodoInca.Text);
            d = Convert.ToInt16(TextBoxDíasInca.Text);
            f = TextBoxFechaConfirmado.Text;
            c = TextBoxComprobacion.Text;
            a = TextBoxAntecedentes.Text;
            r = TextBoxRiesgo.Text;
            ex = TextBoxExtra.Text;
            //dp = FileUploadPrueba.ToString();
            //di = FileUploadPruebaI.ToString();

            fm = Convert.ToInt16(ViewState["ID_Dr"]);
            fe = TextBoxFecha.Text;
            com = TextBoxFormComunica.Text;
            rep = TextBoxReporte.Text;
            ent = TextBoxEntrevista.Text;
            ex2 = TextBoxExtraSegui.Text;

            

            recibe = bl.InsertarProfePositivo(f, c, a, r, co, ex, fp, filename, i, d, filename2);
            fpp = bl.F_PositivoProfe(ref msj);
            recibe2 = bl.InsertarSeguimientoPro(fpp, fm, fe, com, rep, ent, ex2);
            if (recibe == true && recibe2 == true)
            {
                ViewState["ID_Profe"] = 0;
                ViewState["ID_Dr"] = 0;
                TextBoxStatus.Text = "Nuevo registro agregado exitosamente";
            } else
            {
                TextBoxStatus.Text = "Error!, no se agrego el registro";
            }
            
        }

        protected void DropDownList1IdProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ID_Profe"] = DropDownList1IdProfesor.SelectedValue.ToString();
        }

        protected void DropDownListMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ID_Dr"] = DropDownListMedico.SelectedValue.ToString();
        }
    }
}