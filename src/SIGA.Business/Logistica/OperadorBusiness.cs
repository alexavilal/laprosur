using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Logistica;
using SIGA.DAO.Logistica;

namespace SIGA.Business.Logistica
{
    public class OperadorBusiness
    {
        public List<Operador> ListarOperador()
        {
            OperadorDao _ParametroRepository = new OperadorDao();

            return _ParametroRepository.ListarOperador();
        }

        public int RegistrarOperador(Operador objOperador)
        {
            int Codigo = 0;
            OperadorDao _GeneralRepository = new OperadorDao();
            Codigo = _GeneralRepository.RegistrarOperador(objOperador);
            return Codigo;
        }

        public int ActualizarOperador(Operador objOperador)
        {
            int Codigo = 0;
            OperadorDao _GeneralRepository = new OperadorDao();
            Codigo = _GeneralRepository.ActualizarOperador(objOperador);
            return Codigo;
        }

        public List<Operador> ObtenerOperadores(Operador objOperador)
        {
            OperadorDao _GeneralRepository = new OperadorDao();
            return _GeneralRepository.ObtenerOperadores(objOperador);
        }

        public Operador ObtenerOperadorPorCodigo(Operador objOperador)
        {
            OperadorDao _GeneralRepository = new OperadorDao();
            return _GeneralRepository.ObtenerOperadorPorCodigo(objOperador);
        }




    }
}
