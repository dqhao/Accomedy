
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wsp_flexible_search_post]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[wsp_flexible_search_post] AS' 
END
GO

ALTER PROCEDURE [dbo].[wsp_flexible_search_post]  
(
	@searchFields XML,
	@sortingField varchar(200),
	@sortingDesc varchar(5),
	@pageNumber INT,
	@rowsPerPage INT,
	@RountCow INT OUTPUT
)
AS
BEGIN

	SET @PageNumber = @PageNumber - 1
	DECLARE @sqlCount NVARCHAR(MAX)=''
	DECLARE @sqlQuery NVARCHAR(MAX)=''
	DECLARE @sql_condition NVARCHAR(MAX)=''
	DECLARE @pagingString NVARCHAR(MAX) = CONCAT(' ORDER BY ', @sortingField, ' ', @sortingDesc, ' 
												OFFSET ', CONVERT(NVARCHAR(30), @PageNumber), '*', CONVERT(NVARCHAR(30),@RowsPerPage), ' ROWS 
												FETCH NEXT ', CONVERT(NVARCHAR(30), @RowsPerPage), ' ROWS ONLY ')

	;WITH cte_field_condition AS
	(	
			
		SELECT  
		[PARAM_NAME] = Parameters.value('@FieldName', 'NVARCHAR(MAX)'),
		[PARAM_VALUE] =	Parameters.value('@Value', 'NVARCHAR(MAX)')
		FROM @searchFields.nodes('/FieldConditions/FieldCondition') AS XTbl(Parameters)
	)
	SELECT @sql_condition =  @sql_condition + ' AND '+ 
	CASE 
		WHEN [PARAM_NAME] ='(ADDRESS)' THEN 'posts.ADDRESS LIKE ''%' + LTRIM(rtrim([PARAM_VALUE])) + '%'''
		WHEN [PARAM_NAME] = '(PRICE)' THEN 'posts.PRICE <= ' + [PARAM_VALUE]
	END
	FROM cte_field_condition cte;

	SELECT @sql_condition = SUBSTRING(@sql_condition, 5, LEN(@sql_condition))

	

	SET @sqlQuery = CONCAT('SELECT * FROM dbo.POSTS ', IIF(@sql_condition <> '', ' WHERE ' + @sql_condition, ''))

	
	EXEC(@sqlQuery + @pagingString)

	SET @sqlCount = 'SELECT @RountCow = COUNT(1) FROM dbo.POSTS ' + IIF(@sql_condition <> '', ' WHERE ' + @sql_condition, '')
	EXEC sys.sp_executesql	@sqlCount ,N'@RountCow INT OUT'	,@RountCow OUT

END
GO
