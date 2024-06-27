USE [dbLaprosur]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbNotaSalida](
	[NtsCodigo] [int] IDENTITY(1,1) NOT NULL,
	[NtsNumero] [varchar](200) NULL,
	[CodAlmacen] [tinyint] NULL,
	[NtsTransaccion] [varchar](200) NULL,
	[NtsFechaEmision] [datetime] NULL,	
	[NtsFechaDocumento] [datetime] NULL,	
	[CodProveedor] [int] NULL,
	[NtsCliente] [varchar](200) NULL,
	[NtsNroDocReferencia] [varchar](200) NULL,
	[NtsAutorizado] [varchar](200) NULL,
	[NtsCentroCosto] [varchar](200) NULL,
	[CodMoneda]	[tinyint] NULL,
	[NtsComentario] [varchar](300) NULL,			
	[NtsEstado] [int] NULL,
	[UsuCodigo] [int] NULL,
	[UsuCreCodigo] [int] NULL,
	[FecCre] [datetime] NULL,
	[UsuModCodigo] [int] NULL,
	[FecMod] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[NtsCodigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


