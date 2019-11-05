using GBT.DataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessMemebershipstatus
    {
        IUnitOfWork _uow;
        public BusinessMemebershipstatus() : this(new UnitOfWork())
        {

        }

        public BusinessMemebershipstatus(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public List< VMMemebershipstatus> GetMemberShipStatus()
        {
            return _uow.Memebershipstatus.GetAll().Select(s=>new VMMemebershipstatus {
                ID=s.ID,
                Statusname=s.Statusname,
            }).ToList();
        }

    }
}
