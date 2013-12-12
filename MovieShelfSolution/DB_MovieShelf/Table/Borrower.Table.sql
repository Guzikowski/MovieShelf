USE [MovieShelf]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Borrower_DisplayImage]') AND parent_object_id = OBJECT_ID(N'[dbo].[Borrower]'))
ALTER TABLE [dbo].[Borrower] DROP CONSTRAINT [FK_Borrower_DisplayImage]
GO

USE [MovieShelf]
GO

/****** Object:  Table [dbo].[Borrower]    Script Date: 12/23/2011 19:57:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Borrower]') AND type in (N'U'))
DROP TABLE [dbo].[Borrower]
GO

USE [MovieShelf]
GO

/****** Object:  Table [dbo].[Borrower]    Script Date: 12/23/2011 19:57:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Borrower](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayImageId] [int] NULL,
	[IsDeleted] [bit] NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](50) NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Borrower] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Borrower]  WITH CHECK ADD  CONSTRAINT [FK_Borrower_DisplayImage] FOREIGN KEY([DisplayImageId])
REFERENCES [dbo].[DisplayImage] ([Id])
GO

ALTER TABLE [dbo].[Borrower] CHECK CONSTRAINT [FK_Borrower_DisplayImage]
GO


