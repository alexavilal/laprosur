using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Logistica;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using SIGA.DAO.Comunes;

namespace SIGA.DAO.Logistica
{
   public class ProveedorDao
    {
       private Conexion Conection = new Conexion();

       public int RegistrarProveedor(Proveedor request,  List<ProveedorMarca> ListaProveedorMarca)
       {
           int DocumentoGenerado = 0;
            
           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               con.Open();
               using (IDbTransaction tran = con.BeginTransaction())
               {
                   try
                   {
                       using (SqlCommand cmd = new SqlCommand("USP_ProveedorInsertar", con))
                       {
                           cmd.CommandType = CommandType.StoredProcedure;
                            
                           cmd.Parameters.Add("@ProRazonSocial", SqlDbType.VarChar).Value = request.ProRazonSocial;
                           cmd.Parameters.Add("@ProNombreComercial", SqlDbType.VarChar).Value = request.ProNombreComercial;
                           cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = request.CodTipoDocumento;
                           cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = request.NumDocumento;
                           cmd.Parameters.Add("@ProPaginaWeb", SqlDbType.VarChar).Value = request.ProPaginaWeb;
                           cmd.Parameters.Add("@FecAniProveedor", SqlDbType.DateTime).Value = request.FecAniProveedor;
                           cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = request.CorreoElectronico;
                           cmd.Parameters.Add("@ProDireccion", SqlDbType.VarChar).Value = request.Direccion;
                           cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = request.UsuCreCodigo;
                           cmd.Parameters.Add("@FecCre", SqlDbType.DateTime).Value = request.FecCreacion;
                           cmd.Parameters.Add("@ProConMarca", SqlDbType.Bit).Value = request.ProConMarca;
                           cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = request.Estado;
                           
                           SqlParameter parm2 = new SqlParameter("@ProCodigo", SqlDbType.Int);
                           parm2.Size = 7;
                           parm2.Direction = ParameterDirection.Output;  
                           cmd.Parameters.Add(parm2);

                           cmd.Transaction = tran as SqlTransaction;
                           cmd.ExecuteNonQuery();

                           DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@ProCodigo"].Value);
                       }

                       if (ListaProveedorMarca != null)
                       {
                           foreach (var item in ListaProveedorMarca)
                           {
                               ProveedorMarca objProveedorMarca =  new ProveedorMarca();
                               objProveedorMarca.ProCodigo = DocumentoGenerado;
                               objProveedorMarca.CodMarca = item.CodMarca;
                               objProveedorMarca.UsuCreCodigo = item.UsuCreCodigo;
                               RegistrarProveedorMarca(objProveedorMarca);
                           }
                       }           

                       tran.Commit();
                   }

                   catch (Exception ex)
                   {
                       tran.Rollback();
                       DocumentoGenerado = 0;
                   }

               }
           }

           return DocumentoGenerado;
       }

       public int RegistrarProveedorMarca(ProveedorMarca ProveedorMarca)
       {
           int DocumentoGenerado = 0;

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               con.Open();
                
                   try
                   {
                       if (ProveedorMarca != null)
                       {                            
                            using (SqlCommand cmd = new SqlCommand("USP_ProveedorMarcaInsertar", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = ProveedorMarca.ProCodigo;
                                cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = ProveedorMarca.CodMarca;
                                cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = ProveedorMarca.UsuCreCodigo;
                                SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                                parm2.Size = 7;
                                parm2.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(parm2);                                   
                                cmd.ExecuteNonQuery();

                                DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                            }                            
                       }                        
                   }

                   catch (Exception ex)
                   {                      
                       DocumentoGenerado = 0;
                   } 
           }

           return DocumentoGenerado;
       }
       
       public int RegistrarProveedorContacto(List<ProveedorContacto> ListaProveedorContacto)
       {
           int DocumentoGenerado = 0;
            
           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               con.Open();
               using (IDbTransaction tran = con.BeginTransaction())
               {
                   try
                   {
                       if (ListaProveedorContacto != null)
                       {
                           foreach (var item in ListaProveedorContacto)
                           {
                                ProveedorContacto objProveedorContacto = new ProveedorContacto();
                                objProveedorContacto.ProCodigo=item.ProCodigo;
                                objProveedorContacto.NomProveedorContacto=item.NomProveedorContacto;
                                objProveedorContacto.CarProveedorContacto=item.CarProveedorContacto;
                                objProveedorContacto.AreProveedorContacto=item.AreProveedorContacto;
                                objProveedorContacto.CodOperador=item.CodOperador;
                                objProveedorContacto.NumTelProveedorContacto=item.NumTelProveedorContacto;                                
                                objProveedorContacto.UsuCreCodigo=item.UsuCreCodigo;
                                objProveedorContacto.CorreoElectronico = item.CorreoElectronico;
                                objProveedorContacto.UsuCreCodigo = item.UsuCreCodigo;
                                DocumentoGenerado = RegistrarProveedorContactoUnico(objProveedorContacto);
                           }
                       }

                       tran.Commit();
                   }

                   catch (Exception ex)
                   {
                       tran.Rollback();
                       DocumentoGenerado = 0;
                   }
               }
           }

