using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Logistica;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using SIGA.Entities.Ventas;
using SIGA.DAO.Comunes;

namespace SIGA.DAO.Logistica
{
    public class GeneralDao
    {
        private Conexion Conection = new Conexion();

        public int Actualizar(General request)
        {
            int DocumentoGenerado = 0;
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            string NumPedido = string.Empty;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_ActualizarGeneral", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = request.CodGeneral;
                            cmd.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = request.CodEmpresa;
                            cmd.Parameters.Add("@CodTipoCodigo", SqlDbType.TinyInt).Value = request.CodTipoCodigo;
                            cmd.Parameters.Add("@IndCodigoBarra ", SqlDbType.Bit).Value = request.IndCodigoBarra;
                            cmd.Parameters.Add("@CodBarra", SqlDbType.VarChar).Value = request.CodBarra;
                            cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = request.CodMarca;
                            cmd.Parameters.Add("@CodMaterial", SqlDbType.SmallInt).Value = request.CodMaterial;
                            cmd.Parameters.Add("@CodFamilia", SqlDbType.Int).Value = request.CodFamilia;
                            cmd.Parameters.Add("@CodSubFamilia", SqlDbType.Int).Value = request.CodSubFamilia;
                            cmd.Parameters.Add("@CodExtGeneral", SqlDbType.VarChar).Value = request.CodExtGeneral;
                            cmd.Parameters.Add("@DesLarGeneral", SqlDbType.VarChar).Value = request.DesLarGeneral;
                            cmd.Parameters.Add("@DesCorGeneral", SqlDbType.VarChar).Value = request.DesCorGeneral;
                            cmd.Parameters.Add("@CodForma", SqlDbType.TinyInt).Value = request.CodForma;
                            cmd.Parameters.Add("@CodColor", SqlDbType.SmallInt).Value = request.CodColor;
                            cmd.Parameters.Add("@CodCapacidad", SqlDbType.TinyInt).Value = request.CodCapacidad;
                            cmd.Parameters.Add("@AltoGeneral", SqlDbType.VarChar).Value = request.AltoGeneral;
                            cmd.Parameters.Add("@Largoeneral", SqlDbType.VarChar).Value = request.LargoGeneral;
                            cmd.Parameters.Add("@AnchoGeneral", SqlDbType.VarChar).Value = request.AnchoGeneral;
                            cmd.Parameters.Add("@Cicuferenciageneral", SqlDbType.VarChar).Value = request.Cicuferenciageneral;
                            cmd.Parameters.Add("@EmpGeneral", SqlDbType.Decimal).Value = request.Empaque;
                            cmd.Parameters.Add("@CodUnidadMedidad", SqlDbType.TinyInt).Value = request.CodUnidadMedida;
                            cmd.Parameters.Add("@CodEmpaque", SqlDbType.TinyInt).Value = request.CodEmpaque;
                            cmd.Parameters.Add("@AltoEmpaque", SqlDbType.VarChar).Value = request.AltoEmpaque;
                            cmd.Parameters.Add("@AnchoEmpaque", SqlDbType.VarChar).Value = request.AnchoEmpaque;
                            cmd.Parameters.Add("@LargoEmpaque", SqlDbType.VarChar).Value = request.LargoEmpaque;
                            cmd.Parameters.Add("@StockMininoGeneral", SqlDbType.Decimal).Value = request.StockMinimo;
                            cmd.Parameters.Add("@LeadTimeGeneral", SqlDbType.Decimal).Value = request.LeadTime;
                            cmd.Parameters.Add("@ReposicionGeneral", SqlDbType.Decimal).Value = request.Reposicion;
                            cmd.Parameters.Add("@Temporal", SqlDbType.Int).Value = request.Temporal;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = request.UsuCreCodigo;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = request.EstCodigo;
                            cmd.Parameters.Add("@CodBarra1", SqlDbType.VarChar).Value = request.Codigo1;
                            cmd.Parameters.Add("@CodBarra2", SqlDbType.VarChar).Value = request.Codigo2;
                            cmd.Parameters.Add("@CodBarra3", SqlDbType.VarChar).Value = request.Codigo3;
                            cmd.Parameters.Add("@CodBarra4", SqlDbType.VarChar).Value = request.Codigo4;
                            cmd.Parameters.Add("@CodBarra5", SqlDbType.VarChar).Value = request.Codigo5;
                            cmd.Parameters.Add("@CodBarra6", SqlDbType.VarChar).Value = request.Codigo6;
                            cmd.Parameters.Add("@CodBarra7", SqlDbType.VarChar).Value = request.Codigo7;
                            cmd.Parameters.Add("@CodBarra8", SqlDbType.VarChar).Value = request.Codigo8;
                            cmd.Parameters.Add("@CodBarra9", SqlDbType.VarChar).Value = request.Codigo9;
                            cmd.Parameters.Add("@CodBarra10", SqlDbType.VarChar).Value = request.Codigo10;
                            cmd.Parameters.Add("@CodZurece", SqlDbType.VarChar).Value = request.CodigoZurece;
                            cmd.Parameters.Add("@CodClasificacion", SqlDbType.SmallInt).Value = request.CodGeneralClasificacion;
                            cmd.Parameters.Add("@CodSeccion", SqlDbType.SmallInt).Value = request.CodSeccion;
                            cmd.Parameters.Add("@FlagVenta", SqlDbType.Bit).Value = request.FlagVenta;


                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();


                        }

