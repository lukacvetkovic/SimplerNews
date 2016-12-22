CREATE TABLE [dbo].[UserVideoWatched] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [VideoId] INT NOT NULL,
    [UserId]  INT NOT NULL,
    CONSTRAINT [PK_UserVideoWatched] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserVideoWatched_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserVideoWatched_Video] FOREIGN KEY ([VideoId]) REFERENCES [dbo].[Video] ([Id])
);



