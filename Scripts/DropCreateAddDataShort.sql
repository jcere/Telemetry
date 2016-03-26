IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Temperatures' AND TABLE_SCHEMA = 'dbo')
	DROP TABLE dbo.Temperatures;

CREATE TABLE [dbo].[Temperatures] (
    [Id]       INT        NOT NULL IDENTITY,
    [RemoteId] INT        NULL,
    [Time]     FLOAT (53) NOT NULL,
    [Level]    INT        NULL,
    [Volt]     FLOAT (53) NOT NULL,
    [TempC]    FLOAT (53) NOT NULL,
    [DateTime] TEXT       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (35, 1.44334e+09, 79, 0.255, 25.48, 'Sun Sep 27 09:00:02 2015');
INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (36, 1.44335e+09, 78, 0.252, 25.16, 'Sun Sep 27 10:00:01 2015');
INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (37, 1.44335e+09, 78, 0.252, 25.16, 'Sun Sep 27 11:00:02 2015');
INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (38, 1.44336e+09, 78, 0.252, 25.16, 'Sun Sep 27 12:00:01 2015');
INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (39, 1.44336e+09, 79, 0.255, 25.48, 'Sun Sep 27 13:00:01 2015');
INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (40, 1.44336e+09, 80, 0.258, 25.81, 'Sun Sep 27 14:00:02 2015');
INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (41, 1.44337e+09, 83, 0.268, 26.77, 'Sun Sep 27 15:00:01 2015');
INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (42, 1.44337e+09, 83, 0.268, 26.77, 'Sun Sep 27 16:00:02 2015');
INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (43, 1.44337e+09, 82, 0.265, 26.45, 'Sun Sep 27 17:00:01 2015');
INSERT INTO Temperatures (RemoteId, Time, Level, Volt, TempC, DateTime) VALUES (44, 1.44338e+09, 84, 0.271, 27.1, 'Sun Sep 27 18:00:01 2015');