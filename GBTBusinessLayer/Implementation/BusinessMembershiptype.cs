using GBT.DataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessMembershiptype
    {
        IUnitOfWork _uow;
        public BusinessMembershiptype() : this(new UnitOfWork())
        {
        }
        public BusinessMembershiptype(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public List<VMMembershiptype> GetMemberShipType()
        {
            return _uow.Membershiptypes.GetAll().Select(s => new VMMembershiptype
            {
                ID = s.ID,
                Membershiptypename = s.Membershiptypename,
            }).ToList();
        }
    }
}
