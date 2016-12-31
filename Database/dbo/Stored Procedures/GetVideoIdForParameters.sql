CREATE PROCEDURE [dbo].[GetVideoIdForParameters]
	@UserId int,
	@CategoryId int
AS
BEGIN
	DECLARE @VideoId int;
	DECLARE @now  DATETIME = GETUTCDATE();
	DECLARE @fivedaysago  DATETIME= dateadd(day,-10,@now);


	SET @VideoId = (SELECT TOP 1 vid.Id
	FROM Video vid
	WHERE vid.PublishedAt > @fivedaysago
	AND vid.Id NOT IN (SELECT VideoId FROM UserVideoWatched WHERE UserId = @UserId)
	AND vid.VideoCategoryId = @CategoryId);


	RETURN @VideoId

END;
