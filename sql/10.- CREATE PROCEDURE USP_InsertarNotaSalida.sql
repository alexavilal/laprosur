CREATE PROCEDURE dbo.USP_InsertarNotaSalida
	@CodAlmacen	[tinyint],
	@NtsTransaccion [varchar](200),
	@NtsFechaEmision [datetime],	
	@NtsFechaDocumento [datetime],	
	@CodProveedor [int],
	@NtsCliente [varchar](200),
	@NtsNroDocReferencia [varchar](200),
	@NtsAutorizado [varchar](200),
	@NtsCentroCosto [varchar](200),
	@CodMoneda	[tinyint],
	@NtsComentario [varchar](300),	
	@NtsEstado [int],
	@UsuCodigo [int],
	@UsuCreCodigo [int],
	@NtsNumero VarChar(200) OutPut,
	@NtsCodigo Int OutPut
AS    
BEGIN    
        
    -- Insertar el nuevo registro    
    INSERT INTO dbo.tbNotaSalida (
				NtsNumero
				,CodAlmacen
				,NtsTransaccion 
				,NtsFechaEmision
				,NtsFechaDocumento
				,CodProveedor
				,NtsCliente
				,NtsNroDocReferencia
				,NtsAutorizado
				,NtsCentroCosto
				,CodMoneda
				,NtsComentario
				,NtsEstado
				,UsuCodigo
				,UsuCreCodigo)    
    VALUES (
				 @NtsNumero
				,@CodAlmacen
				,@NtsTransaccion 
				,@NtsFechaEmision
				,@NtsFechaDocumento
				,@CodProveedor
				,@NtsCliente
				,@NtsNroDocReferencia
				,@NtsAutorizado
				,@NtsCentroCosto
				,@CodMoneda
				,@NtsComentario
				,@NtsEstado
				,@UsuCodigo
				,@UsuCreCodigo
				);    
    
    -- Obtener el nuevo NtsCodigo
    Set @NtsNumero = '0000' + convert(VarChar,SCOPE_IDENTITY())  
    Set @NtsCodigo = SCOPE_IDENTITY()  
	
	UPDATE dbo.tbNotaSalida
		SET NtsNumero = @NtsNumero
	WHERE NtsCodigo = @NtsCodigo;

    SELECT @NtsNumero AS NtsNumero, @NtsCodigo AS NtsCodigo
        
    -- Obtener el nuevo NtsNumero    
END