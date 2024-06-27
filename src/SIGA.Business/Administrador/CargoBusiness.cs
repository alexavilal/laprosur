using SIGA.DAO.Administrador;
using SIGA.Entities.Administrador;
using System.Collections.Generic;


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
