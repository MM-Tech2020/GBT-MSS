            using System;
namespace SSO.DataAccessLayer
{
public interface IUnitOfWork : IDisposable
{
    ICredentialsRepository Credentialss { get; }
    IPermissionRepository Permissions { get; }
    IUserRepository Users { get; }
    IUserPermissionRepository UserPermissions { get; }
    ISiteRepository Sites { get; }
    IDomainRepository Domains { get; }
    IUserInfoRepository UserInfos { get; }
    ISessionRepository Sessions { get; }
    IRoleRepository Roles { get; }
    IUserSiteRepository UserSites { get; }
    IModuleRepository Modules { get; }
    IUserRoleRepository UserRoles { get; }
    IUserConfigurationRepository UserConfigurations { get; }
    void Save();
}
}
