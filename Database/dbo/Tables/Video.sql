CREATE TABLE [dbo].[Video] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [YoutubeId]           NVARCHAR (50)  NOT NULL,
    [Title]               NVARCHAR (100) NOT NULL,
    [Description]         NVARCHAR (250) NULL,
    [YoutubeChannelId]    NVARCHAR (150) NULL,
    [YoutubeChannelTitle] NVARCHAR (50)  NULL,
    [PublishedAt]         DATETIME       NOT NULL,
    CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED ([Id] ASC)
);