           return DocumentoGenerado;
       }


       public int RegistrarProveedorContactoUnico(ProveedorContacto ProveedorContacto)
       {
           int DocumentoGenerado = 0;

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               con.Open();
               using (IDbTransaction tran = con.BeginTransaction())
               {
                   try
                   {
                       if (ProveedorContacto != null)
                       {                           
                            using (SqlCommand cmd = new SqlCommand("USP_ProveedorContactoInsertar", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = ProveedorContacto.ProCodigo;
                                cmd.Parameters.Add("@NomProveedorContacto", SqlDbType.VarChar).Value = ProveedorContacto.NomProveedorContacto;
                                cmd.Parameters.Add("@CarProveedorContacto", SqlDbType.VarChar).Value = ProveedorContacto.CarProveedorContacto;
                                cmd.Parameters.Add("@AreProveedorContacto", SqlDbType.VarChar).Value = ProveedorContacto.AreProveedorContacto;
                                cmd.Parameters.Add("@CodOperador", SqlDbType.SmallInt).Value = ProveedorContacto.CodOperador;
                                cmd.Parameters.Add("@NumTelProveedorContacto", SqlDbType.VarChar).Value = ProveedorContacto.NumTelProveedorContacto;
                                cmd.Parameters.Add("@UsuCreCodigo", SqlDbType.SmallInt).Value = ProveedorContacto.UsuCreCodigo;
                                cmd.Parameters.Add("@CorreProveedorContacto", SqlDbType.VarChar,50).Value = ProveedorContacto.CorreoElectronico;
                                SqlParameter parm2 = new SqlParameter("@Resultado", SqlDbType.Int);
                                
                                parm2.Size = 7;
                                parm2.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(parm2);

                                cmd.Transaction = tran as SqlTransaction;
                                cmd.ExecuteNonQuery();

                                DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                            }                            
                       }

                       tran.Commit();
                   }
                   catch (Exception ex)
                   {
                       tran.Rollback();
                       DocumentoGenerado = 0;
                   }
               }
           }

           return DocumentoGenerado;
       }



       public List<Proveedor> BuscarPorCriterios(string strRazonSocial,string strNombreComercial,Int16 TipoDocumento,string strNumeroDocumento)
       {

           var listResult = new List<Proveedor>();
           string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

           //string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";

          using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               using (SqlCommand cmd = new SqlCommand("USP_ProveedorBuscar", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;


                   cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = strRazonSocial;
                   cmd.Parameters.Add("@NombreComercial", SqlDbType.VarChar).Value = strNombreComercial;
                   cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = TipoDocumento;
                   cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = strNumeroDocumento;

                   con.Open();

                   using (SqlDataReader dr = cmd.ExecuteReader())
                   {
                       while (dr.Read())
                       {

                           var ItemResult = new Proveedor();
                           ItemResult.ProCodigo = Convert.ToInt32(dr.GetValue(0));
                           ItemResult.ProRazonSocial = Convert.ToString(dr.GetValue(1));
                           ItemResult.ProNombreComercial = Convert.ToString(dr.GetValue(2));
                           ItemResult.CodTipoDocumento = 1;
                           ItemResult.NumDocumento = Convert.ToString(dr.GetValue(4));

                           ItemResult.ProPaginaWeb = Convert.ToString(dr.GetValue(5));
                           ItemResult.CorreoElectronico = "micorreo@hotmail.com";


                           listResult.Add(ItemResult);
                       }
                   }
               }
           }

           return listResult;
       }

       public DataTable BuscarPorCriterioDT(string strRazonSocial,string strNombreComercial,Int16 TipoDocumento,string strNumeroDocumento,string Marca)
       {
           DataTable dt = new DataTable();


           string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";


          using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               using (SqlCommand cmd = new SqlCommand("USP_ProveedorBuscarDT", con))
               {

                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = strRazonSocial;
                   cmd.Parameters.Add("@NombreComercial", SqlDbType.VarChar).Value = strNombreComercial;
                   cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = TipoDocumento;
                   cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = strNumeroDocumento;
                   cmd.Parameters.Add("@Marca", SqlDbType.VarChar).Value = Marca;



                   con.Open();
                   dt.Load(cmd.ExecuteReader());

               }
           }

           return dt;

       }


       public List<Proveedor> ListarProveedores(Proveedor objProveedor)
       {

           var listResult = new List<Proveedor>();
           
           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               using (SqlCommand cmd = new SqlCommand("USP_LISTAR_PROVEEDORES", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@ProRazonSocial", SqlDbType.VarChar).Value = objProveedor.ProRazonSocial;
                   cmd.Parameters.Add("@ProNombreComercial", SqlDbType.VarChar).Value = objProveedor.ProNombreComercial;
                   cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = objProveedor.CodTipoDocumento;
                   cmd.Parameters.Add("@EstCodigo", SqlDbType.VarChar).Value = objProveedor.Estado;
                   cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = objProveedor.NumDocumento;
                   
                   con.Open();

                   using (SqlDataReader dr = cmd.ExecuteReader())
                   {
                       while (dr.Read())
                       {

                           var ItemResult = new Proveedor();
                           ItemResult.ProCodigo = Convert.ToInt32(dr.GetValue(0));
                           ItemResult.ProRazonSocial = Convert.ToString(dr.GetValue(1));
                           ItemResult.ProNombreComercial = Convert.ToString(dr.GetValue(2));
                           ItemResult.TipoDocumento = Convert.ToString(dr.GetValue(3));  
                           ItemResult.NumDocumento = Convert.ToString(dr.GetValue(4));
                           ItemResult.Estado = Convert.ToString(dr.GetValue(5));                   

                           listResult.Add(ItemResult);
                       }
                   }
               }
           }

           return listResult;
       }



       public Proveedor ObtenerProveedor(Proveedor objProveedor)
       {
           var ItemResult = new Proveedor();

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               using (SqlCommand cmd = new SqlCommand("USP_ObtenerProveedor", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = objProveedor.ProCodigo;
                 
                   con.Open();

                   using (SqlDataReader dr = cmd.ExecuteReader())
                   {
                       if (dr.Read())
                       {                            
                           ItemResult.ProCodigo = Convert.ToInt32(dr.GetValue(0));
                           ItemResult.ProRazonSocial = Convert.ToString(dr.GetValue(1));
                           ItemResult.ProNombreComercial = Convert.ToString(dr.GetValue(2));
                           ItemResult.CodTipoDocumento = Convert.ToInt16(dr.GetValue(3));
                           ItemResult.NumDocumento = Convert.ToString(dr.GetValue(4));
                           ItemResult.ProPaginaWeb = Convert.ToString(dr.GetValue(5));
                           ItemResult.FecAniProveedor = Convert.ToDateTime(dr.GetValue(6));
                           ItemResult.CorreoElectronico = Convert.ToString(dr.GetValue(7));
                           ItemResult.Estado = Convert.ToString(dr.GetValue(8));
                           ItemResult.ProConMarca = Convert.ToByte(dr.GetValue(9));
                           ItemResult.Direccion = Convert.ToString(dr.GetValue(10));
                       }
                   }
               }
           }

           return ItemResult;
       }


       public List<ProveedorMarca> ObtenerProveedorMarca(ProveedorMarca objProveedor)
       {

           var listResult = new List<ProveedorMarca>();

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {    
                /*
               using (SqlCommand cmd = new SqlCommand("USP_ObtenerProveedorMarca", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = objProveedor.ProCodigo;

                   con.Open();

                   using (SqlDataReader dr = cmd.ExecuteReader())
                   {
                       while (dr.Read())
                       {

                           var ItemResult = new ProveedorMarca();
                           ItemResult.CodMarca = Convert.ToInt16(dr.GetValue(0));
                           ItemResult.Marca = Convert.ToString(dr.GetValue(1));
                        
                           listResult.Add(ItemResult);
                       }
                   }
               }*/
           }

           return listResult;
       }


       public List<ProveedorContacto> ObtenerProveedorContacto(ProveedorContacto objProveedor)
       {
           var listResult = new List<ProveedorContacto>();

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               using (SqlCommand cmd = new SqlCommand("USP_ObtenerProveedorContacto", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = objProveedor.ProCodigo;

                   con.Open();

                   using (SqlDataReader dr = cmd.ExecuteReader())
                   {
                       while (dr.Read())
                       {
                           var ItemResult = new ProveedorContacto();
                           ItemResult.CodProveedorContacto = Convert.ToInt16(dr.GetValue(0));
                           ItemResult.ProCodigo = Convert.ToInt32(dr.GetValue(1));
                           ItemResult.NomProveedorContacto = Convert.ToString(dr.GetValue(2));
                           ItemResult.CarProveedorContacto = Convert.ToString(dr.GetValue(3));
                           ItemResult.AreProveedorContacto = Convert.ToString(dr.GetValue(4));
                           ItemResult.CodOperador = Convert.ToInt16(dr.GetValue(5));
                           ItemResult.NumTelProveedorContacto = Convert.ToString(dr.GetValue(6));
                           ItemResult.Operador = Convert.ToString(dr.GetValue(7));
                           ItemResult.CorreoElectronico = Convert.ToString(dr.GetValue(8));
                           listResult.Add(ItemResult);
                       }
                   }
               }
           }

           return listResult;
       }



       public int ActualizarProveedor(Proveedor request, List<ProveedorMarca> ListaProveedorMarca, List<ProveedorContacto> ListaProveedorContacto)
       {
           int DocumentoGenerado = 0;

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               con.Open();
               using (IDbTransaction tran = con.BeginTransaction())
               {
                   try
                   {
                       using (SqlCommand cmd = new SqlCommand("USP_ProveedorActualizar", con))
                       {
                           cmd.CommandType = CommandType.StoredProcedure;
                           cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = request.ProCodigo;
                           cmd.Parameters.Add("@ProRazonSocial", SqlDbType.VarChar).Value = request.ProRazonSocial;
                           cmd.Parameters.Add("@ProNombreComercial", SqlDbType.VarChar).Value = request.ProNombreComercial;
                           cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = request.CodTipoDocumento;
                           cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value = request.NumDocumento;
                           cmd.Parameters.Add("@ProPaginaWeb", SqlDbType.VarChar).Value = request.ProPaginaWeb;
                           cmd.Parameters.Add("@FecAniProveedor", SqlDbType.DateTime).Value = request.FecAniProveedor;
                           cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = request.CorreoElectronico;
                           cmd.Parameters.Add("@UsuModCodigo", SqlDbType.SmallInt).Value = request.UsuCreCodigo;                        
                           cmd.Parameters.Add("@ProConMarca", SqlDbType.Bit).Value = request.ProConMarca;
                           cmd.Parameters.Add("@ProDireccion", SqlDbType.VarChar).Value = request.Direccion;

                           cmd.Parameters.Add("@EstCodigo", SqlDbType.Char).Value = request.Estado;

                           SqlParameter parm2 = new SqlParameter("@RESULTADO", SqlDbType.Int);
                           parm2.Size = 7;
                           parm2.Direction = ParameterDirection.Output;
                           cmd.Parameters.Add(parm2);

                           cmd.Transaction = tran as SqlTransaction;
                           cmd.ExecuteNonQuery();

                           DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                       }

                       if (ListaProveedorMarca != null)
                       {
                           foreach (var item in ListaProveedorMarca)
                           {
                               var objProveedorMarca = new ProveedorMarca();
                               objProveedorMarca.ProCodigo = request.ProCodigo;
                               objProveedorMarca.CodMarca = item.CodMarca; 
                               objProveedorMarca.UsuCreCodigo = item.UsuCreCodigo;

                               var consultarExiste = ObtenerProveedorMarcaPorCodigo(objProveedorMarca);
                               if (consultarExiste.Equals(0))
                               {                                   
                                   RegistrarProveedorMarca(objProveedorMarca);              
                               }
                           }
                       }

                       if (ListaProveedorContacto != null)
                       {
                           foreach (var item in ListaProveedorContacto)
                           { 
                               ProveedorContacto objProveedorContacto = new ProveedorContacto();
                               objProveedorContacto.CodProveedorContacto = item.CodProveedorContacto;
                               objProveedorContacto.ProCodigo = request.ProCodigo;
                               objProveedorContacto.NomProveedorContacto = item.NomProveedorContacto;
                               objProveedorContacto.CarProveedorContacto = item.CarProveedorContacto;
                               objProveedorContacto.AreProveedorContacto = item.AreProveedorContacto;
                               objProveedorContacto.CodOperador = item.CodOperador;
                               objProveedorContacto.NumTelProveedorContacto = item.NumTelProveedorContacto;
                               objProveedorContacto.CorreoElectronico = item.CorreoElectronico;
                               objProveedorContacto.UsuCreCodigo = item.UsuCreCodigo;

                               var consultarExiste = ObtenerProveedorContactoPorCodigo(objProveedorContacto);
                               if (consultarExiste.Equals(0))
                               {
                                   RegistrarProveedorContactoUnico(objProveedorContacto);
                               }                               
                           }
                       }
                        

                       tran.Commit();
                   }

                   catch (Exception ex)
                   {
                       tran.Rollback();
                       DocumentoGenerado = 0;
                   }

               }
           }

           return DocumentoGenerado;
       }



       public int ObtenerProveedorMarcaPorCodigo(ProveedorMarca objProveedor)
       {
           int ItemResult =0;

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               using (SqlCommand cmd = new SqlCommand("USP_ProveedorMarcaPorCodigo", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = objProveedor.ProCodigo;
                   cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = objProveedor.CodMarca;
                   con.Open();

                   using (SqlDataReader dr = cmd.ExecuteReader())
                   {
                       if (dr.Read())
                       {
                           ItemResult = Convert.ToInt16(dr.GetValue(0));                           
                       }
                   }
               }
           }

           return ItemResult;
       }

       public int ObtenerProveedorContactoPorCodigo(ProveedorContacto objProveedor)
       {
           int ItemResult = 0;

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               using (SqlCommand cmd = new SqlCommand("USP_ProveedorContactoPorCodigo", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@CodProveedorContacto", SqlDbType.Int).Value = objProveedor.CodProveedorContacto;
                
                   con.Open();

                   using (SqlDataReader dr = cmd.ExecuteReader())
                   {
                       if (dr.Read())
                       {
                           ItemResult = Convert.ToInt16(dr.GetValue(0));
                       }
                   }
               }
           }

           return ItemResult;
       }


       public int EliminarProveedorMarca (ProveedorMarca objProveedor)
       {
           int DocumentoGenerado = 0;

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               con.Open();

               using (SqlCommand cmd = new SqlCommand("USP_ProveedorMarcaEliminar", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = objProveedor.ProCodigo;
                   cmd.Parameters.Add("@CodMarca", SqlDbType.SmallInt).Value = objProveedor.CodMarca; 
                   SqlParameter parm2 = new SqlParameter("@RESULTADO", SqlDbType.Int);
                   parm2.Size = 7;
                   parm2.Direction = ParameterDirection.Output;
                   cmd.Parameters.Add(parm2); 

                   cmd.ExecuteNonQuery();

                   DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
               }
           }

           return DocumentoGenerado;
       }


       public int EliminarProveedorContacto(ProveedorContacto objProveedorContacto)
       {
           int DocumentoGenerado = 0;

           using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               con.Open();

               using (SqlCommand cmd = new SqlCommand("USP_ProveedorContactoEliminar", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@ProCodigo", SqlDbType.Int).Value = objProveedorContacto.ProCodigo;
                   cmd.Parameters.Add("@CodProveedorContacto", SqlDbType.Int).Value = objProveedorContacto.CodProveedorContacto;
                
                   SqlParameter parm2 = new SqlParameter("@RESULTADO", SqlDbType.Int);
                   parm2.Size = 7;
                   parm2.Direction = ParameterDirection.Output;
                   cmd.Parameters.Add(parm2);

                   
                   cmd.ExecuteNonQuery();

                   DocumentoGenerado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
               }
           }

           return DocumentoGenerado;
       }



       public DataTable BuscarPorTipoDocumento(Int16 TipoDocumento, string Numero)
       {
           DataTable dt = new DataTable();


           string Connection = @"Data Source=192.168.0.4;Initial Catalog=SIGA;User id=sa;pwd=123456";


          using (SqlConnection con = new SqlConnection(Conection.cadenaConexion()))
           {
               using (SqlCommand cmd = new SqlCommand("USP_ProveedorBuscarPorDocumento", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@CodTipoDocumento", SqlDbType.TinyInt).Value = TipoDocumento;
                   cmd.Parameters.Add("@NumDocumento", SqlDbType.VarChar).Value =Numero;
                   con.Open();
                   dt.Load(cmd.ExecuteReader());

               }
           }

           return dt;
       }
      
   }
}
