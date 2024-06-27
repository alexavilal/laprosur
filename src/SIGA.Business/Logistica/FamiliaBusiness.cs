using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System.Collections.Generic;

namespace SIGA.Business.Logistica
{
    public class FamiliaBusiness
    {

        public List<Familia> Listar(Familia objFamilia)
        {
            FamiliaDao _ParametroRepository = new FamiliaDao();

            var lstResult = _ParametroRepository.Listar(objFamilia);
            return lstResult;
        }

        public int RegistrarFamilia(Familia objFamilia)
        {

            FamiliaDao _GeneralRepository = new FamiliaDao();
            var Codigo = _GeneralRepository.RegistrarFamilia(objFamilia);
            return Codigo;
        }

        public int ActualizarFamilia(Familia objFamilia)
        {
            int Codigo = 0;
            FamiliaDao _GeneralRepository = new FamiliaDao();
            Codigo = _GeneralRepository.ActualizarFamilia(objFamilia);
            return Codigo;
        }

        public List<Familia> ObtenerFamilias(Familia objFamilia)
        {
            FamiliaDao _GeneralRepository = new FamiliaDao();
            return _GeneralRepository.ObtenerFamilias(objFamilia);
        }

        public Familia ObtenerFamiliaPorCodigo(Familia objFamilia)
        {
            FamiliaDao _GeneralRepository = new FamiliaDao();
            return _GeneralRepository.ObtenerFamiliaPorCodigo(objFamilia);
        }


    }
}
