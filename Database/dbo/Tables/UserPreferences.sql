CREATE TABLE [dbo].[UserPreferences] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [UserId]            INT             NOT NULL,
    [YoutubeCategoryId] INT             NOT NULL,
    [Score]             DECIMAL (10, 4) NOT NULL,
    CONSTRAINT [PK_UserPreferences] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserPreferences_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserPreferences_VideoCategory] FOREIGN KEY ([YoutubeCategoryId]) REFERENCES [dbo].[VideoCategory] ([Id])
);

