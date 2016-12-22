CREATE PROCEDURE [dbo].[ResetUserPreferences]
	@UserId int
AS
BEGIN	
	DELETE FROM dbo.UserPreferences 
	WHERE UserId = @UserId

	INSERT INTO [dbo].[UserPreferences]
           ([UserId]
           ,[YoutubeCategoryId]
           ,[Score])
	SELECT u.Id, vc.Id , 1 
	FROM [User] u 
		CROSS JOIN VideoCategory vc
	WHERE 
		u.Id = @UserId
END
