using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;

namespace SIGA.Business.Ventas
{
    public class SolicitudCotizacionBusiness
    {

        public int IngresaSolicitud(SolicitudCotizacionRequest request)
        {
            SolicitudCotizacionDao _CitaRepository = new SolicitudCotizacionDao();
            var lstResult = _CitaRepository.InsertarSolicitud(request);
            return lstResult;
        }
    }
}
