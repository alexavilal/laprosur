using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
namespace SIGA.Business.Ventas
{
    public class CitaBusiness
    {

        public int IngresarCita(CitaRequest request)
        {
            CitaDao _CitaRepository = new CitaDao();
            var lstResult = _CitaRepository.IngresarCita(request);
            return lstResult;
        }


        public IEnumerable<CitaRequest> ConsultarCita()
        {
            CitaDao _CitaRepository = new CitaDao();
            var lstResult = _CitaRepository.Consultar();
            return lstResult;
        }
        
    }
}
