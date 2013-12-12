USE [MovieShelf]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RatingType_DisplayImage]') AND parent_object_id = OBJECT_ID(N'[dbo].[RatingType]'))
ALTER TABLE [dbo].[RatingType] DROP CONSTRAINT [FK_RatingType_DisplayImage]
GO


USE [MovieShelf]
GO

/****** Object:  Table [dbo].[RatingType]    Script Date: 12/23/2011 19:57:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RatingType]') AND type in (N'U'))
DROP TABLE [dbo].[RatingType]
GO

USE [MovieShelf]
GO

/****** Object:  Table [dbo].[RatingType]    Script Date: 12/23/2011 19:57:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RatingType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DisplayImageId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[RatingType]  WITH CHECK ADD  CONSTRAINT [FK_RatingType_DisplayImage] FOREIGN KEY([DisplayImageId])
REFERENCES [dbo].[DisplayImage] ([Id])
GO

ALTER TABLE [dbo].[RatingType] CHECK CONSTRAINT [FK_RatingType_DisplayImage]
GO



