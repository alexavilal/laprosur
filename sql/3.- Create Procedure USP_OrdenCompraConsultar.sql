ALTER PROCEDURE USP_OrdenCompraConsultar
@FechaInicio VarChar(10),
@FechaFin VarChar(10),
@CodProveedor Int
-- USP_OrdenCompraConsultar '20240626','20240626',0
AS

SELECT Ord.OrdNumero as Numero
	    --,Ord.OrdFechaEmision
		,Convert(VarChar,Ord.OrdFechaEmision,103) as Fecha
		,Ord.CodProveedor
		,Pro.ProRazonSocial as [Razon Social]
		,Ord.CodMoneda
		,IsNull(Mon.DesMoneda,'Soles') as Moneda
		,SUM(OrdDet.Total) as Total
FROM tbOrdenCompra Ord
INNER JOIN tbOrdenCompraDetalle OrdDet
	ON Ord.OrdCodigo = OrdDet.OrdCodigo 
INNER JOIN Proveedor Pro
	ON Ord.CodProveedor = Pro.ProCodigo
LEFT JOIN tbMoneda Mon
	ON Ord.CodMoneda = Mon.CodMoneda
WHERE  CONVERT(VarChar(10),Ord.OrdFechaEmision,112)>=@FechaInicio
AND CONVERT(VarChar(10),Ord.OrdFechaEmision,112)<=@FechaFin
AND (ISNULL(@CodProveedor,0) = 0 or Ord.CodProveedor = @CodProveedor)
GROUP BY Ord.OrdNumero 		
	    ,Ord.OrdFechaEmision		
		,Ord.CodProveedor
		,Pro.ProRazonSocial
		,Ord.CodMoneda
		,Mon.DesMoneda