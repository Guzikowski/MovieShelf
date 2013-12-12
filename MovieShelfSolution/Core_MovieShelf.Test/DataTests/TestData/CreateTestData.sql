
INSERT INTO [Borrower] ([Name], [DisplayImageId], [IsDeleted], [Email], [Phone], [ModifiedBy], [ModifiedDate])     
       VALUES  ('John Doe', NULL, 0, 'abc@d.co.nz', '021345678', 'TESTDATA', getdate())

INSERT INTO [Borrower] ([Name], [DisplayImageId], [IsDeleted], [Email], [Phone], [ModifiedBy], [ModifiedDate])     
       VALUES  ('Jane Sticky', NULL, 0, '', '042994444', 'TESTDATA', getdate())
	   
INSERT INTO [Borrower] ([Name], [DisplayImageId], [IsDeleted], [Email], [Phone], [ModifiedBy], [ModifiedDate])     
       VALUES  ('Mike Fingers', NULL, 0, 'finger@me.com', '', 'TESTDATA', getdate())

  
       
  INSERT INTO [MovieDetail]
           ([Title], [MovieSeriesId], [GenreTypeId], [MovieTypeId], [StatusTypeId], [RatingTypeId], [DisplayImageId], [ViewRatingId], [Value], [DateCollected], [ModifiedBy], [ModifiedDate])
     VALUES
           ('Four Minutes Past Yesterday', 1, 1, 1, 1, 1, 1, 1, 5.00, getdate(), 'TESTDATA', getdate())

 INSERT INTO [MovieDetail]
           ([Title], [MovieSeriesId], [GenreTypeId], [MovieTypeId], [StatusTypeId], [RatingTypeId], [DisplayImageId], [ViewRatingId], [Value], [DateCollected], [ModifiedBy], [ModifiedDate])
     VALUES
           ('Moon Glorious', 2, 2, 2, 2, 2, 2, 2, 15.00, getdate(), 'TESTDATA', getdate())

 INSERT INTO [MovieDetail]
           ([Title], [MovieSeriesId], [GenreTypeId], [MovieTypeId], [StatusTypeId], [RatingTypeId], [DisplayImageId], [ViewRatingId], [Value], [DateCollected], [ModifiedBy], [ModifiedDate])
     VALUES
           ('Blind as a Mime', 3, 3, 3, 3, 3, 3, 3, 3.00, getdate(), 'TESTDATA', getdate())

 INSERT INTO [MovieDetail]
           ([Title], [MovieSeriesId], [GenreTypeId], [MovieTypeId], [StatusTypeId], [RatingTypeId], [DisplayImageId], [ViewRatingId], [Value], [DateCollected], [ModifiedBy], [ModifiedDate])
     VALUES
           ('Tomorrow is Today, Yesterday', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'TESTDATA', getdate())



INSERT INTO [BorrowedItem] ([BorrowerId], [MovieDetailId], [DateBorrowed], [DateReturned], [OverdueDate], [ModifiedBy], [ModifiedDate])     
       VALUES  (1, 1, getdate(), getdate(), getdate() + 1, 'TESTDATA', getdate())

INSERT INTO [BorrowedItem] ([BorrowerId], [MovieDetailId], [DateBorrowed], [DateReturned], [OverdueDate], [ModifiedBy], [ModifiedDate])     
       VALUES  (2, 2, getdate(), NULL, getdate() + 1, 'TESTDATA', getdate())
 
INSERT INTO [BorrowedItem] ([BorrowerId], [MovieDetailId], [DateBorrowed], [DateReturned], [OverdueDate], [ModifiedBy], [ModifiedDate])     
       VALUES  (3, 3, getdate() -1, NULL, getdate(), 'TESTDATA', getdate())

