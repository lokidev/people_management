CREATE DATABASE PeopleManagement;
GO
USE PeopleManagement;
GO

USE [PeopleManagement]
GO

/****** Object:  Table [dbo].[People]    Script Date: 9/17/2021 3:47:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[Gender] [bit] NULL,
	[Luck] [float] NULL,
	[Education] [float] NULL,
	[Health] [float] NULL,
	[Hunger] [float] NULL,
	[Security] [float] NULL,
	[AvailableFood] [float] NULL,
    [AvailableResources] [float] NULL,
    [Mate] [int] NULL,
	[CreationDate] [datetime] NOT NULL,
	[BirthDate] [datetime] NULL,
	[DeathDate] [datetime] NULL,
	[DestructionDate] [datetime] NULL,
	[IdentificationTags] [varchar](max) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_People_IdentificationTags_JSON]') AND parent_object_id = OBJECT_ID(N'[dbo].[People]'))
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [CK_People_IdentificationTags_JSON] CHECK  ((isjson([IdentificationTags])=(1)))
GO