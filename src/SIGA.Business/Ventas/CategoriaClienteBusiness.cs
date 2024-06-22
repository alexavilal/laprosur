using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SIGA.Entities.Ventas;
using SIGA.DAO.Ventas;

namespace SIGA.Business.Ventas
{
    public class CategoriaClienteBusiness
    {


        public DataTable TipoClienteDcto()
        {
            CategoriaClienteDao _DocumentoRepository = new CategoriaClienteDao();
            return _DocumentoRepository.TipoClienteDcto();
        }

        public int RegistrarDcto(int CodigoTipo, Decimal Inicio, Decimal Fin, int Usuario)
        {

            CategoriaClienteDao _DocumentoRepository = new CategoriaClienteDao();
            return _DocumentoRepository.RegistrarDcto(CodigoTipo, Inicio, Fin, Usuario);

        }
    }
}
