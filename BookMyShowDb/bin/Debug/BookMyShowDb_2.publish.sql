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
PRINT N'Starting rebuilding table [dbo].[Admin]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Admin] (
    [AdminId]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([AdminId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Admin])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Admin] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Admin] ([AdminId], [Name], [Email], [Password])
        SELECT   [AdminId],
                 [Name],
                 [Email],
                 [Password]
        FROM     [dbo].[Admin]
        ORDER BY [AdminId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Admin] OFF;
    END

DROP TABLE [dbo].[Admin];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Admin]', N'Admin';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Cinema]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Cinema] (
    [CinemaId]   INT            IDENTITY (1, 1) NOT NULL,
    [CinemaName] NVARCHAR (MAX) NOT NULL,
    [TotalSeats] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([CinemaId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Cinema])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Cinema] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Cinema] ([CinemaId], [CinemaName], [TotalSeats])
        SELECT   [CinemaId],
                 [CinemaName],
                 [TotalSeats]
        FROM     [dbo].[Cinema]
        ORDER BY [CinemaId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Cinema] OFF;
    END

DROP TABLE [dbo].[Cinema];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Cinema]', N'Cinema';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Movie]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Movie] (
    [MovieId]     INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Language]    NVARCHAR (50)  NOT NULL,
    [ReleaseDate] DATETIME       NOT NULL,
    [Genre]       NVARCHAR (50)  NOT NULL,
    [Duration]    DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([MovieId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Movie])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Movie] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Movie] ([MovieId], [Title], [Description], [Language], [ReleaseDate], [Genre], [Duration])
        SELECT   [MovieId],
                 [Title],
                 [Description],
                 [Language],
                 [ReleaseDate],
                 [Genre],
                 [Duration]
        FROM     [dbo].[Movie]
        ORDER BY [MovieId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Movie] OFF;
    END

DROP TABLE [dbo].[Movie];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Movie]', N'Movie';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Update complete.';


GO
