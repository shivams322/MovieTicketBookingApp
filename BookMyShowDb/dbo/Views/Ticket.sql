CREATE VIEW [dbo].[Ticket]
	AS 
Select [User].[Id],[Booking].[Id]AS [BookingId],[Show].[Id]AS[ShowId],[User].[Name],[Movie].[Title] AS [MovieName],[Cinema].[CinemaName] AS [Cinema],[Show].[StartTime] AS [MovieTimings] ,[Booking].[NoOfSeats] ,[ShowSeat].[SeatNumber]
FROM [dbo].[Movie]
INNER JOIN [dbo].[Show] ON [Movie].[Id]=[Show].[MovieId]
INNER JOIN [dbo].[Cinema] ON [Show].[CinemaId]=[Cinema].[Id]
INNER JOIN [dbo].[Booking] ON [Show].[Id]=[Booking].[ShowId]
INNER JOIN [dbo].[ShowSeat] ON [Booking].[Id]=[ShowSeat].[BookingId]
INNER JOIN [dbo].[User] ON [Booking].[UserId]=[User].[Id];