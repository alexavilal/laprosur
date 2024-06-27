using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Data;

namespace SIGA.Business.Logistica
{
    public class GeneralBusiness
    {

        public DataTable ConsultaGeneral(int CodigoGeneral)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var lstResult = _GeneralRepository.ConsultarGeneral(CodigoGeneral);
            return lstResult;
        }

        public DataTable ConsultarMantenimiento(int CodigoSeccion, short CodigoEmpresa, short CodigoMarca, short CodigoMaterial, short CodigoFamilia, short CodigoSubFamilia, short CodigoColor, short CodigoCapacidad, short CodigoForma, short CodigoUnidad, short CodigoEmpaque, string Descripcion, string Estado, short CodigoClasificacion, string CodigoExterno, string Ventas)
        {
            return new GeneralDao().ConsultarMantenimiento(CodigoEmpresa, CodigoMarca, CodigoMaterial, CodigoFamilia, CodigoSubFamilia, CodigoColor, CodigoCapacidad, CodigoForma, CodigoUnidad, CodigoEmpaque, Descripcion, Estado, CodigoClasificacion, CodigoExterno, CodigoSeccion, Ventas);
        }

        public DataTable ConsultaParaKardex(int CodigoMarca, string Codigo, string Descripcion)
        {

            GeneralDao _GeneralRepository = new GeneralDao();
            var result = _GeneralRepository.ConsultarParaKardex(CodigoMarca, Codigo, Descripcion);
            return result;

        }

        public DataTable ConsultaParaKardexPorSeccion(int CodigoMarca, string Codigo, string Descripcion, int CodigoSeccion)
        {
            return new GeneralDao().ConsultarParaKardexSeccion(CodigoMarca, Codigo, Descripcion, CodigoSeccion);
        }


        public int Registrar(General request, ref string CodigoArticulo)
        {
            int Codigo = 0;
            GeneralDao _GeneralRepository = new GeneralDao();
            Codigo = _GeneralRepository.Registrar(request, ref CodigoArticulo);

            // Codigo = _GeneralRepository.Registrar(request);

            return Codigo;
        }

        public int Actualizar(General request)
        {
            int Codigo = 0;
            GeneralDao _GeneralRepository = new GeneralDao();
            Codigo = _GeneralRepository.Actualizar(request);
            return Codigo;
        }
        public List<General> ConsultarPorDescripcion(string Descripcion)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var result = _GeneralRepository.ConsultarPorDescripcion(Descripcion);
            return result;
        }

        public string Codigo(General request)
        {
            string Codigo = string.Empty;
            GeneralDao _GeneralRepository = new GeneralDao();
            Codigo = _GeneralRepository.GenerarCodigo(request);
            return Codigo;


        }


        public List<SIGA.Comun.Dto.GeneralDto> ConsultarPorDescripcionGeneral(string CodigoGeneral, Int16 CodigoMarca, Int16 CodigoEmpresa, string Descripcion)
        {

            string Codigo = string.Empty;
            GeneralDao _GeneralRepository = new GeneralDao();
            var Result = _GeneralRepository.ConsultarPorDescripcionGeneral(CodigoGeneral, CodigoMarca, CodigoEmpresa, Descripcion);
            return Result;

        }

        public DataTable PrecioConsulta(Int16 CodigoEmpresa, Int16 CodigoMarca, string Codigo, string Descripcion)
        {

            GeneralDao _GeneralRepository = new GeneralDao();
            return _GeneralRepository.PrecioConsulta(CodigoEmpresa, CodigoMarca, Codigo, Descripcion);
        }

        public DataTable PrecioConsultaPorCodigo(int Codigo)
        {

            GeneralDao _GeneralRepository = new GeneralDao();
            return _GeneralRepository.PrecioConsultaDatosPorCodigo(Codigo);
        }

        public bool ActualizarPrecios(int CodigoGeneral, decimal PrecioPromedio, decimal PrecioEmpresa, Int16 CodigoUsuario)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            return _GeneralRepository.ActualizarPrecios(CodigoGeneral, PrecioPromedio, PrecioEmpresa, CodigoUsuario);
        }

        public List<General> ConsultarPorDescripcionPrecio(string Descripcion, string Codigo, int Marca)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var result = _GeneralRepository.ConsultarPorDescripcionPrecio(Descripcion, Codigo, Marca);
            return result;
        }

        public DataTable ConsultarGeneralStockPorAlmacen(int CodigoGeneral, int CodigoAlmacen)
        {
            GeneralDao _GeneralRepository = new GeneralDao();
            var result = _GeneralRepository.ConsultarGeneralStockPorAlmacen(CodigoGeneral, CodigoAlmacen);
            return result;
        }

        public DataTable GeneralPorProducto(int CodigoGeneral)
        {
            return new GeneralDao().GeneralPorProducto(CodigoGeneral);
        }

        public DataTable GeneralPorEmpresa(int CodigoEmpresa, int CodigoRango)
        {
            return new GeneralDao().GeneralPorEmpresa(CodigoEmpresa, CodigoRango);
        }
    }
}
