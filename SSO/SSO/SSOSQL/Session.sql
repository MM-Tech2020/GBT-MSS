CREATE TABLE [dbo].[Session]
(
	[SessionId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [Token] NVARCHAR(MAX) NOT NULL, 
    [TokenValidUntil] DATETIME NOT NULL, 
    CONSTRAINT [FK_Session_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)
