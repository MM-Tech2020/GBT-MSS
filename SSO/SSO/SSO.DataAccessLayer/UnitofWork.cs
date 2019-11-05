
using System;

using SSO.Model;
namespace SSO.DataAccessLayer
{
public class UnitOfWork : IUnitOfWork
{
    private SSOContext _context;

    public UnitOfWork(SSOContext context)
    {
        _context = context;
    }

	//Delete this default constructor if using an IoC container
	public UnitOfWork()
	{
		_context = new SSOContext();
	}
	
    public ICredentialsRepository Credentialss
    {
        get { return new CredentialsRepository(_context); }
    }

    public IPermissionRepository Permissions
    {
        get { return new PermissionRepository(_context); }
    }

    public IUserRepository Users
    {
        get { return new UserRepository(_context); }
    }

    public IUserPermissionRepository UserPermissions
    {
        get { return new UserPermissionRepository(_context); }
    }

    public ISiteRepository Sites
    {
        get { return new SiteRepository(_context); }
    }

    public IDomainRepository Domains
    {
        get { return new DomainRepository(_context); }
    }

    public IUserInfoRepository UserInfos
    {
        get { return new UserInfoRepository(_context); }
    }

    public ISessionRepository Sessions
    {
        get { return new SessionRepository(_context); }
    }

    public IRoleRepository Roles
    {
        get { return new RoleRepository(_context); }
    }

    public IUserSiteRepository UserSites
    {
        get { return new UserSiteRepository(_context); }
    }

    public IModuleRepository Modules
    {
        get { return new ModuleRepository(_context); }
    }

    public IUserRoleRepository UserRoles
    {
        get { return new UserRoleRepository(_context); }
    }

    public IUserConfigurationRepository UserConfigurations
    {
        get { return new UserConfigurationRepository(_context); }
    }

    
    public void Save()
    {
           _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
}
