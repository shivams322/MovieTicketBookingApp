CREATE VIEW [dbo].[MovieList]
	AS 
SELECT [Movie].[Id],[Movie].[Title],[Movie].[Description],[Movie].[Language],[Movie].[ReleaseDate],[Movie].[Genre],[Movie].[Duration],[Image].[MovieImage]
FROM [dbo].[Movie]
INNER JOIN [dbo].[Image] 
ON [Movie].[Id]=[Image].[MovieId]