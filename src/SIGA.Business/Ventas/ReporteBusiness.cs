using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SIGA.DAO.Ventas;

namespace SIGA.Business.Ventas
{
    public class ReporteBusiness
    {
        public DataTable TopArticulo(int CodigoSede,DateTime Del, DateTime Al,int CodigoMarca,int CodigoMaterial,int CodigoFamilia,
                                     int CodigoSubFamilia,string Codigo,string Descripcion,int CodigoUsuario)
        {
            ReportesDao obj = new ReportesDao();

            var result = obj.TopArticulo(CodigoSede,Del, Al,CodigoMarca,CodigoMaterial,CodigoFamilia,CodigoSubFamilia,Codigo,Descripcion,CodigoUsuario);

            return result;


        }


        public DataTable VentasrPorDiaRazonSocial(DateTime Del, DateTime Al)
        {
            return new ReportesDao().VentasrPorDiaRazonSocial(Del, Al);
        }

        public DataTable TopArticuloContable(DateTime Del, DateTime Al, int CodigoEmpresa, int CodigoMarca,
                                           string Codigo, string Descripcion)
        {
            ReportesDao obj = new ReportesDao();

            var result = obj.TopArticuloContable(Del, Al, CodigoEmpresa, CodigoMarca, Codigo, Descripcion);

            return result;
        }


        public DataTable TransaccionesCajero(string Del, string Al)
        {
            ReportesDao obj = new ReportesDao();

            var result = obj.TransacionesCajero(Del, Al);

            return result;


        }

        public DataTable TopClientes(DateTime Del, DateTime Al)
        {
            ReportesDao obj = new ReportesDao();

            var result = obj.TopClientes(Del, Al);

            return result;

        }


        public DataTable TopVendedor(DateTime Del, DateTime Al)
        {
            ReportesDao obj = new ReportesDao();

            var result = obj.TopVendedor(Del, Al);

            return result;

        }



        public DataTable TopTipoClientes(DateTime Del, DateTime Al)
        {
            ReportesDao obj = new ReportesDao();

            var result = obj.TopTipoClientes(Del, Al);

            return result;

        }


        public DataTable VentasPorDia(DateTime Del, DateTime Al)
        {
            ReportesDao obj = new ReportesDao();

            var result = obj.VentasrPorDia(Del, Al);

            return result;


        }

        public DataTable CompararPrecios(string CodigoExterno, string Descripcion,int CodigoEmpresa,int CodFamilia,int CodSubFamilia,int CodMarca)
        {
            ReportesDao obj = new ReportesDao();

            var result = obj.CompararPrecios(CodigoExterno, Descripcion, CodigoEmpresa, CodFamilia, CodSubFamilia, CodMarca);

            return result;


        }

        public DataTable VentasPorMarca(DateTime Del, DateTime Al, int CodigoMarca)
        {
            ReportesDao obj = new ReportesDao();
            var result = obj.VentasPorMarca(Del, Al, CodigoMarca);
            return result;

        }


    }
}
