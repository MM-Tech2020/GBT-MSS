using GBTDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBT.DataAccessLayer
{
    public partial class BranchRepository : GenericDataRepository<Branch>, IBranchRepository
    {
    }
}
