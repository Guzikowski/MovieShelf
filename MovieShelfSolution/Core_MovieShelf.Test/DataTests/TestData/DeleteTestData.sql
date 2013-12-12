
  DELETE
  FROM [BorrowedItem]
  
  DBCC CHECKIDENT ([BorrowedItem], RESEED, 0)
  
  DELETE
  FROM [Borrower]
  
  DBCC CHECKIDENT ([Borrower], RESEED, 0)
  
  DELETE
  FROM [MovieDetail]
  
  DBCC CHECKIDENT ([MovieDetail], RESEED, 0)