                
using GBTDataAccessLayer;
namespace GBT.DataAccessLayer
{              
public partial class RelationTypeRepository : GenericDataRepository<RelationType>, IRelationTypeRepository
{
    private GBTMembershipSolutionEntities _context;
	

    public RelationTypeRepository(GBTMembershipSolutionEntities entitycontext) : base(entitycontext)
    {
        _context = entitycontext;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IRelationTypeRepository.cs file
}
}
