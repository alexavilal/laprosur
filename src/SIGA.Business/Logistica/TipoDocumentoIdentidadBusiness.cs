using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System.Collections.Generic;

namespace SIGA.Business.Logistica
{
    public class TipoDocumentoIdentidadBusiness
    {
        public List<TipoDocumentoIdentificacion> ListarTipoDocumentoIdentidad()
        {
            TipoDocumentoIdentificacionDao _ParametroRepository = new TipoDocumentoIdentificacionDao();

            return _ParametroRepository.ListarTipoDocumentoIdentidad();
        }
    }
}
