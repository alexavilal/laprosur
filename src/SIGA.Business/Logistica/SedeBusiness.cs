using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System.Collections.Generic;


namespace SIGA.Business.Logistica
{
    public class SedeBusiness
    {

        public List<Sede> Listar()
        {
            SedeDao _ParametroRepository = new SedeDao();
            var lstResult = _ParametroRepository.Listar();
            return lstResult;
        }

        public int RegistrarSede(Sede objSede)
        {
            int Codigo = 0;
            SedeDao _GeneralRepository = new SedeDao();
            Codigo = _GeneralRepository.RegistrarSede(objSede);
            return Codigo;
        }

        public int ActualizarSede(Sede objSede)
        {
            int Codigo = 0;
            SedeDao _GeneralRepository = new SedeDao();
            Codigo = _GeneralRepository.ActualizarSede(objSede);
            return Codigo;
        }

        public List<Sede> ObtenerSedes(Sede objSede)
        {
            SedeDao _GeneralRepository = new SedeDao();
            return _GeneralRepository.ObtenerSedes(objSede);
        }

        public Sede ObtenerSedePorCodigo(Sede objSede)
        {
            SedeDao _GeneralRepository = new SedeDao();
            return _GeneralRepository.ObtenerSedePorCodigo(objSede);
        }
    }
}
