CREATE TABLE [dbo].[UserInformation] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50)  NOT NULL,
    [Email]    NVARCHAR (50)  NULL,
    [Location] NVARCHAR (50)  NULL,
    [UserId]   NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserInformation_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

