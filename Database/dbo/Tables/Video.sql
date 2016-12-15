CREATE TABLE [dbo].[Video] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [YoutubeId]        NVARCHAR (50)  NOT NULL,
    [Title]            NVARCHAR (100) NOT NULL,
    [Description]      NVARCHAR (250) NULL,
    [YoutubeChannelId] INT            NOT NULL,
    [PublishedAt]      DATETIME       NOT NULL,
    [YoutubeLink]      NVARCHAR (250) NULL,
    [VideoCategoryId]  INT            NULL,
    CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Video_VideoCategory] FOREIGN KEY ([VideoCategoryId]) REFERENCES [dbo].[VideoCategory] ([Id]),
    CONSTRAINT [FK_Video_YoutubeChannel] FOREIGN KEY ([YoutubeChannelId]) REFERENCES [dbo].[YoutubeChannel] ([Id])
);



