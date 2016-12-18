CREATE TABLE [dbo].[YoutubeChannel] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50)  NOT NULL,
    [Description]      NVARCHAR (250) NULL,
    [YoutubeChannelId] NVARCHAR (150) NOT NULL,
    [UploadPlaylistId] NVARCHAR (150) NULL,
    CONSTRAINT [PK_YoutubeChannel] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_YoutubeChannelId] UNIQUE NONCLUSTERED ([Id] ASC, [YoutubeChannelId] ASC)
);





