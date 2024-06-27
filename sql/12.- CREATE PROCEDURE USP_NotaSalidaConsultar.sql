ALTER PROCEDURE USP_NotaSalidaConsultar
@FechaInicio VarChar(10),
@FechaFin VarChar(10),
@CodProveedor Int
-- USP_NotaSalidaConsultar '20240626','20240626',0
AS

SELECT Nts.NtsNumero as Numero
	    --,Nts.NtsFechaEmision
		,Convert(VarChar,Nts.NtsFechaEmision,103) as Fecha
		,Nts.CodProveedor
		,Pro.ProRazonSocial as [Razon Social]
		,Nts.CodMoneda
		,IsNull(Mon.DesMoneda,'Soles') as Moneda
		,SUM(NtsDet.Total) as Total
FROM tbNotaSalida Nts
INNER JOIN tbNotaSalidaDetalle NtsDet
	ON Nts.NtsCodigo = NtsDet.NtsCodigo 
INNER JOIN Proveedor Pro
	ON Nts.CodProveedor = Pro.ProCodigo
LEFT JOIN tbMoneda Mon
	ON Nts.CodMoneda = Mon.CodMoneda
WHERE  CONVERT(VarChar(10),Nts.NtsFechaEmision,112)>=@FechaInicio
AND CONVERT(VarChar(10),Nts.NtsFechaEmision,112)<=@FechaFin
AND (ISNULL(@CodProveedor,0) = 0 or Nts.CodProveedor = @CodProveedor)
GROUP BY Nts.NtsNumero 		
	    ,Nts.NtsFechaEmision		
		,Nts.CodProveedor
		,Pro.ProRazonSocial
		,Nts.CodMoneda
		,Mon.DesMoneda