USE [dbLaprosur]
GO

/****** Object:  Table [dbo].[tbGuia]    Script Date: 24/06/2024 21:24:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbOrdenCompraDetalle](
	[OrdCodigo] [int],
	[OrdItem] [int] NULL,
	[OrdCodigoGeneral] [int] NULL,
	[Cantidad] [decimal](12, 3) NULL,
	[CodUnidadMedida] [int] NULL,
	[OrdDescripcion] [varchar](300) NULL,
	[Precio] [decimal](12, 3) NULL,	
	[Total] [decimal](12, 3) NULL,	
	[UsuCodigo] [int] NULL,
	[UsuCreCodigo] [int] NULL,
	[FecCre] [datetime] NULL,
	[UsuModCodigo] [int] NULL,
	[FecMod] [datetime] NULL,
) ON [PRIMARY] 
GO