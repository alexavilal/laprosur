sp_helptext USP_LISTAR_PROVEEDORES

Select * from tbGeneralPrecio
Select * from tbPoliticaPrecio

select * from tbGuiaDetalle

select * from tbUnidadMedida

select * from tbOrdenCompra
select * from tbOrdenCompraDetalle

select * from tbGuia

select   
pv.ProCodigo as Codigo, pv.ProRazonSocial as 'Razon Social' ,pv.ProNombreComercial as 'Nombre Comercial',   
td.DesTipoDocumento 'Tipo Documento', pv.NumDocumento 'Numero Documento',  
case when pv.EstCodigo='A' then 'Activo' else 'Inactivo' end as Estado  
from Proveedor pv inner join [tbTipoDocumentoIdentificacion] td  
on pv.CodTipoDocumento= td.CodTipoDocumento  


select * from Proveedor


select   
pv.ProCodigo as Codigo, pv.ProRazonSocial as 'Razon Social' ,pv.ProNombreComercial as 'Nombre Comercial',   
td.DesTipoDocumento 'Tipo Documento', pv.NumDocumento 'Numero Documento',  
case when pv.EstCodigo='A' then 'Activo' else 'Inactivo' end as Estado  
from Proveedor pv inner join [tbTipoDocumentoIdentificacion] td  
on pv.CodTipoDocumento= td.CodTipoDocumento  
WHERE (@ProRazonSocial = '' OR pv.ProRazonSocial=@ProRazonSocial)  
AND (@ProNombreComercial = '' OR pv.ProNombreComercial=@ProNombreComercial)  
AND (@CodTipoDocumento = '' OR pv.CodTipoDocumento=@CodTipoDocumento)  
AND (@EstCodigo = '' OR pv.EstCodigo=@EstCodigo)  
AND (@NumDocumento = '' OR pv.NumDocumento=@NumDocumento) 






SELECT Ord.OrdNumero
	    ,Ord.OrdFechaEmision
		--,Convert(VarChar,CotFecha,103) as Fecha
		,Ord.CodProveedor
		,Pro.ProRazonSocial
		,Ord.CodMoneda
		,Mon.DesMoneda
		,SUM(OrdDet.Total) as Total
FROM tbOrdenCompra Ord
INNER JOIN tbOrdenCompraDetalle OrdDet
	ON Ord.OrdCodigo = OrdDet.OrdCodigo 
INNER JOIN Proveedor Pro
	ON Ord.CodProveedor = Pro.ProCodigo
INNER JOIN tbMoneda Mon
	ON Ord.CodMoneda = Mon.CodMoneda
--WHERE  CONVERT(VarChar(10),Ord.OrdFechaEmision,112)>=@FechaInicio
--AND CONVERT(VarChar(10),Ord.OrdFechaEmision,112)<=@FechaFin
--AND (ISNULL(@CodProveedor,0) = 0 or Ord.CodProveedor = @CodProveedor)
GROUP BY Ord.OrdNumero 		
	    ,Ord.OrdFechaEmision		
		,Ord.CodProveedor
		,Pro.ProRazonSocial
		,Ord.CodMoneda
		,Mon.DesMoneda

SELECT * FROM tbAlmacen
SELECT * FROM tbTipoDocumento

SELECT * FROM tbOrdenCompraDetalle
SELECT * FROM Proveedor
SELECT * FROM tbMoneda