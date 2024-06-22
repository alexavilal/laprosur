using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using SIGA.Entities.Mantenimientos;
using System.Data;

namespace SIGA.Business.Ventas
{
    public class GeneralBusiness
    {

        public DataTable ConsultarPrecio(int CodigoGeneral, int Cantidad, int Perfil, int TipoCliente)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            // var lstResult = _GeneralRepository.PreciosConsultar(CodigoGeneral, Cantidad, Perfil, TipoCliente);
            var lstResult = _GeneralRepository.PreciosConsultarNew(CodigoGeneral, Cantidad);
            return lstResult;
        }


        public DataTable ConsultarPrecioNew(int CodigoGeneral, int Cantidad)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.PreciosConsultarNew(CodigoGeneral, Cantidad);
            return lstResult;
        }

        public int RegistrarPrecioNew(GeneralPrecios request)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.RegistrarPrecioNew(request);
            return lstResult;
        }
        public DataTable ConsutarDescuentosNew(int Cantidad, decimal dcto, int CodigoGeneral, int TipoCliente, int Categoria, int PerfilUsuario)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.ConsutarDescuentosNew(Cantidad, dcto, CodigoGeneral, TipoCliente, Categoria, PerfilUsuario);
            return lstResult;

        }

        public int RegistrarPrecioReposicion(GeneralPrecios request)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.RegistrarPrecioReposicion(request);
            return lstResult;
        }

        public DataTable ConsultarPrecioNew(int CodigoFamilia, int CodigoSubFamilia, int CodigoMarca, int CodigoGeneral, string CodigoExterno, string Descripcion, int CodigoEmpresa)
        {


            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.PreciosConsultarNew(CodigoFamilia, CodigoSubFamilia, CodigoMarca, CodigoGeneral, CodigoExterno, Descripcion, CodigoEmpresa);
            return lstResult;
        }


        public DataTable ConsultarPrecioNewVentas(int CodigoFamilia, int CodigoSubFamilia, int CodigoMarca, int CodigoGeneral, string CodigoExterno, string Descripcion, int CodigoEmpresa)
        {


            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.PreciosConsultarNewVentas(CodigoFamilia, CodigoSubFamilia, CodigoMarca, CodigoGeneral, CodigoExterno, Descripcion, CodigoEmpresa);
            return lstResult;
        }

        public DataTable ConsultarPrecioNewBarra(int CodigoFamilia, int CodigoSubFamilia, int CodigoMarca, int CodigoGeneral, string CodigoExterno, string Descripcion, string CodigoBarra)
        {


            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.PreciosConsultarNewBarra(CodigoFamilia, CodigoSubFamilia, CodigoMarca, CodigoGeneral, CodigoExterno, Descripcion, CodigoBarra);
            return lstResult;
        }


        public DataTable PrecioReposicionConsultar(int CodigoFamilia, int CodigoSubFamilia, int CodigoMarca, int CodigoGeneral, string CodigoExterno, string Descripcion)
        {

            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.PrecioReposicionConsultar(CodigoFamilia, CodigoSubFamilia, CodigoMarca, CodigoGeneral, CodigoExterno, Descripcion);
            return lstResult;
        }


        public GeneralResponse BuscarPorCodigoBarra(string pCodigo)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.BuscarPorCodigoBarra(pCodigo);
            return lstResult;
        }

        public GeneralResponse BuscarPorCodigoZurece(string pCodigo)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.BuscarPorCodigoZurece(pCodigo);
            return lstResult;
        }


        public GeneralResponse BuscarPrecio(int pCodigo)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.BuscarPrecio(pCodigo);
            return lstResult;
        }


        public int Registrar(ManGeneralRequest request)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.Registrar(request);
            return lstResult;

        }

        public GeneralResponse BuscarPorCodigoArticulo(string CodigoArticulo)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.BuscarPorCodigoArticulo(CodigoArticulo);
            return lstResult;
        }

        public GeneralResponse BuscarPorCodigoArticuloDos(string CodigoArticulo)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.BuscarPorCodigoArticuloDos(CodigoArticulo);
            return lstResult;
        }


        public GeneralResponse ObtenerPrecioRangoProducto(int CodigoArticulo)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.ObtenerPrecioRangoProducto(CodigoArticulo);
            return lstResult;
        }


    }
}
