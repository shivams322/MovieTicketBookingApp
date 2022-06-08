CREATE TABLE [dbo].[Image]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MovieId] INT NOT NULL, 
    [MovieImage] VARBINARY(MAX) NOT NULL
)
