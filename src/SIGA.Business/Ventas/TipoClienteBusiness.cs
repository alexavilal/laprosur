using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SIGA.Entities.Ventas;
using SIGA.DAO.Ventas;

namespace SIGA.Business.Ventas
{
    public class TipoClienteBusiness
    {
        public List<TipoCliente> ObtenerTipoCliente()
        {
            TipoClienteDao _DocumentoRepository = new TipoClienteDao();
            return _DocumentoRepository.ObtenerTipoCliente();
        }

        public DataTable TipoClienteDcto()
        {
            TipoClienteDao _DocumentoRepository = new TipoClienteDao();
            return _DocumentoRepository.TipoClienteDcto();
        }

        public int RegistrarDcto(int CodigoTipo, Decimal Inicio, Decimal Fin, int Usuario)
        {

            TipoClienteDao _DocumentoRepository = new TipoClienteDao();
            return _DocumentoRepository.RegistrarDcto(CodigoTipo, Inicio, Fin, Usuario);

        }
        
    }
}
