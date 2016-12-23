CREATE TABLE [dbo].[FacebookCategory] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [CategoryName]    NVARCHAR (150) NOT NULL,
    [VideoCategoryId] INT            NULL,
    CONSTRAINT [PK_FacebookCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FacebookCategory_VideoCategory] FOREIGN KEY ([VideoCategoryId]) REFERENCES [dbo].[VideoCategory] ([Id])
);



