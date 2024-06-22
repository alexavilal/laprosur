using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SIGA.DAO.Ventas;


namespace SIGA.Business.Ventas
{
    public class MotivoAnulacionBusiness
    {
        public DataTable ConsultarMotivoAnulacion(short CodigoMotivoAnulacion, string Descripcion, string Estado)
        {
            return new MotivoAnulacionDao().ConsultarMotivoAnulacion(CodigoMotivoAnulacion, Descripcion, Estado);
        }

        public DataTable ConsultarRegistroAnulacion(int CodigoDocumento)
        {
            return new MotivoAnulacionDao().ConsultarRegistroAnulacion(CodigoDocumento);
        }
    
    }
}
