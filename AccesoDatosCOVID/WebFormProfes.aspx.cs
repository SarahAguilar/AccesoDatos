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
	public partial class WebFormProfes : System.Web.UI.Page
	{
		LN bl = null;
		string idProfe = null;
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
		}

		public void mostrarSeleccion()
		{
			string msj = "";
			GridView1.DataSource = bl.InfoProfe(ref msj, idProfe);
			GridView1.DataBind();
		}
	}
}