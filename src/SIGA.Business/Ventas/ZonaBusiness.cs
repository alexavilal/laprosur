using SIGA.DAO.Administrador;
using SIGA.DAO.Ventas;
using SIGA.Entities.Administrador;
using SIGA.Entities.Ventas;
using System.Collections.Generic;

namespace SIGA.Business.Ventas
{
    public class ZonaBusiness
    {

        public int RegistrarZona(Zona objZona)
        {
            int Codigo = 0;
            ZonaDao _GeneralRepository = new ZonaDao();
            Codigo = _GeneralRepository.RegistrarZona(objZona);
            return Codigo;
        }

        public int ActualizarModulo(Modulo objModulo)
        {
            int Codigo = 0;
            ZonaDao _GeneralRepository = new ZonaDao();
            Codigo = _GeneralRepository.ActualizarModulo(objModulo);
            return Codigo;
        }

        public List<Zona> ObtenerZonas(Zona objZona)
        {
            ZonaDao _GeneralRepository = new ZonaDao();
            return _GeneralRepository.ObtenerZona(objZona);
        }

        public Modulo ObtenerModuloPorCodigo(Modulo objModulo)
        {
            ModuloDao _GeneralRepository = new ModuloDao();
            return _GeneralRepository.ObtenerModuloPorCodigo(objModulo);
        }


    }
}
