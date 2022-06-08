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
/*
The column [dbo].[UserSeat].[CinemaId] on table [dbo].[UserSeat] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[UserSeat])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'The following operation was generated from a refactoring log file f22b37f7-30d9-4070-ae66-25d6997df867';

PRINT N'Rename [dbo].[UserSeat].[CinemaSeatId] to SeatNumber';


GO
EXECUTE sp_rename @objname = N'[dbo].[UserSeat].[CinemaSeatId]', @newname = N'SeatNumber', @objtype = N'COLUMN';


GO
PRINT N'Altering Table [dbo].[UserSeat]...';


GO
ALTER TABLE [dbo].[UserSeat]
    ADD [CinemaId] INT NOT NULL;


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f22b37f7-30d9-4070-ae66-25d6997df867')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f22b37f7-30d9-4070-ae66-25d6997df867')

GO

GO
PRINT N'Update complete.';


GO