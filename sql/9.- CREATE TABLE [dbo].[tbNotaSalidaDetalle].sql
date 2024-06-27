USE [dbLaprosur]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbNotaSalidaDetalle](
	[NtsCodigo] [int],
	[NtsItem] [int] NULL,
	[CodigoGeneral] [int] NULL,	
	[CodUnidadMedida] [int] NULL,	
	[NtsDescripcion] [varchar](200) NULL,
	[NtsOrdFabricacion] [varchar](200) NULL,
	[Cantidad] [decimal](12, 3) NULL,	
	[Precio] [decimal](12, 3) NULL,	
	[Total] [decimal](12, 3) NULL,	
	[UsuCodigo] [int] NULL,
	[UsuCreCodigo] [int] NULL,
	[FecCre] [datetime] NULL,
	[UsuModCodigo] [int] NULL,
	[FecMod] [datetime] NULL,
) ON [PRIMARY] 
GO