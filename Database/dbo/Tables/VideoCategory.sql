CREATE TABLE [dbo].[VideoCategory] (
    [Id]                    INT           IDENTITY (1, 1) NOT NULL,
    [VideoCategoryName]     NVARCHAR (50) NOT NULL,
    [YoutbeVideoCategoryId] NVARCHAR (5)  NOT NULL,
    CONSTRAINT [PK_VideoCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

