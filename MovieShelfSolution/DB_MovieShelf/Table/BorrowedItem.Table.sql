USE [MovieShelf]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BorrowedItem_Borrower]') AND parent_object_id = OBJECT_ID(N'[dbo].[BorrowedItem]'))
ALTER TABLE [dbo].[BorrowedItem] DROP CONSTRAINT [FK_BorrowedItem_Borrower]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BorrowedItem_MovieDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[BorrowedItem]'))
ALTER TABLE [dbo].[BorrowedItem] DROP CONSTRAINT [FK_BorrowedItem_MovieDetail]
GO

USE [MovieShelf]
GO

/****** Object:  Table [dbo].[BorrowedItem]    Script Date: 12/23/2011 19:57:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BorrowedItem]') AND type in (N'U'))
DROP TABLE [dbo].[BorrowedItem]
GO

USE [MovieShelf]
GO

/****** Object:  Table [dbo].[BorrowedItem]    Script Date: 12/23/2011 19:57:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BorrowedItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BorrowerId] [int] NOT NULL,
	[MovieDetailId] [int] NOT NULL,
	[DateBorrowed] [datetime] NOT NULL,
	[DateReturned] [datetime] NULL,
	[OverdueDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[TimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_BorrowedItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[BorrowedItem]  WITH CHECK ADD  CONSTRAINT [FK_BorrowedItem_Borrower] FOREIGN KEY([BorrowerId])
REFERENCES [dbo].[Borrower] ([Id])
GO

ALTER TABLE [dbo].[BorrowedItem] CHECK CONSTRAINT [FK_BorrowedItem_Borrower]
GO

ALTER TABLE [dbo].[BorrowedItem]  WITH CHECK ADD  CONSTRAINT [FK_BorrowedItem_MovieDetail] FOREIGN KEY([MovieDetailId])
REFERENCES [dbo].[MovieDetail] ([Id])
GO

ALTER TABLE [dbo].[BorrowedItem] CHECK CONSTRAINT [FK_BorrowedItem_MovieDetail]
GO


