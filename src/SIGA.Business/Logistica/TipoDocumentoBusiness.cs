using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
namespace SIGA.Business.Logistica
{
    public class TipoDocumentoBusiness
    {

        public List<TipoDocumento> Listar()
        {
            TipoDocumentoDao _ParametroRepository = new TipoDocumentoDao();

            var lstResult = _ParametroRepository.Listar();
            return lstResult;
        }
    
    
    }

}
