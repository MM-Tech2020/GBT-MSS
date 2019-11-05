using GBTDataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBT.DataAccessLayer
{
    public partial interface IMembershipdataRepository : IGenericDataRepository<Membershipdata>
    {
        VMResponse AddMemberShipData(VMMemberShipData _mberShipData);
        VMResponse EditMemberShipData(VMMemberShipDataSearch _mberShipData);
    }
}
