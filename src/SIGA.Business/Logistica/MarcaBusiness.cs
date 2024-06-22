using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Logistica;
using SIGA.Entities.Logistica;
using System.Data;

namespace SIGA.Business.Logistica
{
   public  class MarcaBusiness
    {

       public List<Marca> Listar(string Estado)
       {
           MarcaDao _ParametroRepository = new MarcaDao();

           var lstResult = _ParametroRepository.Listar(Estado);
           return lstResult;
       }


       public List<Marca> ListarMarcas()
       {
           MarcaDao _ParametroRepository = new MarcaDao();

           return _ParametroRepository.ListarMarcas();           
       }

       public DataTable ListarMarcaCriterio(Int16? CodMarca, string Descripcion, string Estado)
       {
           MarcaDao _ParametroRepository = new MarcaDao();
           var result = _ParametroRepository.ListarMarcaCriterio(CodMarca, Descripcion, Estado);
           return result;
       }

       public int Registrar(Marca objMarca)
       {
           MarcaDao _ParametroRepository = new MarcaDao();
           var result = _ParametroRepository.RegistrarMarca(objMarca);
           return result;

       }


       public int Actualizar(Marca objMarca)
       {
           MarcaDao _ParametroRepository = new MarcaDao();
           var result = _ParametroRepository.ActualizarMarca(objMarca);
           return result;

       }
   

        public DataTable ListarMarcaPorCodigo(Int16 CodMarca)
       {
           MarcaDao _ParametroRepository = new MarcaDao();
           var result = _ParametroRepository.ConsultarMarcaPorCodigo(CodMarca);
           return result;
       }

       public DataTable ConsultarMarcas()
        {
            MarcaDao _ParametroRepository = new MarcaDao();
            var result = _ParametroRepository.ConsultarMarcas();
            return result;

        }

   }
}
