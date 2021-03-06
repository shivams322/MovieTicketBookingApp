/*
Deployment script for BookMyShowDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BookMyShowDB"
:setvar DefaultFilePrefix "BookMyShowDB"
:setvar DefaultDataPath "C:\Users\ASUS\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\"
:setvar DefaultLogPath "C:\Users\ASUS\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating Procedure [dbo].[Ticket]...';


GO
CREATE PROCEDURE [dbo].[Ticket]
	@Id int 
AS
begin
	Select [User].[Name],[Movie].[Title],[Cinema].[CinemaName],[Show].[StartTime],[Booking].[NoOfSeats]
    FROM [dbo].[User]
    INNER JOIN [dbo].[Booking] ON [User].[Id]=[Booking].[UserId]
    INNER JOIN [dbo].[Show] ON [Booking].[ShowId]=[Show].[Id]
    INNER JOIN [dbo].[Movie] ON [Show].[MovieId]=[Movie].[Id]
    INNER JOIN [dbo].[Cinema] ON [Show].[CinemaId]=[Cinema].[Id]
    WHERE [User].[Id]= @Id;
end
GO
PRINT N'Update complete.';


GO
