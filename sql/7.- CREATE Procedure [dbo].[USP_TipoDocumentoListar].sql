ALTER Procedure [dbo].[USP_TipoDocumentoListar]
--(	
	--@CodTipoDocumento int,	
	--@DesTipoDocumento varchar(50), 		
	--@EstReg char(1)
--)
as
begin
 
 
	Select   CodTipoDocumento,	DesTipoDocumento ,
	case when  EstReg='A' then 'Activo' else 'Inactivo' end as Estado  
	FROM  tbTipoDocumento
	--WHERE   
	--(isnull(@CodTipoDocumento,0)=0 or CodTipoDocumento =@CodTipoDocumento)
	--and 
	--(@DesTipoDocumento ='' or DesTipoDocumento like '%'+ @DesTipoDocumento +'%')	
	--and
	--(@EstReg='' or EstReg =@EstReg)	
end