using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGA.DAO.Ventas;
using System.Data;

namespace SIGA.Business.Ventas
{
    public class UbigeoBusiness
    {

        public DataTable ConsultarUbigeo(string Descripcion)
        {
           
            SIGA.DAO.Ventas.UbigeoDao objVentas = new SIGA.DAO.Ventas.UbigeoDao();


            var result = objVentas.ConsultarUbigeo(Descripcion);

            return result;

        }

        public DataTable ConsultarUbigeoGuiaRemision(string Descripcion)
        {
            SIGA.DAO.Ventas.UbigeoDao objVentas = new SIGA.DAO.Ventas.UbigeoDao();


            var result = objVentas.ConsultarUbigeoGuiaRemision(Descripcion);

            return result;
        }

    }
}
