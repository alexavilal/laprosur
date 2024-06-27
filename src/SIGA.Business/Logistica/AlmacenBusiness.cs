using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System;
using System.Collections.Generic;
using System.Data;

namespace SIGA.Business.Logistica
{
    public class AlmacenBusiness
    {
        public List<Almacen> Listar()
        {
            AlmacenDao _ParametroRepository = new AlmacenDao();
            var lstResult = _ParametroRepository.Listar();
            return lstResult;
        }

        public DataTable ConsultarAlmacenes(Int16 CodigoSede)
        {
            AlmacenDao _DocumentoRepository = new AlmacenDao();

            return _DocumentoRepository.ConsultarAlmacenes(CodigoSede);
        }


        public List<Almacen> ListarPorSede(Int16 CodigoSede)
        {
            AlmacenDao _ParametroRepository = new AlmacenDao();
            var lstResult = _ParametroRepository.ListarPorSede(CodigoSede);
            return lstResult;
        }

        public int RegistrarAlmacen(Almacen objAlmacen)
        {
            int Codigo = 0;
            AlmacenDao _GeneralRepository = new AlmacenDao();
            Codigo = _GeneralRepository.RegistrarAlmacen(objAlmacen);
            return Codigo;
        }


        public int ActualizarAlmacen(Almacen objAlmacen)
        {
            int Codigo = 0;
            AlmacenDao _GeneralRepository = new AlmacenDao();
            Codigo = _GeneralRepository.ActualizarAlmacen(objAlmacen);
            return Codigo;
        }

        public List<Almacen> ObtenerAlmacens(Almacen objAlmacen)
        {
            AlmacenDao _GeneralRepository = new AlmacenDao();
            return _GeneralRepository.ObtenerAlmacens(objAlmacen);
        }

        public Almacen ObtenerAlmacenPorCodigo(Almacen objAlmacen)
        {
            AlmacenDao _GeneralRepository = new AlmacenDao();
            return _GeneralRepository.ObtenerAlmacenPorCodigo(objAlmacen);
        }

    }
}
