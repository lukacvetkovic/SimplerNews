CREATE TABLE [dbo].[FacebookYoutubeMapping] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [FacebookCategoryId] INT NOT NULL,
    [VideoCategoryId]    INT NOT NULL,
    CONSTRAINT [PK_FacebookYoutubeMapping] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FacebookYoutubeMapping_FacebookCategory] FOREIGN KEY ([FacebookCategoryId]) REFERENCES [dbo].[FacebookCategory] ([Id]),
    CONSTRAINT [FK_FacebookYoutubeMapping_VideoCategory] FOREIGN KEY ([VideoCategoryId]) REFERENCES [dbo].[VideoCategory] ([Id])
);

