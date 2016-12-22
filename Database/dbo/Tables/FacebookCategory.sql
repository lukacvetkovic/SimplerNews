CREATE TABLE [dbo].[FacebookCategory] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_FacebookCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

