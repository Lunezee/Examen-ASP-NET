CREATE TABLE Articles (
    ArticleID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(500),
    Category NVARCHAR(50),
    Gender NVARCHAR(10),
    Color NVARCHAR(20),
    Size NVARCHAR(10),
    Price DECIMAL(18, 2)
);

