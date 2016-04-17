CREATE TABLE [dbo].[Temperatures] (
    [Id]       INT  NOT NULL,
    [Time]     FLOAT NOT NULL,
    [Level]    INT  NULL,
    [Volt]     FLOAT NOT NULL,
    [TempC]    FLOAT NOT NULL,
    [DateTime] TEXT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

