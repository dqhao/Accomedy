
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wsp_get_post_detail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[wsp_get_post_detail] AS' 
END
GO

ALTER PROCEDURE [dbo].[wsp_get_post_detail]  
(
	@POST_ID VARCHAR(128)
)
AS
BEGIN
	
	SELECT *
	FROM dbo.POSTS
	WHERE POST_ID = @POST_ID
	
END
GO
