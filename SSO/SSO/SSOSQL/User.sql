CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] VARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [SocialSecurityNumber] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(MAX) NULL, 
    [Country] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(MAX) NOT NULL 
)
