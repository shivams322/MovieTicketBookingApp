﻿/*
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
PRINT N'Rename refactoring operation with key bae90c4c-38a7-4838-bd48-5bca58012f5b is skipped, element [dbo].[Booking].[No] (SqlSimpleColumn) will not be renamed to NoOfSeats';


GO
PRINT N'Rename refactoring operation with key 75410d55-638b-4633-b3fd-b1e4722b8d05, 64c9669a-e2ec-4146-b3d5-8a694de4679e is skipped, element [dbo].[Booking].[Timings] (SqlSimpleColumn) will not be renamed to BookTime';


GO
PRINT N'Creating Table [dbo].[Booking]...';


GO
CREATE TABLE [dbo].[Booking] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [NoOfSeats] INT      NOT NULL,
    [BookTime]  DATETIME NOT NULL,
    [UserId]    INT      NOT NULL,
    [ShowId]    INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[CinemaSeat]...';


GO
CREATE TABLE [dbo].[CinemaSeat] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [SeatNumber] INT NOT NULL,
    [CinemaId]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Show]...';


GO
CREATE TABLE [dbo].[Show] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [Date]      DATE     NOT NULL,
    [StartTime] TIME (7) NOT NULL,
    [EndTime]   TIME (7) NOT NULL,
    [CinemaId]  INT      NOT NULL,
    [MovieId]   INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[UserSeat]...';


GO
CREATE TABLE [dbo].[UserSeat] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [price]        INT NOT NULL,
    [Status]       BIT NOT NULL,
    [CinemaSeatId] INT NOT NULL,
    [ShowId]       INT NOT NULL,
    [BookingId]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Default Constraint unnamed constraint on [dbo].[UserSeat]...';


GO
ALTER TABLE [dbo].[UserSeat]
    ADD DEFAULT 200 FOR [price];


GO
PRINT N'Creating Default Constraint unnamed constraint on [dbo].[UserSeat]...';


GO
ALTER TABLE [dbo].[UserSeat]
    ADD DEFAULT 0 FOR [Status];


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'bae90c4c-38a7-4838-bd48-5bca58012f5b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('bae90c4c-38a7-4838-bd48-5bca58012f5b')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '453d1e8b-c9eb-4042-a2ec-dcfe226fe075')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('453d1e8b-c9eb-4042-a2ec-dcfe226fe075')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '17ecfab0-1e79-4d4f-8aa9-9e5e5ac2d201')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('17ecfab0-1e79-4d4f-8aa9-9e5e5ac2d201')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '75410d55-638b-4633-b3fd-b1e4722b8d05')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('75410d55-638b-4633-b3fd-b1e4722b8d05')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '64c9669a-e2ec-4146-b3d5-8a694de4679e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('64c9669a-e2ec-4146-b3d5-8a694de4679e')

GO

GO
PRINT N'Update complete.';


GO