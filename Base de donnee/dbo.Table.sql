CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DateOfBirth DATE,
    Login NVARCHAR(50) UNIQUE,
    PasswordHash NVARCHAR(256)
);

