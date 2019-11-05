using System;
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{
public partial class UnitOfWork : IUnitOfWork
{
    private GBTMembershipSolutionEntities _context;

    public UnitOfWork(GBTMembershipSolutionEntities context)
    {
        _context = context;
    }

	//Delete this default constructor if using an IoC container
	public UnitOfWork()
	{
		_context = new GBTMembershipSolutionEntities();
	}
	
    public ICardStatuRepository CardStatus
    {
        get { return new CardStatuRepository(_context); }
    }

    public IPersonalInterstsDataRepository PersonalInterstsDatas
    {
        get { return new PersonalInterstsDataRepository(_context); }
    }

    public IPersonalInterestRepository PersonalInterests
    {
        get { return new PersonalInterestRepository(_context); }
    }

    public IClubInfoRepository ClubInfos
    {
        get { return new ClubInfoRepository(_context); }
    }

    public IClubInterestRepository ClubInterests
    {
        get { return new ClubInterestRepository(_context); }
    }

    public IPaymentsduesRepository Payments_duess
    {
        get { return new PaymentsduesRepository(_context); }
    }

    public IContacttypeRepository Contacttypes
    {
        get { return new ContacttypeRepository(_context); }
    }

    public ICitizenIDRepository CitizenIDs
    {
        get { return new CitizenIDRepository(_context); }
    }

    public IPersonaldataRepository Personaldatas
    {
        get { return new PersonaldataRepository(_context); }
    }

    public IMemebershipstatuRepository Memebershipstatus
    {
        get { return new MemebershipstatuRepository(_context); }
    }

    public IEducationsinfoRepository Educationsinfos
    {
        get { return new EducationsinfoRepository(_context); }
    }

    public IContactinfoRepository Contactinfos
    {
        get { return new ContactinfoRepository(_context); }
    }

    public IPremesisLimitRepository PremesisLimits
    {
        get { return new PremesisLimitRepository(_context); }
    }

    public IMembershiptypeRepository Membershiptypes
    {
        get { return new MembershiptypeRepository(_context); }
    }

    public ICardDataRepository CardDatas
    {
        get { return new CardDataRepository(_context); }
    }

    public ICitizenIDTypeRepository CitizenIDTypes
    {
        get { return new CitizenIDTypeRepository(_context); }
    }

    public ICitizenAddressRepository CitizenAddresss
    {
        get { return new CitizenAddressRepository(_context); }
    }

    public IMembershipinterestRepository Membershipinterests
    {
        get { return new MembershipinterestRepository(_context); }
    }

    public IjobcatogoryRepository jobcatogorys
    {
        get { return new jobcatogoryRepository(_context); }
    }

    public IMembershipdataRepository Membershipdatas
    {
        get { return new MembershipdataRepository(_context); }
    }

    public IsysdiagramRepository sysdiagrams
    {
        get { return new sysdiagramRepository(_context); }
    }

    public IRenewalDataRepository RenewalDatas
    {
        get { return new RenewalDataRepository(_context); }
    }

    public IRelationTypeRepository RelationTypes
    {
        get { return new RelationTypeRepository(_context); }
    }

    public IeducationdegreetypeRepository educationdegreetypes
    {
        get { return new educationdegreetypeRepository(_context); }
    }

    public IJobInfoRepository JobInfos
    {
        get { return new JobInfoRepository(_context); }
    }

    public IBranchRepository Branchs
    {
        get { return new BranchRepository(_context); }
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
