USE [dbLaprosur]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbOrdenCompra](
	[OrdCodigo] [int] IDENTITY(1,1) NOT NULL,
	[OrdNumero] [varchar](200) NULL,
	[OrdFechaEmision] [datetime] NULL,
	[OrdFechaEntrega] [datetime] NULL,
	[CodProveedor] [int] NULL,
	[CodMoneda]	[tinyint] NULL,
	[OrdDireccion] [varchar](300) NULL,
	[OrdNroRuc] [varchar](25) NULL,
	[OrdContacto] [varchar](200) NULL,
	[OrdTelefono] [varchar](25) NULL,
	[CodFormaPago] [int] NULL,
	[OrdReferencia] [varchar](200) NULL,
	[OrdNroCuentaCorriente] [varchar](30) NULL,
	[OrdSolicitatoPor] [varchar](200) NULL,
	[OrdNroCotizacion] [varchar](30) NULL,
	[OrdObservacion] [varchar](30) NULL,	
	[OrdEstado] [int] NULL,
	[UsuCodigo] [int] NULL,
	[UsuCreCodigo] [int] NULL,
	[FecCre] [datetime] NULL,
	[UsuModCodigo] [int] NULL,
	[FecMod] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrdCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


