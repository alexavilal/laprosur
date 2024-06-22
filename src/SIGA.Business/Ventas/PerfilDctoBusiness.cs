using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.Entities.Ventas;
using SIGA.DAO.Ventas;
using System.Data;

namespace SIGA.Business.Ventas
{
    public class PerfilDctoBusiness
    {

        public int Actualizar(int  CodigoPerfil, Decimal Inicio, Decimal Fin, int CodigoUsuario)
        {
            PerfilDctoDao _DocumentoRepository = new PerfilDctoDao();
            return _DocumentoRepository.Actualizar(CodigoPerfil, Inicio,Fin, CodigoUsuario);

        }

        public DataTable ConsultarSubTipo()
        {
            PerfilDctoDao _DocumentoRepository = new PerfilDctoDao();
            return _DocumentoRepository.PerfilDcto();

        }
    }
}