                        tran.Commit();
                    }

                    catch (Exception ex)
                    {
                        tran.Rollback();

                    }



                }
            }

            return DocumentoGenerado;

        }

        public DataTable ConsultarMantenimiento(short CodigoEmpresa, short CodigoMarca, short CodigoMaterial, short CodigoFamilia, short CodigoSubFamilia, short CodigoColor, short CodigoCapacidad, short CodigoForma, short CodigoUnidad, short CodigoEmpaque, string Descripcion, string Estado, short CodigoClasificacion, string CodigoExterno, int CodigoSeccion,string Ventas)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.Conection.cadenaConexion()))
            {
                using (SqlCommand sqlCommand = new SqlCommand("USP_GeneralBuscarPorCriteriosTodos", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@CodEmpresa", SqlDbType.SmallInt).Value = (object)CodigoEmpresa;
                    sqlCommand.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = (object)CodigoMarca;
                    sqlCommand.Parameters.Add("@CodMaterial", SqlDbType.SmallInt).Value = (object)CodigoMaterial;
                    sqlCommand.Parameters.Add("@CodFamilia", SqlDbType.SmallInt).Value = (object)CodigoFamilia;
                    sqlCommand.Parameters.Add("@CodSubFamilia ", SqlDbType.SmallInt).Value = (object)CodigoSubFamilia;
                    sqlCommand.Parameters.Add("@CodColor", SqlDbType.SmallInt).Value = (object)CodigoColor;
                    sqlCommand.Parameters.Add("@CodCapacidad", SqlDbType.SmallInt).Value = (object)CodigoCapacidad;
                    sqlCommand.Parameters.Add("@CodForma", SqlDbType.SmallInt).Value = (object)CodigoForma;
                    sqlCommand.Parameters.Add("@CodUnidadMedidad", SqlDbType.SmallInt).Value = (object)CodigoUnidad;
                    sqlCommand.Parameters.Add("@CodEmpaque", SqlDbType.SmallInt).Value = (object)CodigoEmpaque;
                    sqlCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = (object)Descripcion;
                    sqlCommand.Parameters.Add("@CodBarra", SqlDbType.VarChar).Value = (object)Descripcion;
                    sqlCommand.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = (object)Estado;
                    sqlCommand.Parameters.Add("@CodClasificacion", SqlDbType.SmallInt).Value = (object)CodigoClasificacion;
                    sqlCommand.Parameters.Add("@CodigoExterno", SqlDbType.VarChar).Value = (object)CodigoExterno;
                    sqlCommand.Parameters.Add("@CodSeccion", SqlDbType.Int).Value = (object)CodigoSeccion;
                    sqlCommand.Parameters.Add("@FlagVentas", SqlDbType.VarChar).Value = (object)Ventas;

                    connection.Open();
                    dataTable.Load((IDataReader)sqlCommand.ExecuteReader());
                }
            }
            return dataTable;
        }


        public DataTable ConsultarParaKardex(int CodigoMarca, string Codigo, string Descripcion)
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_GeneralBuscar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodMarca", SqlDbType.Int).Value = CodigoMarca;
                    cmd.Parameters.Add("@CodExterno", SqlDbType.VarChar).Value = Codigo;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;


                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;


        }

        public DataTable PrecioConsultaDatosPorCodigo(int Codigo)
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_GeneralPreciosConsultar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = Codigo;

                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }

        public DataTable PrecioConsultaPorCodigo(int Codigo)
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_PreciosCosto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = Codigo;

                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }

        public DataTable PrecioConsulta(Int16 CodigoEmpresa, Int16 CodigoMarca, string Codigo, string Descripcion)
        {
            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_GeneralConsultarPreciosCosto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodEmpresa", SqlDbType.SmallInt).Value = CodigoEmpresa;
                    cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = CodigoMarca;

                    cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigo;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;


                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;

        }
        public int Registrar(General request, ref string CodigoArticulo)
        //public int Registrar(General request)
        {
            int DocumentoGenerado = 0;


            string NumPedido = string.Empty;
            decimal Porcentaje = 0;


            SIGA.DAO.Logistica.FamiliaDao objFamilia = new SIGA.DAO.Logistica.FamiliaDao();
            SIGA.Entities.Logistica.Familia entFamilia = new SIGA.Entities.Logistica.Familia()
            {
                CodFamilia = Convert.ToInt16(request.CodFamilia)
            };



            var ResultFamilia = objFamilia.ObtenerFamiliaPorCodigo(entFamilia);

            if (ResultFamilia != null)
            {
                //Porcentaje = ResultFamilia.Porcentaje;
            }


            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();

                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_GeneralInsertarLogistica", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@CodEmpresa", SqlDbType.TinyInt).Value = request.CodEmpresa;
                            cmd.Parameters.Add("@CodTipoCodigo", SqlDbType.TinyInt).Value = request.CodTipoCodigo;
                            cmd.Parameters.Add("@IndCodigoBarra ", SqlDbType.Bit).Value = request.IndCodigoBarra;
                            cmd.Parameters.Add("@CodBarra", SqlDbType.VarChar).Value = request.CodBarra;
                            cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = request.CodMarca;
                            cmd.Parameters.Add("@CodMaterial", SqlDbType.SmallInt).Value = request.CodMaterial;
                            cmd.Parameters.Add("@CodFamilia", SqlDbType.Int).Value = request.CodFamilia;
                            cmd.Parameters.Add("@CodSubFamilia", SqlDbType.Int).Value = request.CodSubFamilia;
                            cmd.Parameters.Add("@CodExtGeneral", SqlDbType.VarChar).Value = request.CodExtGeneral;
                            cmd.Parameters.Add("@DesLarGeneral", SqlDbType.VarChar).Value = request.DesLarGeneral;
                            cmd.Parameters.Add("@DesCorGeneral", SqlDbType.VarChar).Value = request.DesCorGeneral;
                            cmd.Parameters.Add("@CodForma", SqlDbType.TinyInt).Value = request.CodForma;
                            cmd.Parameters.Add("@CodColor", SqlDbType.SmallInt).Value = request.CodColor;
                            cmd.Parameters.Add("@CodCapacidad", SqlDbType.TinyInt).Value = request.CodCapacidad;
                            cmd.Parameters.Add("@AltoGeneral", SqlDbType.VarChar).Value = request.AltoGeneral;
                            cmd.Parameters.Add("@Largoeneral", SqlDbType.VarChar).Value = request.LargoGeneral;
                            cmd.Parameters.Add("@AnchoGeneral", SqlDbType.VarChar).Value = request.AnchoGeneral;
                            cmd.Parameters.Add("@Cicuferenciageneral", SqlDbType.VarChar).Value = request.Cicuferenciageneral;
                            cmd.Parameters.Add("@EmpGeneral", SqlDbType.Decimal).Value = request.Empaque;
                            cmd.Parameters.Add("@CodUnidadMedidad", SqlDbType.TinyInt).Value = request.CodUnidadMedida;
                            cmd.Parameters.Add("@CodEmpaque", SqlDbType.TinyInt).Value = request.CodEmpaque;
                            cmd.Parameters.Add("@AltoEmpaque", SqlDbType.VarChar).Value = request.AltoEmpaque;
                            cmd.Parameters.Add("@AnchoEmpaque", SqlDbType.VarChar).Value = request.AnchoEmpaque;
                            cmd.Parameters.Add("@LargoEmpaque", SqlDbType.VarChar).Value = request.LargoEmpaque;
                            cmd.Parameters.Add("@StockMininoGeneral", SqlDbType.Decimal).Value = request.StockMinimo;
                            cmd.Parameters.Add("@LeadTimeGeneral", SqlDbType.Decimal).Value = request.LeadTime;
                            cmd.Parameters.Add("@ReposicionGeneral", SqlDbType.Decimal).Value = request.Reposicion;
                            cmd.Parameters.Add("@Temporal", SqlDbType.Int).Value = request.Temporal;
                            cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = request.UsuCreCodigo;
                            cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = request.EstCodigo;
                            cmd.Parameters.Add("@CodBarra1", SqlDbType.VarChar).Value = request.Codigo1;
                            cmd.Parameters.Add("@CodBarra2", SqlDbType.VarChar).Value = request.Codigo2;
                            cmd.Parameters.Add("@CodBarra3", SqlDbType.VarChar).Value = request.Codigo3;
                            cmd.Parameters.Add("@CodBarra4", SqlDbType.VarChar).Value = request.Codigo4;
                            cmd.Parameters.Add("@CodBarra5", SqlDbType.VarChar).Value = request.Codigo5;
                            cmd.Parameters.Add("@CodBarra6", SqlDbType.VarChar).Value = request.Codigo6;
                            cmd.Parameters.Add("@CodBarra7", SqlDbType.VarChar).Value = request.Codigo7;
                            cmd.Parameters.Add("@CodBarra8", SqlDbType.VarChar).Value = request.Codigo8;
                            cmd.Parameters.Add("@CodBarra9", SqlDbType.VarChar).Value = request.Codigo9;
                            cmd.Parameters.Add("@CodBarra10", SqlDbType.VarChar).Value = request.Codigo10;
                            cmd.Parameters.Add("@CodZurece", SqlDbType.VarChar).Value = request.CodigoZurece;
                            cmd.Parameters.Add("@CodClasificacion", SqlDbType.SmallInt).Value = request.CodGeneralClasificacion;
                            cmd.Parameters.Add("@CodSeccion", SqlDbType.SmallInt).Value = request.CodSeccion;
                            cmd.Parameters.Add("@FlagVenta", SqlDbType.Bit).Value = request.FlagVenta;

                            //cmd.Parameters.Add("@IndInafecto", SqlDbType.Int).Value = request.Inafecto;

                            SqlParameter parm2 = new SqlParameter("@CodGeneral", SqlDbType.Int);
                            parm2.Size = 7;
                            parm2.Direction = ParameterDirection.Output; // This is important!
                            cmd.Parameters.Add(parm2);

                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();

                            DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@CodGeneral"].Value);
                            //CodigoArticulo = Convert.ToString(cmd.Parameters["@CodExtGeneral"].Value);

                        }

                        //SIGA.DAO.Ventas.TipoClienteDao objTipoCliente = new SIGA.DAO.Ventas.TipoClienteDao();
                        //var result = objTipoCliente.TipoClienteTable();
                        //Int16 CodigoTipoCliente = 0;
                        //Int16 TipoPerfil = 0;
                        //int CodigoRango = 0;

                        //List<SIGA.Entities.Seguridad.Perfil> objPerfil = new List<SIGA.Entities.Seguridad.Perfil>();

                        //objPerfil.Add(new SIGA.Entities.Seguridad.Perfil { CodPerfil = 1, });
                        //objPerfil.Add(new SIGA.Entities.Seguridad.Perfil { CodPerfil = 2 });
                        //objPerfil.Add(new SIGA.Entities.Seguridad.Perfil { CodPerfil = 3 });



                        //for (int i = 0; i < result.Rows.Count; i++)
                        //{
                        //    CodigoTipoCliente = Convert.ToInt16(result.Rows[i][0]);

                        //    foreach (var item in objPerfil)
                        //    {
                        //        TipoPerfil = item.CodPerfil;

                        //        SIGA.DAO.Ventas.RangoDao objVentas = new SIGA.DAO.Ventas.RangoDao();
                        //        var resultRango = objVentas.Listado();

                        //        foreach (var itemRango in resultRango)
                        //        {

                        //            CodigoRango = itemRango.CodRango;
                        //            SIGA.Entities.Ventas.Precio objPrecio = new SIGA.Entities.Ventas.Precio()
                        //            {
                        //                CodigoGeneral = DocumentoGenerado,
                        //                PorDcto = Porcentaje,
                        //                PorPrecio = Porcentaje,
                        //                CodigoRango = CodigoRango,
                        //                Estado = "A",
                        //                TipoCliente = CodigoTipoCliente,
                        //                TipoPerfil = TipoPerfil,
                        //                UsuarioCreacion = Convert.ToInt16(request.UsuCreCodigo)

                        //            };


                        //            bool Ejecutar = RegistroPrecioInicial(objPrecio, tran, con);

                        //        }

                        //    }


                        //}





                        tran.Commit();
                    }

                    catch (Exception ex)
                    {
                        tran.Rollback();

                    }



                }
            }

            return DocumentoGenerado;

        }


        public List<General> ConsultarPorDescripcion(string Descripcion)
        {
            var listResult = new List<General>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_GeneralConsultarPorDescripcion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new General();
                            ItemResult.CodGeneral = Convert.ToInt32(dr.GetValue(0));
                            ItemResult.CodExtGeneral = Convert.ToString(dr.GetValue(1));
                            ItemResult.DesLarGeneral = Convert.ToString(dr.GetValue(2));
                            ItemResult.DesMarca = Convert.ToString(dr.GetValue(3));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(4));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }


        public string GenerarCodigo(General request)
        {
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            string Codigo = string.Empty;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_GenerarCodigo", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("@CodMarca", SqlDbType.TinyInt).Value = request.CodMarca;
                            cmd.Parameters.Add("@CodMaterial", SqlDbType.SmallInt).Value = request.CodMaterial;
                            cmd.Parameters.Add("@CodTipoCodigo", SqlDbType.TinyInt).Value = request.CodTipoCodigo;
                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();

                            Codigo = Convert.ToString(cmd.Parameters["@Codigo"].Value);

                        }
                    }
                    catch (Exception ex)
                    {

                    }



                }
            }

            return Codigo;
        }


        public List<SIGA.Comun.Dto.GeneralDto> ConsultarPorDescripcionGeneral(string CodigoGeneral, Int16 CodigoMarca, Int16 CodigoEmpresa, string Descripcion)
        {
            var listResult = new List<SIGA.Comun.Dto.GeneralDto>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_GeneralConsultarPorCriterioGeneral", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Descripcion;
                    cmd.Parameters.Add("@CodExtGeneral", SqlDbType.VarChar, 15).Value = CodigoGeneral;
                    cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = CodigoMarca;
                    cmd.Parameters.Add("@CodEmpresa", SqlDbType.SmallInt).Value = CodigoEmpresa;


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new SIGA.Comun.Dto.GeneralDto();
                            ItemResult.Codigo = Convert.ToInt32(dr.GetValue(0));
                            ItemResult.Empresa = Convert.ToString(dr.GetValue(1));
                            ItemResult.CodigoExterno = Convert.ToString(dr.GetValue(2));
                            ItemResult.CodigoBarra = Convert.ToString(dr.GetValue(3));
                            ItemResult.Marca = Convert.ToString(dr.GetValue(4));

                            ItemResult.Descripcion = Convert.ToString(dr.GetValue(5));

                            ItemResult.Estado = Convert.ToString(dr.GetValue(6));

                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }

        public bool RegistroPrecio(Precio request)
        {

            int DocumentoGenerado = 0;
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            string NumPedido = string.Empty;
            bool Validado = false;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_PreciosInsertar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            //cmd.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = request.CodigoGeneral;
                            //cmd.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = request.TipoCliente;
                            //cmd.Parameters.Add("@CodPerfil", SqlDbType.Int).Value = request.TipoPerfil;
                            //cmd.Parameters.Add("@CodRango", SqlDbType.Int).Value = request.CodigoRango;
                            //cmd.Parameters.Add("@PorPrecio", SqlDbType.Decimal).Value = request.PorPrecio;
                            //cmd.Parameters.Add("@PorDcto", SqlDbType.Decimal).Value = request.PorDcto;
                            //cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = request.UsuarioCreacion;
                            //cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = request.Estado;
                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();
                            Validado = true;

                        }

                        tran.Commit();
                    }

                    catch (Exception ex)
                    {


                        Validado = false;
                        tran.Rollback();

                    }



                }
            }

            return Validado;

        }



        public bool RegistroPrecioInicial(Precio request, IDbTransaction tran, SqlConnection con)
        {
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            string NumPedido = string.Empty;
            bool Validado = false;


            using (SqlCommand cmd = new SqlCommand("USP_PreciosInsertar", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = request.CodigoGeneral;
                //cmd.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = request.TipoCliente;
                //cmd.Parameters.Add("@CodPerfil", SqlDbType.Int).Value = request.TipoPerfil;
                //cmd.Parameters.Add("@CodRango", SqlDbType.Int).Value = request.CodigoRango;
                //cmd.Parameters.Add("@PorPrecio", SqlDbType.Decimal).Value = request.PorPrecio;
                //cmd.Parameters.Add("@PorDcto", SqlDbType.Decimal).Value = request.PorDcto;
                //cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = request.UsuarioCreacion;
                //cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = request.Estado;
                cmd.Transaction = tran as SqlTransaction;
                cmd.ExecuteNonQuery();
                Validado = true;

            }






            return Validado;

        }




        public bool ActualizarPrecios(int CodigoGeneral, Decimal PrecioPromedio, Decimal PrecioEmpresa, Int16 CodigoUsuario)
        {


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";
            string NumPedido = string.Empty;
            bool Validado = false;
            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                con.Open();
                using (IDbTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("USP_GeneralPrecioActualizar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = CodigoGeneral;
                            cmd.Parameters.Add("@PrecioPromedio", SqlDbType.Decimal).Value = PrecioPromedio;
                            cmd.Parameters.Add("@PrecioEmpresa", SqlDbType.Decimal).Value = PrecioEmpresa;
                            cmd.Parameters.Add("@UsuCodigo", SqlDbType.SmallInt).Value = CodigoUsuario;


                            cmd.Transaction = tran as SqlTransaction;
                            cmd.ExecuteNonQuery();
                            Validado = true;

                        }

                        tran.Commit();
                    }

                    catch (Exception ex)
                    {


                        Validado = false;
                        tran.Rollback();

                    }



                }
            }

            return Validado;

        }


        public List<General> ConsultarPorDescripcionPrecio(string Descripcion, string Codigo, int CodMarca)
        {
            var listResult = new List<General>();
            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_GeneralConsultarPrecio", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodMarca", SqlDbType.Int).Value = CodMarca;
                    cmd.Parameters.Add("@CodExtGeneral", SqlDbType.VarChar).Value = Codigo;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Descripcion;


                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var ItemResult = new General();
                            ItemResult.CodGeneral = Convert.ToInt32(dr.GetValue(0));
                            ItemResult.CodExtGeneral = Convert.ToString(dr.GetValue(1));
                            ItemResult.DesLarGeneral = Convert.ToString(dr.GetValue(2));
                            ItemResult.DesMarca = Convert.ToString(dr.GetValue(3));
                            ItemResult.EstCodigo = Convert.ToString(dr.GetValue(4));
                            listResult.Add(ItemResult);
                        }
                    }
                }
            }

            return listResult;
        }



        public DataTable ConsultarGeneral(int CodigoGeneral)
        {

            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_ConsultaProductoPorCodigo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = CodigoGeneral;

                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;


        }

        public DataTable ConsultarGeneralStockPorAlmacen(int CodigoGeneral, int CodigoAlmacen)
        {

            DataTable dt = new DataTable();


            string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

            using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("USP_StockPorAlmacen", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = CodigoGeneral;

                    cmd.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = CodigoAlmacen;

                    con.Open();


                    dt.Load(cmd.ExecuteReader());

                }
            }

            return dt;


        }


        public DataTable GeneralPorProducto(int CodigoGeneral)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.Conection.cadenaConexion()))
            {
                using (SqlCommand sqlCommand = new SqlCommand("USP_EmpresasPorProducto", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@CodGeneral", SqlDbType.Int).Value = (object)CodigoGeneral;
                    connection.Open();
                    dataTable.Load((IDataReader)sqlCommand.ExecuteReader());
                }
            }
            return dataTable;
        }

        public DataTable GeneralPorEmpresa(int CodigoEmpresa, int CodigoRango)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.Conection.cadenaConexion()))
            {
                using (SqlCommand sqlCommand = new SqlCommand("USP_ProductosPorEmpresaDos", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = (object)CodigoEmpresa;
                    sqlCommand.Parameters.Add("@CodRango", SqlDbType.Int).Value = (object)CodigoRango;
                    connection.Open();
                    dataTable.Load((IDataReader)sqlCommand.ExecuteReader());
                }
            }
            return dataTable;
        }


        public DataTable ConsultarParaKardexSeccion(int CodigoMarca, string Codigo, string Descripcion, int CodigoSeccion)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.Conection.cadenaConexion()))
            {
                using (SqlCommand sqlCommand = new SqlCommand("USP_GeneralBuscarPorSECCION", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@CodMarca", SqlDbType.Int).Value = (object)CodigoMarca;
                    sqlCommand.Parameters.Add("@CodExterno", SqlDbType.VarChar).Value = (object)Codigo;
                    sqlCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = (object)Descripcion;
                    sqlCommand.Parameters.Add("@CodSeccion", SqlDbType.Int).Value = (object)CodigoSeccion;
                    connection.Open();
                    dataTable.Load((IDataReader)sqlCommand.ExecuteReader());
                }
            }
            return dataTable;
        }

    }
}