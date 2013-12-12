USE [MovieShelf]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ViewRatingType_DisplayImage]') AND parent_object_id = OBJECT_ID(N'[dbo].[ViewRatingType]'))
ALTER TABLE [dbo].[ViewRating] DROP CONSTRAINT [FK_ViewRatingType_DisplayImage]
GO

USE [MovieShelf]
GO

/****** Object:  Table [dbo].[ViewRatingType]    Script Date: 12/23/2011 19:56:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewRatingType]') AND type in (N'U'))
DROP TABLE [dbo].[ViewRatingType]
GO

USE [MovieShelf]
GO

/****** Object:  Table [dbo].[ViewRatingType]    Script Date: 12/23/2011 19:56:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ViewRatingType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DisplayImageId] [int] NULL,
	[IsDeleted] [bit] NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ViewRating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ViewRatingType]  WITH CHECK ADD  CONSTRAINT [FK_ViewRatingType_DisplayImage] FOREIGN KEY([DisplayImageId])
REFERENCES [dbo].[DisplayImage] ([Id])
GO

ALTER TABLE [dbo].[ViewRatingType] CHECK CONSTRAINT [FK_ViewRatingType_DisplayImage]
GO



