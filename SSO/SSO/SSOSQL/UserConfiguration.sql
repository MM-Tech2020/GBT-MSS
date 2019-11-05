CREATE TABLE [dbo].[UserConfiguration]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [TokenExpireAfterDays] INT NOT NULL, 
    CONSTRAINT [FK_UserConfiguration_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)
