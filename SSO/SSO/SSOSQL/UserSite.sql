CREATE TABLE [dbo].[UserSite]
(
	[UserSiteId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [SiteId] INT NOT NULL, 
    CONSTRAINT [FK_UserSite_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]), 
    CONSTRAINT [FK_UserSite_Site] FOREIGN KEY ([SiteId]) REFERENCES [Site]([SiteId])
)
