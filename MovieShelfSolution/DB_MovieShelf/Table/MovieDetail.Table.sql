USE [MovieShelf]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MovieDetail_MovieSeries]') AND parent_object_id = OBJECT_ID(N'[dbo].[MovieDetail]'))
ALTER TABLE [dbo].[MovieDetail] DROP CONSTRAINT [FK_MovieDetail_MovieSeries]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MovieDetail_GenreType]') AND parent_object_id = OBJECT_ID(N'[dbo].[MovieDetail]'))
ALTER TABLE [dbo].[MovieDetail] DROP CONSTRAINT [FK_MovieDetail_GenreType]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MovieDetail_DisplayImage]') AND parent_object_id = OBJECT_ID(N'[dbo].[MovieDetail]'))
ALTER TABLE [dbo].[MovieDetail] DROP CONSTRAINT [FK_MovieDetail_DisplayImage]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MovieDetail_RatingType]') AND parent_object_id = OBJECT_ID(N'[dbo].[MovieDetail]'))
ALTER TABLE [dbo].[MovieDetail] DROP CONSTRAINT [FK_MovieDetail_RatingType]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MovieDetail_StatusType]') AND parent_object_id = OBJECT_ID(N'[dbo].[MovieDetail]'))
ALTER TABLE [dbo].[MovieDetail] DROP CONSTRAINT [FK_MovieDetail_StatusType]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MovieDetail_MovieType]') AND parent_object_id = OBJECT_ID(N'[dbo].[MovieDetail]'))
ALTER TABLE [dbo].[MovieDetail] DROP CONSTRAINT [FK_MovieDetail_MovieType]
GO

USE [MovieShelf]
GO

/****** Object:  Table [dbo].[MovieDetail]    Script Date: 12/23/2011 19:57:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MovieDetail]') AND type in (N'U'))
DROP TABLE [dbo].[MovieDetail]
GO

USE [MovieShelf]
GO

/****** Object:  Table [dbo].[MovieDetail]    Script Date: 12/23/2011 19:57:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MovieDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieSeriesId] [int] NULL,
	[GenreTypeId] [int] NULL,
	[MovieTypeId] [int] NULL,
	[StatusTypeId] [int] NULL,
	[RatingTypeId] [int] NULL,
	[DisplayImageId] [int] NULL,
	[ViewRatingId] [int] NULL,
	[Title] [varchar](100) NOT NULL,
	[Value] [money] NULL,
	[DateCollected] [datetime] NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_MovieDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[MovieDetail]  WITH CHECK ADD  CONSTRAINT [FK_MovieDetail_MovieSeries] FOREIGN KEY([MovieSeriesId])
REFERENCES [dbo].[MovieSeries] ([Id])
GO

ALTER TABLE [dbo].[MovieDetail] CHECK CONSTRAINT [FK_MovieDetail_MovieSeries]
GO

ALTER TABLE [dbo].[MovieDetail]  WITH CHECK ADD  CONSTRAINT [FK_MovieDetail_GenreType] FOREIGN KEY([GenreTypeId])
REFERENCES [dbo].[GenreType] ([Id])
GO

ALTER TABLE [dbo].[MovieDetail] CHECK CONSTRAINT [FK_MovieDetail_GenreType]
GO

ALTER TABLE [dbo].[MovieDetail]  WITH CHECK ADD  CONSTRAINT [FK_MovieDetail_DisplayImage] FOREIGN KEY([DisplayImageId])
REFERENCES [dbo].[DisplayImage] ([Id])
GO

ALTER TABLE [dbo].[MovieDetail] CHECK CONSTRAINT [FK_MovieDetail_DisplayImage]
GO

ALTER TABLE [dbo].[MovieDetail]  WITH CHECK ADD  CONSTRAINT [FK_MovieDetail_RatingType] FOREIGN KEY([RatingTypeId])
REFERENCES [dbo].[RatingType] ([Id])
GO

ALTER TABLE [dbo].[MovieDetail] CHECK CONSTRAINT [FK_MovieDetail_RatingType]
GO

ALTER TABLE [dbo].[MovieDetail]  WITH CHECK ADD  CONSTRAINT [FK_MovieDetail_StatusType] FOREIGN KEY([StatusTypeId])
REFERENCES [dbo].[StatusType] ([Id])
GO

ALTER TABLE [dbo].[MovieDetail] CHECK CONSTRAINT [FK_MovieDetail_StatusType]
GO

ALTER TABLE [dbo].[MovieDetail]  WITH CHECK ADD  CONSTRAINT [FK_MovieDetail_MovieType] FOREIGN KEY([MovieTypeId])
REFERENCES [dbo].[MovieType] ([Id])
GO

ALTER TABLE [dbo].[MovieDetail] CHECK CONSTRAINT [FK_MovieDetail_MovieType]
GO


