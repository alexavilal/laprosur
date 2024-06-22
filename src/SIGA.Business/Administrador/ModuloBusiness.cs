using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Administrador;
using SIGA.DAO.Administrador;

namespace SIGA.Business.Administrador
{
    public  class ModuloBusiness
    {

        public int RegistrarModulo(Modulo objModulo)
        {
            int Codigo = 0;
            ModuloDao _GeneralRepository = new ModuloDao();
            Codigo = _GeneralRepository.RegistrarModulo(objModulo);
            return Codigo;
        }

        public int ActualizarModulo(Modulo objModulo)
        {
            int Codigo = 0;
            ModuloDao _GeneralRepository = new ModuloDao();
            Codigo = _GeneralRepository.ActualizarModulo(objModulo);
            return Codigo;        
        }

        public List<Modulo> ObtenerModulos(Modulo objModulo)
        {
            ModuloDao _GeneralRepository = new ModuloDao();
            return _GeneralRepository.ObtenerModulos(objModulo);
        }

        public Modulo ObtenerModuloPorCodigo(Modulo objModulo)
        {
            ModuloDao _GeneralRepository = new ModuloDao();
            return _GeneralRepository.ObtenerModuloPorCodigo(objModulo);
        }

    }
}
