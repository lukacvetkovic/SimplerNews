CREATE TABLE [dbo].[VideoTag] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [VideoId] INT           NOT NULL,
    [Tag]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_VideoTags] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VideoTags_Video] FOREIGN KEY ([VideoId]) REFERENCES [dbo].[Video] ([Id])
);

