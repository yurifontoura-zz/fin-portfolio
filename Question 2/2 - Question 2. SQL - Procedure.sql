CREATE OR ALTER PROCEDURE SP_Categorize
(
	@finantial_instrument_ID	varchar(max)
)
AS
	DECLARE @names TABLE(name varchar(50));
	DECLARE @ids TABLE(id INT);

	INSERT INTO @ids(id)
	SELECT convert(int, s.value) [id]
	FROM STRING_SPLIT(@finantial_instrument_ID, ',') s;
BEGIN
	INSERT INTO @names(name)
	SELECT fr.Name
	FROM FinantialInstrument fi
		INNER JOIN @ids ids ON fi.ID = ids.id
		INNER JOIN FinantialRule fr ON (fr.MinValue is null or fi.MarketValue >= fr.MinValue) AND (fr.MaxValue is null OR fi.MarketValue <= fr.MaxValue);

	SELECT name FROM @names;
END;

-- exec SP_Categorize '1,2,3,4'