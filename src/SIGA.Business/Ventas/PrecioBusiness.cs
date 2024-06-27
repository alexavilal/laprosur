using SIGA.DAO.Ventas;
using SIGA.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Data;

namespace SIGA.Business.Ventas
{
    public class PrecioBusiness : IDisposable
    {
        public void Dispose()
        {
            // Liberar recursos no administrados, como conexiones a bases de datos, archivos, etc.
            // Ejemplo: Cerrar conexiones abiertas, liberar recursos de archivo, etc.
        }

        public DataTable DevuelvePrecioPorItem(int CodGeneral, int CodPolitica, int CodZona)
        {
            PrecioDao objPrecioDao = new PrecioDao();
            var result = objPrecioDao.DevuelvePrecioPorItem(CodGeneral, CodPolitica, CodZona);
            return result;
        }
        public DataTable DevuelvePrecio(int CodPolitica, int CodZona)
        {
            PrecioDao objPrecioDao = new PrecioDao();
            var result = objPrecioDao.DevuelvePrecio(CodPolitica, CodZona);
            return result;
        }

        public int InsertarPrecio(List<Precio> EntPrecio)
        {
            PrecioDao objPrecioDao = new PrecioDao();
            var result = objPrecioDao.InsertarPrecio(EntPrecio);
            return result;
        }
    }
}
