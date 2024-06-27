using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System.Collections.Generic;
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
