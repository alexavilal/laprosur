using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO;
using SIGA.Entities.Logistica;
using SIGA.DAO.Logistica;

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
