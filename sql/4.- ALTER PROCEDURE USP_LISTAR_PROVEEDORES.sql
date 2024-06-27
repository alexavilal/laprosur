ALTER PROCEDURE USP_LISTAR_PROVEEDORES  
(  
@ProRazonSocial VARCHAR(50),  
@ProNombreComercial VARCHAR(50),  
@CodTipoDocumento tinyint,  
@EstCodigo  char(1),  
@NumDocumento  VARCHAR(50)  
  
)  
AS  
BEGIN  
  
select   
pv.ProCodigo as Codigo, pv.ProRazonSocial as 'Razon Social' ,pv.ProNombreComercial as 'Nombre Comercial',   
td.DesTipoDocumento 'Tipo Documento', pv.NumDocumento 'Numero Documento',  
case when pv.EstCodigo='A' then 'Activo' else 'Inactivo' end as Estado  
,pv.ProDireccion
from Proveedor pv inner join [tbTipoDocumentoIdentificacion] td  
on pv.CodTipoDocumento= td.CodTipoDocumento  
WHERE (@ProRazonSocial = '' OR pv.ProRazonSocial LIKE '%' + @ProRazonSocial + '%')  
--(@DesAlmacen ='' or  a.DesAlmacen like '%'+ @DesAlmacen +'%')	
AND (@ProNombreComercial = '' OR pv.ProNombreComercial=@ProNombreComercial)  
AND (@CodTipoDocumento = '' OR pv.CodTipoDocumento=@CodTipoDocumento)  
AND (@EstCodigo = '' OR pv.EstCodigo=@EstCodigo)  
AND (@NumDocumento = '' OR pv.NumDocumento=@NumDocumento)  
  
END  