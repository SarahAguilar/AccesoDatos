using System;
using System.Collections.Generic;
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

        public LN(string cdn)
        {
            conexion = cdn;
            acceso = new ClassAccSQL(cdn);
        }
        public string Open()
        {
            string msj = "";
            acceso.AbrirConexion(ref msj);
            return msj;
        }
            
    }
}
