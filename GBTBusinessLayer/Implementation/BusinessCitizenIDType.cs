using GBT.DataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessCitizenIDType
    {
        IUnitOfWork _uow;
        public BusinessCitizenIDType() : this(new UnitOfWork())
        {

        }

        public BusinessCitizenIDType(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public List<VMCitizenIDType> GetActiveType()
        {
           return _uow.CitizenIDTypes.FindList(a => a.Active == "1         ").Select(s => new VMCitizenIDType
                    {
                        ID=s.ID,
                        citizenIdtpename=s.citizenIdtpename,
                        Active=s.Active,
                    }).ToList();
        }
    }
}
