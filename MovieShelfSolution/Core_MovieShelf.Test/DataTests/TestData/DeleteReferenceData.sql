  DELETE
  FROM [MovieSeries]
  
  DBCC CHECKIDENT ([MovieSeries], RESEED, 0)
  
  DELETE
  FROM [MovieType]
  
  DBCC CHECKIDENT ([MovieType], RESEED, 0)
  
  DELETE
  FROM [GenreType]
  
  DBCC CHECKIDENT ([GenreType], RESEED, 0)

  DELETE
  FROM [RatingType]
  
  DBCC CHECKIDENT ([RatingType], RESEED, 0)

  DELETE
  FROM [StatusType]
  
  DBCC CHECKIDENT ([StatusType], RESEED, 0)

  DELETE
  FROM [ViewRatingType]
  
  DBCC CHECKIDENT ([ViewRatingType], RESEED, 0)

  DELETE
  FROM [DisplayImage]
  
  DBCC CHECKIDENT ([DisplayImage], RESEED, 0)