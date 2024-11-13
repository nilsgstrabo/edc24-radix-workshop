IF NOT EXISTS(SELECT 1 FROM dbo.Movie)
BEGIN
	PRINT 'Insert sample data in table dbo.Movie'
	INSERT INTO dbo.Movie(Title, Released, Rating)
	VALUES
		('The Shawshank Redemption', '1995-01-06', 9.3),
		('The Godfather', '1972-03-24', 9.2),
		('The Dark Knight', '2008-07-14', 9.0),
		('The Godfather - part II', '1974-12-12', 9.0),
		('12 Angry Men', '1957-04-10', 9.0),
		('Schindler''s List', '1993-12-15', 9.0),
		('The Lord of the Rings: The Return of the King', '2003-12-01', 9.0),
		('Pulp Fiction', '', 8.9),
		('The Lord of the Rings: The Fellowship of the Ring', '2001-12-10', 8.8),
		('The Good, the Bad and the Ugly', '1966-12-23', 8.8)
END
