BEGIN TRANSACTION;

---SELECT * FROM Project ORDER BY id OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;
---SELECT * FROM Project;
---SELECT * FROM Comment;
---SELECT * FROM Vote;
---INSERT INTO [User] (Name, LastName)
---VALUES ('Artem', 'Gonchar');

---INSERT INTO Category (Description)
---VALUES ('Test Category2');
---EXEC CreateProject @Name = 'ggggggg', @Description = 'hhhhhh', @CreatorId = 2, @CategoryId = 3;
---EXEC CreateComment @Text = 'Epic',@UserId = 2, @ProjectId = 3;
---EXEC CreateVote @UserId = 1, @ProjectId = 3;
---EXEC ProjectInfo @ProjectId = 3;
---EXEC PaginatedProjects @Name = 'asd',@PageSkip = 0, @PageTake = 10;

CREATE TABLE [User] (
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL
);

CREATE TABLE Category (
	Id INT IDENTITY PRIMARY KEY,
	Description NVARCHAR(255) NOT NULL,
);

CREATE TABLE Project (
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	Description NVARCHAR(255) NOT NULL,
	CreationDate DATE DEFAULT GETDATE(),
	CreatorId INT NOT NULL,
	CategoryId INT NOT NULL,
	FOREIGN KEY (CreatorId) REFERENCES [User](Id),
	FOREIGN KEY (CategoryId) REFERENCES Category(Id),
);

CREATE TABLE Comment (
	Id INT IDENTITY PRIMARY KEY,
	Text NVARCHAR(100) NOT NULL,
	Date DATE DEFAULT GETDATE(),
	UserId INT NOT NULL,
	ProjectId INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User](Id),
	FOREIGN KEY (ProjectId) REFERENCES Project(Id),
);

CREATE TABLE Vote(
	Id INT IDENTITY PRIMARY KEY,
	UserId INT NOT NULL,
	ProjectId INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User](Id),
	FOREIGN KEY (ProjectId) REFERENCES Project(Id),
);
GO


CREATE PROCEDURE CreateProject
	@Name NVARCHAR(100),
	@Description NVARCHAR(255),
	@CreatorId INT,
	@CategoryId INT
AS
BEGIN
	INSERT INTO Project(Name, Description, CreatorId, CategoryId)
	VALUES (@Name,@Description,@CreatorId,@CategoryId)
END;
GO
CREATE PROCEDURE CreateComment
	@Text NVARCHAR(100),
	@UserId INT,
	@ProjectId INT
AS
BEGIN
	INSERT INTO Comment(Text,UserId, ProjectId)
	VALUES (@Text,@UserId,@ProjectId)
END;
GO
CREATE PROCEDURE CreateVote
	@UserId INT,
	@ProjectId INT
AS
BEGIN
	INSERT INTO Vote(UserId, ProjectId)
	VALUES (@UserId,@ProjectId)
END;
GO

CREATE PROCEDURE ProjectInfo
	@ProjectId INT
AS
BEGIN
SELECT p.Name, p.Description, p.CreationDate, u.Name, u.LastName, c.Description,
(SELECT COUNT(*) FROM Vote v WHERE v.ProjectId = p.Id) AS Votes
FROM Project p JOIN [User] u ON p.CreatorId = u.Id JOIN Category c ON p.CategoryId = c.Id
WHERE p.Id = @ProjectId;
SELECT co.Text, co.Date, cu.Name, cu.LastName FROM Comment co
JOIN [User] cu ON co.UserId = cu.Id
WHERE co.ProjectId = @ProjectId
ORDER BY co.Date;
END;
COMMIT;
GO

CREATE PROCEDURE PaginatedProjects
	@Name VARCHAR(100) = NULL,
	@CategoryId INT = NULL,
	@PageSkip INT,
	@PageTake INT,
	@FromDate DATE = NULL,
	@ToDate DATE = NULL
AS
BEGIN
	SELECT p.Id, p.Name, c.Description, p.CreationDate FROM Project p
	JOIN Category c on p.CategoryId = c.Id
	WHERE
	(@Name IS NULL OR p.Name LIKE '%'+ @Name +'%') 
	AND (@CategoryId IS NULL OR p.CategoryId = @CategoryId)
	AND (@FromDate IS NULL OR p.CreationDate >= @FromDate)
	AND (@ToDate IS NULL OR p.CreationDate <= @ToDate)
	ORDER BY p.Id
	OFFSET @PageSkip ROWS FETCH NEXT @PageTake ROWS ONLY;
END;
GO
COMMIT;