
using SIGA.DAO.Administrador;
using SIGA.Entities.Administrador;
using System.Collections.Generic;
using System.Data;

namespace SIGA.Business.Administrador
{
    public class OpcionBusiness
    {

        public DataTable OpcionPorUsuario(int CodigoOpcion)
        {
            OpcionDao _GeneralRepository = new OpcionDao();
            var result = _GeneralRepository.ObtenerUsuariosPorOpcion(CodigoOpcion);
            return result;
        }

        public int RegistrarOpcion(Opcion objOpcion)
        {
            int Codigo = 0;
            OpcionDao _GeneralRepository = new OpcionDao();
            Codigo = _GeneralRepository.RegistrarOpcion(objOpcion);
            return Codigo;
        }



        public int ActualizarOpcion(Opcion objOpcion)

        {
            int Codigo = 0;
            OpcionDao _GeneralRepository = new OpcionDao();
            Codigo = _GeneralRepository.ActualizarOpcion(objOpcion);
            return Codigo;
        }

        public List<Opcion> ObtenerOpciones(Opcion objOpcion)
        {
            OpcionDao _GeneralRepository = new OpcionDao();
            return _GeneralRepository.ObtenerOpciones(objOpcion);
        }

        public Opcion ObtenerOpcionPorCodigo(Opcion objOpcion)
        {
            OpcionDao _GeneralRepository = new OpcionDao();
            return _GeneralRepository.ObtenerOpcionPorCodigo(objOpcion);
        }




    }
}
