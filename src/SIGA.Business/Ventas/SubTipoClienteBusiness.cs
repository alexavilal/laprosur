using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Ventas;
using SIGA.DAO.Ventas;
using System.Data;

namespace SIGA.Business.Ventas
{
    public class SubTipoClienteBusiness
    {
        public List<SubTipoCliente> ObtenerSubTipoCliente()
        {
            SubTipoClienteDao _DocumentoRepository = new SubTipoClienteDao();
            return _DocumentoRepository.ObtenerSubTipoCliente();
        }

        public int Registrar(string Descripcion,Int16 CodigoUsuario)
        {
            SubTipoClienteDao _DocumentoRepository = new SubTipoClienteDao();
            return _DocumentoRepository.Registrar(Descripcion, CodigoUsuario);

        }


        public int Actualizar(Int16 CodigoSubTipo,string Descripcion, Int16 CodigoUsuario,string Estado)
        {
            SubTipoClienteDao _DocumentoRepository = new SubTipoClienteDao();
            return _DocumentoRepository.Actualizar(CodigoSubTipo, Descripcion, CodigoUsuario,Estado);

        }

        public DataTable ConsultarSubTipo (Int16 CodigoSubTipo,string Descripcion,string Estado)
        {
            SubTipoClienteDao _DocumentoRepository = new SubTipoClienteDao();
            return _DocumentoRepository.ConsultarSubTipo(CodigoSubTipo, Descripcion, Estado);

        }



    }
}
