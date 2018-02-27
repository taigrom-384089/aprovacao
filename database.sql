﻿USE [Aprovacao]
GO
/****** Object:  Table [dbo].[TB_CONFIGURACAO]    Script Date: 27/02/2018 15:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CONFIGURACAO](
	[ID_CONFIGURACAO] [int] IDENTITY(1,1) NOT NULL,
	[FAIXA_INICIAL] [numeric](18, 2) NOT NULL,
	[FAIXA_FINAL] [numeric](18, 2) NOT NULL,
	[VISTO] [int] NOT NULL,
	[APROVACAO] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_CONFIGURACAO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_HISTORICO_APROVACAO]    Script Date: 27/02/2018 15:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_HISTORICO_APROVACAO](
	[ID_HISTORICO_APROVACAO] [int] IDENTITY(1,1) NOT NULL,
	[ID_USUARIO] [int] NOT NULL,
	[ID_NOTA_COMPRA] [int] NOT NULL,
	[OPERACAO] [smallint] NOT NULL,
	[DATA] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_HISTORICO_APROVACAO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_NOTA_COMPRA]    Script Date: 27/02/2018 15:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_NOTA_COMPRA](
	[ID_NOTA_COMPRA] [int] IDENTITY(1,1) NOT NULL,
	[DATA_EMISSAO] [datetime2](7) NOT NULL,
	[VALOR_MERCADORIA] [numeric](18, 2) NOT NULL,
	[VALOR_DESCONTO] [numeric](18, 2) NOT NULL,
	[VALOR_FRETE] [numeric](18, 2) NULL,
	[VALOR_TOTAL] [numeric](18, 2) NULL,
	[STATUS] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_NOTA_COMPRA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_USUARIO]    Script Date: 27/02/2018 15:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USUARIO](
	[ID_USUARIO] [int] IDENTITY(1,1) NOT NULL,
	[LOGIN] [nvarchar](20) NOT NULL,
	[SENHA] [nvarchar](8) NOT NULL,
	[PAPEL] [smallint] NOT NULL,
	[VALOR_MIN_VISTO_APROVACAO] [numeric](18, 2) NOT NULL,
	[VALOR_MAX_VISTO_APROVACAO] [numeric](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[TB_CONFIGURACAO] ON 

INSERT [dbo].[TB_CONFIGURACAO] ([ID_CONFIGURACAO], [FAIXA_INICIAL], [FAIXA_FINAL], [VISTO], [APROVACAO]) VALUES (1, CAST(0.00 AS Numeric(18, 2)), CAST(1000.00 AS Numeric(18, 2)), 1, 0)
INSERT [dbo].[TB_CONFIGURACAO] ([ID_CONFIGURACAO], [FAIXA_INICIAL], [FAIXA_FINAL], [VISTO], [APROVACAO]) VALUES (2, CAST(1000.01 AS Numeric(18, 2)), CAST(10000.00 AS Numeric(18, 2)), 1, 1)
INSERT [dbo].[TB_CONFIGURACAO] ([ID_CONFIGURACAO], [FAIXA_INICIAL], [FAIXA_FINAL], [VISTO], [APROVACAO]) VALUES (3, CAST(10000.01 AS Numeric(18, 2)), CAST(50000.00 AS Numeric(18, 2)), 2, 1)
INSERT [dbo].[TB_CONFIGURACAO] ([ID_CONFIGURACAO], [FAIXA_INICIAL], [FAIXA_FINAL], [VISTO], [APROVACAO]) VALUES (4, CAST(50000.01 AS Numeric(18, 2)), CAST(999999.99 AS Numeric(18, 2)), 2, 2)
SET IDENTITY_INSERT [dbo].[TB_CONFIGURACAO] OFF
SET IDENTITY_INSERT [dbo].[TB_NOTA_COMPRA] ON 

INSERT [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA], [DATA_EMISSAO], [VALOR_MERCADORIA], [VALOR_DESCONTO], [VALOR_FRETE], [VALOR_TOTAL], [STATUS]) VALUES (1, CAST(N'2018-02-26 14:31:09.0000000' AS DateTime2), CAST(1220.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), CAST(60.00 AS Numeric(18, 2)), CAST(1300.00 AS Numeric(18, 2)), 0)
INSERT [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA], [DATA_EMISSAO], [VALOR_MERCADORIA], [VALOR_DESCONTO], [VALOR_FRETE], [VALOR_TOTAL], [STATUS]) VALUES (2, CAST(N'2018-02-27 08:58:47.0000000' AS DateTime2), CAST(1920.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), CAST(60.00 AS Numeric(18, 2)), CAST(2000.00 AS Numeric(18, 2)), 0)
INSERT [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA], [DATA_EMISSAO], [VALOR_MERCADORIA], [VALOR_DESCONTO], [VALOR_FRETE], [VALOR_TOTAL], [STATUS]) VALUES (3, CAST(N'2018-02-25 09:55:03.0000000' AS DateTime2), CAST(300.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), CAST(60.00 AS Numeric(18, 2)), CAST(380.00 AS Numeric(18, 2)), 0)
INSERT [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA], [DATA_EMISSAO], [VALOR_MERCADORIA], [VALOR_DESCONTO], [VALOR_FRETE], [VALOR_TOTAL], [STATUS]) VALUES (4, CAST(N'2018-02-22 09:55:18.0000000' AS DateTime2), CAST(400.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), CAST(60.00 AS Numeric(18, 2)), CAST(480.00 AS Numeric(18, 2)), 0)
INSERT [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA], [DATA_EMISSAO], [VALOR_MERCADORIA], [VALOR_DESCONTO], [VALOR_FRETE], [VALOR_TOTAL], [STATUS]) VALUES (5, CAST(N'2018-02-18 09:55:57.0000000' AS DateTime2), CAST(10500.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), CAST(60.00 AS Numeric(18, 2)), CAST(10580.00 AS Numeric(18, 2)), 0)
INSERT [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA], [DATA_EMISSAO], [VALOR_MERCADORIA], [VALOR_DESCONTO], [VALOR_FRETE], [VALOR_TOTAL], [STATUS]) VALUES (6, CAST(N'2018-02-12 09:56:04.0000000' AS DateTime2), CAST(18500.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), CAST(60.00 AS Numeric(18, 2)), CAST(18580.00 AS Numeric(18, 2)), 0)
INSERT [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA], [DATA_EMISSAO], [VALOR_MERCADORIA], [VALOR_DESCONTO], [VALOR_FRETE], [VALOR_TOTAL], [STATUS]) VALUES (7, CAST(N'2018-02-10 09:56:17.0000000' AS DateTime2), CAST(50500.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), CAST(60.00 AS Numeric(18, 2)), CAST(50580.00 AS Numeric(18, 2)), 0)
INSERT [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA], [DATA_EMISSAO], [VALOR_MERCADORIA], [VALOR_DESCONTO], [VALOR_FRETE], [VALOR_TOTAL], [STATUS]) VALUES (8, CAST(N'2018-02-01 09:56:29.0000000' AS DateTime2), CAST(100500.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)), CAST(60.00 AS Numeric(18, 2)), CAST(100580.00 AS Numeric(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[TB_NOTA_COMPRA] OFF
SET IDENTITY_INSERT [dbo].[TB_USUARIO] ON 

INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (1, N'user1', N'123', 1, CAST(0.00 AS Numeric(18, 2)), CAST(1000.00 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (2, N'user2', N'123', 1, CAST(1000.01 AS Numeric(18, 2)), CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (3, N'user3', N'123', 1, CAST(10000.01 AS Numeric(18, 2)), CAST(50000.00 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (4, N'user4', N'123', 1, CAST(50000.01 AS Numeric(18, 2)), CAST(999999.99 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (5, N'user5', N'123', 2, CAST(50000.01 AS Numeric(18, 2)), CAST(999999.99 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (6, N'user6', N'123', 1, CAST(50000.01 AS Numeric(18, 2)), CAST(999999.99 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (7, N'user7', N'123', 2, CAST(50000.01 AS Numeric(18, 2)), CAST(999999.99 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (8, N'user8', N'123', 1, CAST(10000.01 AS Numeric(18, 2)), CAST(50000.00 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (9, N'user9', N'123', 2, CAST(10000.01 AS Numeric(18, 2)), CAST(50000.00 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (10, N'user10', N'123', 2, CAST(1000.01 AS Numeric(18, 2)), CAST(10000.00 AS Numeric(18, 2)))
INSERT [dbo].[TB_USUARIO] ([ID_USUARIO], [LOGIN], [SENHA], [PAPEL], [VALOR_MIN_VISTO_APROVACAO], [VALOR_MAX_VISTO_APROVACAO]) VALUES (11, N'user0', N'123', 2, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[TB_USUARIO] OFF
ALTER TABLE [dbo].[TB_HISTORICO_APROVACAO]  WITH CHECK ADD FOREIGN KEY([ID_NOTA_COMPRA])
REFERENCES [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA])
GO
ALTER TABLE [dbo].[TB_HISTORICO_APROVACAO]  WITH CHECK ADD FOREIGN KEY([ID_NOTA_COMPRA])
REFERENCES [dbo].[TB_NOTA_COMPRA] ([ID_NOTA_COMPRA])
GO
ALTER TABLE [dbo].[TB_HISTORICO_APROVACAO]  WITH CHECK ADD FOREIGN KEY([ID_USUARIO])
REFERENCES [dbo].[TB_USUARIO] ([ID_USUARIO])
GO
ALTER TABLE [dbo].[TB_HISTORICO_APROVACAO]  WITH CHECK ADD FOREIGN KEY([ID_USUARIO])
REFERENCES [dbo].[TB_USUARIO] ([ID_USUARIO])
GO
