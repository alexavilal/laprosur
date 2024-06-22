using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SIGA.DAO.Comunes
{
    public class Conexion
    {
        public string cadenaConexion()
        {

            return ConfigurationManager.ConnectionStrings["Conexion"].ToString();

         //return @"Data Source=L-TIC08\SQLEXPRESS;Initial Catalog=dbLaProSur;User id=sa;pwd=123456";


        }
    }
}
