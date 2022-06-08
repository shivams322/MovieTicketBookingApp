CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Language] NVARCHAR(50) NOT NULL, 
    [ReleaseDate] DATETIME NOT NULL, 
    [Genre] NVARCHAR(50) NOT NULL, 
    [Duration] NVARCHAR(50) NOT NULL, 
    [MoviePoster] IMAGE NULL DEFAULT NULL
)
