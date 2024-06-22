using System.Collections.Generic;
using SIGA.Entities.Administrador;
using SIGA.DAO.Administrador;


namespace SIGA.Business.Administrador
{
    public class CargoBusiness
    {

        public List<Cargo> ObtenerCargo()
        {
            CargoDao _GeneralRepository = new CargoDao();
            return _GeneralRepository.ObtenerCargo();

        }
    }
}
