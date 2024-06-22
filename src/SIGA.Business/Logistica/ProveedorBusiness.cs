using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System.Data;
namespace SIGA.Business.Logistica
{
    public class ProveedorBusiness
    {

        public bool BuscarPorTipoDocumento(Int16 TipoDocumento, string Numero)
        {

            bool Encontro = false;


            ProveedorDao _GeneralRepository = new ProveedorDao();

            var result = _GeneralRepository.BuscarPorTipoDocumento(TipoDocumento, Numero);

            Encontro = (Convert.ToInt32(result.Rows[0][0]) > 0) ? true : false;

            return Encontro;

        }

        public int RegistrarProveedor(Proveedor request, List<ProveedorMarca> ListaProveedorMarca)
        {
            int Codigo = 0;
            ProveedorDao _GeneralRepository = new ProveedorDao();
            Codigo = _GeneralRepository.RegistrarProveedor(request, ListaProveedorMarca);
            return Codigo;
        }

        public int RegistrarProveedorContacto(List<ProveedorContacto> ListaProveedorContacto)
        {
            int Codigo = 0;
            ProveedorDao _GeneralRepository = new ProveedorDao();
            Codigo = _GeneralRepository.RegistrarProveedorContacto(ListaProveedorContacto);
            return Codigo;
        }


        public int ActualizarProveedor(Proveedor request, List<ProveedorMarca> ListaProveedorMarca, List<ProveedorContacto> ListaProveedorContacto)
        {
            int Codigo = 0;
            ProveedorDao _GeneralRepository = new ProveedorDao();
            Codigo = _GeneralRepository.ActualizarProveedor(request, ListaProveedorMarca, ListaProveedorContacto);
            return Codigo;

        }

        public Proveedor ObtenerProveedor(Proveedor objProveedor)
        {
            ProveedorDao _GeneralRepository = new ProveedorDao();
            return _GeneralRepository.ObtenerProveedor(objProveedor);
        }

        public List<ProveedorMarca> ObtenerProveedorMarca(ProveedorMarca objProveedor)
        {
            ProveedorDao _GeneralRepository = new ProveedorDao();
            return _GeneralRepository.ObtenerProveedorMarca(objProveedor);
        }

        public List<ProveedorContacto> ObtenerProveedorContacto(ProveedorContacto objProveedor)
        {
            ProveedorDao _GeneralRepository = new ProveedorDao();
            return _GeneralRepository.ObtenerProveedorContacto(objProveedor);
        }


        public List<Proveedor> BuscarPorCriterios(string strRazonSocial, string strNombreComercial, Int16 TipoDocumento, string strNumeroDocumento)
        {

            ProveedorDao _GeneralRepository = new ProveedorDao();
            var result = _GeneralRepository.BuscarPorCriterios(strRazonSocial, strNombreComercial, TipoDocumento, strNumeroDocumento);

            return result;
        }



        public DataTable BuscarPorCriteriosDT(string strRazonSocial, string strNombreComercial, Int16 TipoDocumento, string strNumeroDocumento,string Marca)
        {

            ProveedorDao _GeneralRepository = new ProveedorDao();
            var result = _GeneralRepository.BuscarPorCriterioDT(strRazonSocial, strNombreComercial, TipoDocumento, strNumeroDocumento,Marca);

            return result;
        }

        public List<Proveedor> ListarProveedores(Proveedor objProveedor)
        {
            ProveedorDao _GeneralRepository = new ProveedorDao();
            return _GeneralRepository.ListarProveedores(objProveedor);
        }


        public int EliminarProveedorMarca(ProveedorMarca objProveedor)
        {
            int Codigo = 0;
            ProveedorDao _GeneralRepository = new ProveedorDao();
            Codigo = _GeneralRepository.EliminarProveedorMarca(objProveedor);
            return Codigo;
        }
        public int EliminarProveedorContacto(ProveedorContacto objProveedorContacto)
        {
            int Codigo = 0;
            ProveedorDao _GeneralRepository = new ProveedorDao();
            Codigo = _GeneralRepository.EliminarProveedorContacto(objProveedorContacto);
            return Codigo;
        }

    }
}
