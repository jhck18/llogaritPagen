USE [salary]
GO
/****** Object:  Table [dbo].[Datat_e_Festave_Zyrtare]    Script Date: 10.08.2021 13:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Datat_e_Festave_Zyrtare](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ditet_e_punes]    Script Date: 10.08.2021 13:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ditet_e_punes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_punonjes] [int] NOT NULL,
	[data] [date] NOT NULL,
	[ore_pune] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagesat_dit_specifike]    Script Date: 10.08.2021 13:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagesat_dit_specifike](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Lloji] [varchar](50) NULL,
	[Perqindja] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Punonjes]    Script Date: 10.08.2021 13:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Punonjes](
	[id_punonjes] [int] IDENTITY(1,1) NOT NULL,
	[emri] [varchar](50) NOT NULL,
	[paga_mujore] [decimal](10, 2) NOT NULL
) ON [PRIMARY]
GO
