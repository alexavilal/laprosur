CREATE PROCEDURE USP_InsertarDetalleNotaSalida
    @NtsCodigo int,
	@NtsItem int,
    @CodigoGeneral int,    
	@CodUnidadMedida int,
	@NtsDescripcion varchar(200),
	@NtsOrdFabricacion varchar(200),
    @Cantidad decimal(12, 3),		
    @Precio decimal(12, 3),    
    @Total decimal(12, 3),       
    @UsuCreCodigo int
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO dbo.tbNotaSalidaDetalle (NtsCodigo, NtsItem, CodigoGeneral, CodUnidadMedida, NtsDescripcion, NtsOrdFabricacion, Cantidad, Precio, Total, UsuCreCodigo)
    VALUES (@NtsCodigo, @NtsItem, @CodigoGeneral, @CodUnidadMedida, @NtsDescripcion, @NtsOrdFabricacion, @Cantidad, @Precio, @Total, @UsuCreCodigo);

END