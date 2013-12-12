﻿
 INSERT INTO [DisplayImage] ([Name], [Location], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Image1','c:\images\image1.png', 0, 'TestData', getdate())
 INSERT INTO [DisplayImage] ([Name], [Location], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Image2', 'c:\images\image2.png', 0, 'TestData', getdate())
 INSERT INTO [DisplayImage] ([Name], [Location], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Image3','c:\images\image3.png', 0, 'TestData', getdate())
 
 INSERT INTO [MovieSeries] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('The Chronicles of Timelessness', 1, 0, 'TestData', getdate())
 INSERT INTO [MovieSeries] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('The Night Sun Trilogy', 2, 0, 'TestData', getdate())
 INSERT INTO [MovieSeries] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('The Cold Sight Series', NULL, 0, 'TestData', getdate())
 
 INSERT INTO [MovieType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('DVD', 1, 0, 'TestData', getdate())
 INSERT INTO [MovieType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('BluRay', 2, 0, 'TestData', getdate())
 INSERT INTO [MovieType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Digital', NULL, 0, 'TestData', getdate())

 INSERT INTO [GenreType] ([Name],  [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Sci-Fi', 1, 0, 'TestData', getdate())
 INSERT INTO [GenreType] ([Name],  [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Action', 2, 0, 'TestData', getdate())
 INSERT INTO [GenreType] ([Name],  [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Drama', NULL, 0, 'TestData', getdate())

 INSERT INTO [RatingType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('G', 1, 0, 'TestData', getdate())
 INSERT INTO [RatingType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('PG-13', 2, 0, 'TestData', getdate())
 INSERT INTO [RatingType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('R', NULL, 0, 'TestData', getdate())

 INSERT INTO [StatusType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Owned', 1, 0, 'TestData', getdate())
 INSERT INTO [StatusType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Wanted', 2, 0, 'TestData', getdate())
 INSERT INTO [StatusType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Lost', NULL, 0, 'TestData', getdate())
  
 INSERT INTO [ViewRatingType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Poor', 1, 0, 'TestData', getdate())
 INSERT INTO [ViewRatingType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Mediocre', 2, 0, 'TestData', getdate())
 INSERT INTO [ViewRatingType] ([Name], [DisplayImageId], [IsDeleted], [ModifiedBy], [ModifiedDate]) 
 VALUES  ('Good', NULL, 0, 'TestData', getdate())

