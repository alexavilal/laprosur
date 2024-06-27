using SIGA.Entities.Logistica;
using System.Collections.Generic;


namespace SIGA.Business.Logistica
{
    public class UnidadMedidaBusiness
    {

        public List<UnidadMedida> Listar()
        {
            SIGA.DAO.Logistica.UndadMedidaDao _ParametroRepository = new SIGA.DAO.Logistica.UndadMedidaDao();
            var lstResult = _ParametroRepository.Listar();
            return lstResult;

        }


        public int RegistrarUnidadMedida(UnidadMedida objUnidadMedida)
        {
            int Codigo = 0;
            SIGA.DAO.Logistica.UndadMedidaDao _GeneralRepository = new SIGA.DAO.Logistica.UndadMedidaDao();
            Codigo = _GeneralRepository.RegistrarUnidadMedida(objUnidadMedida);
            return Codigo;
        }

        public int ActualizarUnidadMedida(UnidadMedida objUnidadMedida)
        {
            int Codigo = 0;
            SIGA.DAO.Logistica.UndadMedidaDao _GeneralRepository = new SIGA.DAO.Logistica.UndadMedidaDao();

            Codigo = _GeneralRepository.ActualizarUnidadMedida(objUnidadMedida);
            return Codigo;
        }

        public List<UnidadMedida> ObtenerUnidadMedidas(UnidadMedida objUnidadMedida)
        {
            SIGA.DAO.Logistica.UndadMedidaDao _GeneralRepository = new SIGA.DAO.Logistica.UndadMedidaDao();

            return _GeneralRepository.ObtenerUnidadMedidas(objUnidadMedida);
        }

        public UnidadMedida ObtenerUnidadMedidaPorCodigo(UnidadMedida objUnidadMedida)
        {
            SIGA.DAO.Logistica.UndadMedidaDao _GeneralRepository = new SIGA.DAO.Logistica.UndadMedidaDao();

            return _GeneralRepository.ObtenerUnidadMedidaPorCodigo(objUnidadMedida);
        }




    }
}
