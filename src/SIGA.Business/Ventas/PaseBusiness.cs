using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;

namespace SIGA.Business.Ventas
{
    public class PaseBusiness
    {

        public int RegistrarPase(PaseDinero request)
        {
            PaseDineroDao _CitaRepository = new PaseDineroDao();
            var lstResult = _CitaRepository.RegistroPase(request);
            return lstResult;
        }
    
    }
}
