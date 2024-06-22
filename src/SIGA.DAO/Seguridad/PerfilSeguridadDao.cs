using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SIGA.DAO.Comunes;

namespace SIGA.DAO.Seguridad
{
    public class PerfilSeguridadDao
    {
        private Conexion Conection = new Conexion();

        public DataTable ConsultarMantenimiento(Int16 CodigoPerfil)
        {

            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_UsuarioPerfilConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodPerfil", SqlDbType.SmallInt).Value = Convert.ToInt16(CodigoPerfil);
                   
                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;


        }


        public DataTable ConsultarPorDescripcion(string Descripcion)
        {

            DataTable dt = new DataTable();


         
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_UsuarioPerfilConsultarDescripcion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DesPerfil ", SqlDbType.VarChar).Value = Descripcion;

                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;
        }



        public DataTable ConsultarPorPerfil(int CodigoUsuario)
        {

            DataTable dt = new DataTable();



            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_PerfilPorUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodUsuario", SqlDbType.VarChar).Value = CodigoUsuario;
                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;
        }
    }
}
