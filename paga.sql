USE [salary]
GO
/****** Object:  Table [dbo].[Datat_e_Festave_Zyrtare]    Script Date: 09.08.2021 15:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Datat_e_Festave_Zyrtare](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ditet_e_punes]    Script Date: 09.08.2021 15:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ditet_e_punes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_punonjes] [int] NOT NULL,
	[Emri] [varchar](50) NOT NULL,
	[Data] [date] NOT NULL,
	[ore] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagesat_dit_specifike]    Script Date: 09.08.2021 15:30:36 ******/
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
/****** Object:  Table [dbo].[Punonjes]    Script Date: 09.08.2021 15:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Punonjes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Emri] [varchar](50) NOT NULL,
	[Rroga] [decimal](10, 0) NOT NULL
) ON [PRIMARY]
GO
