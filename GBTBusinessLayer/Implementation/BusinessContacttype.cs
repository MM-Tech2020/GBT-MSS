using GBT.DataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessContacttype
    {
        IUnitOfWork _uow;
        public BusinessContacttype() : this(new UnitOfWork())
        {

        }

        public BusinessContacttype(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public List<VMContacttype> GetAl()
        {
            return _uow.Contacttypes.GetAll().Select(s=>new VMContacttype {
                ID=s.ID,
                Contacttypename=s.Contacttypename
            }).ToList();
        }

    }
}
