CREATE VIEW [dbo].[ShowList]
	AS 
Select [Show].[Id],[Show].[Date],[Show].[StartTime],[Show].[EndTime],[Show].[CinemaId] ,[Show].[MovieId] ,[Movie].[Title],[Cinema].[CinemaName]
FROM [dbo].[Show]
INNER JOIN [dbo].[Movie] ON [Movie].[Id]=[Show].[MovieId]
INNER JOIN [dbo].[Cinema] ON [Show].[CinemaId]=[Cinema].[Id]
