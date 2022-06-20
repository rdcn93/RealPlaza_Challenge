USE [master]
GO

CREATE DATABASE [RealPlaza_Challenge]
GO

USE [RealPlaza_Challenge]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[description] [text] NULL,
	[status] [bit] NULL,
	[price] [decimal](18, 0) NULL,
	[discount] [decimal](18, 0) NULL,
	[quantity] [int] NULL,
	[inserted_time] [datetime] NULL,
	[updated_time] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nchar](20) NULL,
	[email] [nchar](50) NULL,
	[password] [text] NULL,
	[inserted_time] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

