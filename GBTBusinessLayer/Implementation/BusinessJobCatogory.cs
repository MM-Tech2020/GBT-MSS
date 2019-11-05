using GBT.DataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessJobCatogory
    {
        IUnitOfWork _uow;
        public BusinessJobCatogory() : this(new UnitOfWork())
        {

        }

        public BusinessJobCatogory(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public List<VMjobcatogory> GetAl()
        {
            return _uow.jobcatogorys.GetAll().Select(s => new VMjobcatogory
            {
                ID = s.ID,
                Name = s.Name
            }).ToList();
        }
    }
}
