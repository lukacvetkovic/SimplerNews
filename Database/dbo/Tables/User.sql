CREATE TABLE [dbo].[User] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [Email]  NVARCHAR (256) NOT NULL,
    [Token]  NVARCHAR (150) NOT NULL,
    [Gender] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

