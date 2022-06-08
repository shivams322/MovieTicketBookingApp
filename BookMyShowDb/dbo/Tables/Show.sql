CREATE TABLE [dbo].[Show]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1) , 
    [Date] DATETIME NOT NULL, 
    [StartTime] DATETIME NOT NULL, 
    [EndTime] DATETIME NOT NULL, 
    [CinemaId] INT NOT NULL, 
    [MovieId] INT NOT NULL
)
