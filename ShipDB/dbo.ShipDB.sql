CREATE TABLE [dbo].[ShipDB] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [MaxSpeedShip] INT              NOT NULL,
    [LengthShip]   INT              NOT NULL,
    [IdSHip]       UNIQUEIDENTIFIER NULL,
    [TypeShip] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

