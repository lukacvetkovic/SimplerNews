CREATE TABLE [dbo].[Video] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Etag]             NVARCHAR (250)  NULL,
    [Kind]             NVARCHAR (250)  NULL,
    [YoutubeId]        NVARCHAR (250)  NOT NULL,
    [Title]            NVARCHAR (1000) NULL,
    [Description]      NVARCHAR (MAX)  NULL,
    [YoutubeChannelId] INT             NOT NULL,
    [PublishedAt]      DATETIME        NOT NULL,
    [YoutubeLink]      NVARCHAR (250)  NULL,
    [NumberOfViews]    INT             NULL,
    [NumberOfLikes]    INT             NULL,
    [NumberOfDislikes] INT             NULL,
    [NumberOfComments] INT             NULL,
    [VideoCategoryId]  INT             NULL,
    CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Video_VideoCategory] FOREIGN KEY ([VideoCategoryId]) REFERENCES [dbo].[VideoCategory] ([Id]),
    CONSTRAINT [FK_Video_YoutubeChannel] FOREIGN KEY ([YoutubeChannelId]) REFERENCES [dbo].[YoutubeChannel] ([Id])
);









