DROP TABLE Temperature ;

CREATE TABLE [dbo].[Temperature] (
    [ID]       INT        IDENTITY (1, 1) NOT NULL,
    [Time]     FLOAT (53) NULL,
    [Level]    INT        NULL,
    [Volt]     FLOAT (53) NULL,
    [TempC]    FLOAT (53) NULL,
    [DateTime] TEXT       NULL,
    [TempID]   INT        NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);