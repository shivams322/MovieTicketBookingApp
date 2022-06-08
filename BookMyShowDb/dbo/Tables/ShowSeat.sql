CREATE TABLE [dbo].[ShowSeat]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [price] INT NOT NULL DEFAULT 200, 
    [Status] VARCHAR(50) NOT NULL DEFAULT 0, 
    [SeatNumber] INT NOT NULL, 
    [ShowId] INT NOT NULL, 
    [BookingId] INT NOT NULL, 
    [CinemaId] INT NOT NULL
)
