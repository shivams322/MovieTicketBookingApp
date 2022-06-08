CREATE TABLE [dbo].[Cinema]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CinemaName] NVARCHAR(MAX) NOT NULL, 
    [TotalSeats] INT NOT NULL
)
