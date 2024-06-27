CREATE PROCEDURE USP_InsertarDetalleOrdenCompra
    @OrdCodigo int,
	@OrdItem int,
    @OrdCodigoGeneral int,    
    @Cantidad decimal(12, 3),
	@CodUnidadMedida int,
	@OrdDescripcion varchar(max),
    @Precio decimal(12, 3),    
    @Total decimal(12, 3),       
    @UsuCreCodigo int
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO dbo.tbOrdenCompraDetalle (OrdCodigo, OrdItem, OrdCodigoGeneral, Cantidad, CodUnidadMedida, OrdDescripcion, Precio, Total, UsuCreCodigo)
    VALUES (@OrdCodigo, @OrdItem, @OrdCodigoGeneral, @Cantidad, @CodUnidadMedida, @OrdDescripcion, @Precio, @Total, @UsuCreCodigo);

END