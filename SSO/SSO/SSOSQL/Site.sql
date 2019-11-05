CREATE TABLE [dbo].[Site]
(
	[SiteId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SiteName] VARCHAR(50) NOT NULL, 
    [DomainId] INT NOT NULL, 
    CONSTRAINT [FK_Site_Domain] FOREIGN KEY ([DomainId]) REFERENCES [Domain]([DomainId])
)
