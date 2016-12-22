CREATE PROCEDURE dbo.GetHotVideos
	@UserId INT,
	@DateFrom DATETIME,
	@NumberOfVideos INT
AS
BEGIN
	
	SELECT TOP (@NumberOfVideos) * FROM Video v
	WHERE v.PublishedAt > @DateFrom
	AND v.Id NOT IN (SELECT [VideoId] FROM [dbo].[UserVideoWatched] WHERE UserId = @UserId)
	ORDER BY v.PublishedAt

END