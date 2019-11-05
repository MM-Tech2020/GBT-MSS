using GBT.DataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessEducationdDgreeType
    {
        IUnitOfWork _uow;
        public BusinessEducationdDgreeType() : this(new UnitOfWork())
        {

        }

        public BusinessEducationdDgreeType(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public List<VMEducationdDgreeType> GetAl()
        {
            return _uow.educationdegreetypes.GetAll().Select(s => new VMEducationdDgreeType
            {
                ID = s.ID,
                Degreename = s.Degreename
            }).ToList();
        }
    }
}
