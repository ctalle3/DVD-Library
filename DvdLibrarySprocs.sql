USE DVDLibrary
GO

/* Drop and create CreateDVD sproc*/
IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateDVD')
BEGIN
	DROP PROCEDURE CreateDVD
END
GO

CREATE PROCEDURE CreateDVD(
	@Title varchar(50), 
	@ReleaseYear varchar(4),
	@Director varchar(50), 
	@Rating varchar(5), 
	@Notes varchar(max)
) 
AS

INSERT INTO DVDs
(Title, ReleaseYear, Director, Rating, Notes)
VALUES
(@Title, @ReleaseYear, @Director, @Rating, @Notes)

Go

/* Drop and create ReadDVDList sproc*/
IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ReadDVDList')
BEGIN
	DROP PROCEDURE ReadDVDList
END
GO

CREATE PROCEDURE ReadDVDList
AS

SELECT *
FROM DVDs

Go

/* Drop and create ReadDVD sproc*/
IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ReadDVD')
BEGIN
	DROP PROCEDURE ReadDVD
END
GO

CREATE PROCEDURE ReadDVD (
@DVDId int
)
AS

SELECT *
FROM DVDs
WHERE DVDId = @DVDId

Go

/* Drop and create UpdateDVD sproc*/
IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateDVD')
BEGIN
	DROP PROCEDURE UpdateDVD
END
GO

CREATE PROCEDURE UpdateDVD(
	@DVDID int, 
	@Title varchar(50), 
	@ReleaseYear varchar(4), 
	@Director varchar(50), 
	@Rating varchar(5), 
	@Notes varchar(max)
) 
AS

UPDATE DVDs
SET Title = @Title,
	ReleaseYear = @ReleaseYear,
	Director = @Director,
	Rating = @Rating,
	Notes = @Notes
WHERE DVDId = @DVDId

Go


/* Drop and create DeleteDVD sproc*/
IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteDVD')
BEGIN
	DROP PROCEDURE DeleteDVD
END
GO

CREATE PROCEDURE DeleteDVD (
@DVDId int
)
AS

DELETE FROM DVDs
WHERE DVDId = @DVDId

Go

/* Drop and create ReadDVDTitle sproc*/
IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ReadDVDTitle')
BEGIN
	DROP PROCEDURE ReadDVDTitle
END
GO

CREATE PROCEDURE ReadDVDTitle (
@Title varchar(50)
)
AS

SELECT *
FROM DVDs
WHERE Title LIKE '%' + @Title + '%'

Go

/* Drop and create ReadDVDYear sproc*/
IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ReadDVDYear')
BEGIN
	DROP PROCEDURE ReadDVDYear
END
GO

CREATE PROCEDURE ReadDVDYear (
@Year varchar(4)
)
AS

SELECT *
FROM DVDs
WHERE ReleaseYear LIKE '%' + @Year + '%'

Go
	
/* Drop and create ReadDVDDirector sproc*/
IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ReadDVDDirector')
BEGIN
	DROP PROCEDURE ReadDVDDirector
END
GO

CREATE PROCEDURE ReadDVDDirector (
@Director varchar(50)
)
AS

SELECT *
FROM DVDs
WHERE Director LIKE '%' + @Director + '%'

Go	
	
/* Drop and create ReadDVDRating sproc*/
IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ReadDVDRating')
BEGIN
	DROP PROCEDURE ReadDVDRating
END
GO

CREATE PROCEDURE ReadDVDRating (
@Rating varchar(5)
)
AS

SELECT *
FROM DVDs
WHERE Rating LIKE '%' + @Rating + '%'

Go
