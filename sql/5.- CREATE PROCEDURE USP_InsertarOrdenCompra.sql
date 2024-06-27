CREATE PROCEDURE USP_InsertarOrdenCompra
	@OrdFechaEmision [datetime],
	@OrdFechaEntrega [datetime],
	@CodProveedor [int],
	@CodMoneda	[tinyint],
	@OrdDireccion [varchar](300),
	@OrdNroRuc [varchar](25),
	@OrdContacto [varchar](200),
	@OrdTelefono [varchar](25),
	@CodFormaPago [int],
	@OrdReferencia [varchar](200),
	@OrdNroCuentaCorriente [varchar](30),
	@OrdSolicitatoPor [varchar](200),
	@OrdNroCotizacion [varchar](30),
	@OrdObservacion [varchar](30),	
	@OrdEstado [int],
	@UsuCodigo [int],
	@UsuCreCodigo [int],
	@OrdNumero VarChar(200) OutPut,
	@OrdCodigo Int OutPut
AS    
BEGIN    
        
    -- Insertar el nuevo registro    
    INSERT INTO dbo.tbOrdenCompra (
				OrdNumero 
				,OrdFechaEmision
				,OrdFechaEntrega
				,CodProveedor
				,CodMoneda
				,OrdDireccion
				,OrdNroRuc
				,OrdContacto
				,OrdTelefono
				,CodFormaPago
				,OrdReferencia
				,OrdNroCuentaCorriente
				,OrdSolicitatoPor
				,OrdNroCotizacion
				,OrdObservacion
				,OrdEstado
				, UsuCodigo
				, UsuCreCodigo)    
    VALUES (
				 @OrdNumero 
				,@OrdFechaEmision
				,@OrdFechaEntrega
				,@CodProveedor
				,@CodMoneda
				,@OrdDireccion
				,@OrdNroRuc
				,@OrdContacto
				,@OrdTelefono
				,@CodFormaPago
				,@OrdReferencia
				,@OrdNroCuentaCorriente
				,@OrdSolicitatoPor
				,@OrdNroCotizacion
				,@OrdObservacion
				,@OrdEstado
				,@UsuCodigo
				,@UsuCreCodigo
				);    
    
    -- Obtener el nuevo OrdCodigo
    Set @OrdNumero = '0000' + convert(VarChar,SCOPE_IDENTITY())  
    Set @OrdCodigo = SCOPE_IDENTITY()  
	
	UPDATE dbo.tbOrdenCompra
		SET OrdNumero = @OrdNumero
	WHERE OrdCodigo = @OrdCodigo;

    SELECT @OrdNumero AS OrdNumero, @OrdCodigo AS OrdCodigo
        
    -- Obtener el nuevo OrdNumero    
END