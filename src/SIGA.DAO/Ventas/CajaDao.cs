using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SIGA.DAO.Comunes;

namespace SIGA.DAO.Ventas
{
    public class CajaDao
    {
        private Conexion Conection = new Conexion();

        //public int RegistroCaja(CajaRequest request)
        //{
        //    int DocumentoGenerado = 0;
        //    string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
        //    //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
        //    string NumPedido = string.Empty;
        //    using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
        //    {
        //        con.Open();
        //        using (IDbTransaction tran = con.BeginTransaction())
        //        {
        //            try
        //            {
        //                using (SqlCommand cmd = new SqlCommand("USP_CajaInsertar", con))
        //                {
        //                    cmd.CommandType = CommandType.StoredProcedure;


        //                    cmd.Parameters.Add("@CodSede", SqlDbType.TinyInt).Value = request.CodSede;

        //                    cmd.Parameters.Add("@FecCaja", SqlDbType.VarChar, 8).Value = request.FecCaja.ToString("yyyyMMdd");

        //                    cmd.Parameters.Add("@CodEstadoCaja", SqlDbType.TinyInt).Value = request.CodEstadoCaja;

        //                    cmd.Parameters.Add("@CodMonedaSoles", SqlDbType.TinyInt).Value = 1;
        //                    cmd.Parameters.Add("@MontoSoles", SqlDbType.Decimal).Value = request.MontoSoles;

        //                    cmd.Parameters.Add("@CodMonedaDolares", SqlDbType.TinyInt).Value = 2;
        //                    cmd.Parameters.Add("@MontoDolares", SqlDbType.Decimal).Value = request.MontoDolares;

        //                    cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = request.UsuCodigo;
        //                    cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = request.EstCodigo;
        //                    cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = request.UsuCreCodigo;
        //                    cmd.Parameters.Add("@CodTipoCaja", SqlDbType.TinyInt).Value = request.CodTipoCaja;



        //                    SqlParameter parm2 = new SqlParameter("@CodCaja", SqlDbType.Int);
        //                    parm2.Size = 7;
        //                    parm2.Direction = ParameterDirection.Output; // This is important!
        //                    cmd.Parameters.Add(parm2);

        //                    cmd.Transaction = tran as SqlTransaction;
        //                    cmd.ExecuteNonQuery();




        //                    DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@CodCaja"].Value);

        //                }

        //                tran.Commit();
        //            }

        //            catch (Exception ex)
        //            {
        //                tran.Rollback();

        //            }



        //        }
        //    }

        //    return DocumentoGenerado;

        //}


        public DataTable ConsultarSaldo(int Codigo)
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_SaldoCajaCOnsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodCaja", SqlDbType.Int).Value = Codigo;

                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }



        public DataTable MovimientoCaja(int Codigo, string TipoDocumento, string Cliente, string Numero)
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_MovimientosCaja", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodCaja", SqlDbType.Int).Value = Codigo;
                    cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.Char).Value = TipoDocumento;
                    cmd.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = Cliente;
                    cmd.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero;
                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }

        public DataTable ConsultarCajas(DateTime Del, DateTime Al)
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_CajaConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FecInicio", SqlDbType.VarChar, 8).Value = Del.ToString("yyyyMMdd");
                    cmd.Parameters.Add("@FecFin", SqlDbType.VarChar, 8).Value = Al.ToString("yyyyMMdd");
                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }


        public DataTable ConsultarCajaPorCodigo(int Codigo)
        {
            DataTable dt = new DataTable();


           

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_CajaConsultarPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodCaja", SqlDbType.Int).Value = Codigo;
                   
                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }

        public DataTable ConsultarCajasActivas(int CodigoUsuario,string Fecha,int TipoCaja)
        {
            DataTable dt = new DataTable();




            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_CantidadCajaActiva", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UsuCodigo", SqlDbType.Int).Value = CodigoUsuario;
                    cmd.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Fecha;
                    cmd.Parameters.Add("@TipoCaja", SqlDbType.Int).Value = TipoCaja;


                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }

        public DataTable ConsultarCajasAdministrativaActiva(int CodSede,string Fecha)
        {
            DataTable dt = new DataTable();




            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ConsultarCajaAdministrativaActiva", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Fecha", SqlDbType.VarChar).Value = Fecha;
                    cmd.Parameters.Add("@CodSede", SqlDbType.Int).Value = CodSede;
                    con.Open();
                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }
    }
}
