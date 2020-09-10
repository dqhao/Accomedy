
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wsp_create_post]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[wsp_create_post] AS' 
END
GO

ALTER PROCEDURE [dbo].[wsp_create_post]  
(
	@TITLE VARCHAR(128)
	,@DETAILS VARCHAR(MAX)
	,@PHOTOS VARCHAR(128)
	,@PRICE DECIMAL(10,2)
	,@ADDRESS VARCHAR(128)
	,@OWNER VARCHAR(128)
)
AS
BEGIN
	DECLARE @USER_ID UNIQUEIDENTIFIER
			,@POST_ID UNIQUEIDENTIFIER = NEWID()
	
	INSERT INTO dbo.POSTS
	(
	    POST_ID,
	    TITLE,
	    DETAILS,
	    PHOTOS,
	    PRICE,
	    ADDRESS,
	    STATUS
	)
	VALUES
	(   @POST_ID,
	    @TITLE,
	    @DETAILS,
	    @PHOTOS,
	    @PRICE,
	    @ADDRESS,
	    ''
	)

	SELECT @USER_ID = USER_ID
	FROM dbo.USERS
	WHERE USER_NAME = @OWNER

	INSERT INTO dbo.USER_POSTS
	(
	    USER_ID,
	    POST_ID
	)
	VALUES
	(   @USER_ID,
	    @POST_ID
	)

END
GO
