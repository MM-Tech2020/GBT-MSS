using GBT.DataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessClubInterest
    {
        IUnitOfWork _uow;
        public BusinessClubInterest() : this(new UnitOfWork())
        {

        }

        public BusinessClubInterest(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public List<VMClubInterest> GetAl()
        {
            return _uow.ClubInterests.GetAll().Select(s => new VMClubInterest
            {
                ID = s.ID,
                Interestsdescription = s.Interestsdescription,
                Active=s.Active,
            }).ToList();
        }
    }
}
