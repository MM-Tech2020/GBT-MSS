using GBT.DataAccessLayer;
using GBTDataAccessLayer;
using GBTDataModel.VMDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTBusinessLayer
{
    public class BusinessClub
    {
        IUnitOfWork _uow;
        public BusinessClub() : this(new UnitOfWork())
        {

        }

        public BusinessClub(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public VMClub GetClub(int Id)
        {
            var data = _uow.ClubInfos.FindOne(a => a.ID == Id || Id == 0);
            return new VMClub
            {
                ID = data.ID,
                Active = data.Active,
                Addresses = data.Addresses,
                ArabicName = data.ArabicName,
                EnglishName = data.EnglishName,
                Tel = data.Tel,
            };
        }

        public List<VMClub> GetClubs(int ClubID, int start, int size)
        {
            return _uow.ClubInfos.GetAll().OrderBy(a => a.ID).Skip(start - 1).Take(size).Select(b => new VMClub
            {
                ID = b.ID,
                Active = b.Active,
                Addresses = b.Addresses,
                ArabicName = b.ArabicName,
                EnglishName = b.EnglishName,
                Tel = b.Tel
            }).ToList();
        }



        public List<VMClub> GetAllClub()
        {
            return _uow.ClubInfos.GetAll().Select(b => new VMClub
            {
                ID = b.ID,
                Active = b.Active,
                Addresses = b.Addresses,
                ArabicName = b.ArabicName,
                EnglishName = b.EnglishName,
                Tel = b.Tel
            }).ToList();
        }

        public VMResponse DeActiveBranch(int ID)
        {
            VMResponse _Response = new VMResponse();

            var _club = _uow.ClubInfos.FindOne(a => a.ID == ID);
            _club.Active = _club.Active == 0 ? 1 : 0;
            _uow.Save();
            _Response.Code = 1;
            _Response.Message = _club.ArabicName + (_club.Active == 1 ? " Is Active" : "Is DeActive");
            return _Response;
        }

        public VMResponse Add(ClubInfo club)
        {
            VMResponse _Response = new VMResponse();

            if (club.ID == 0)
            {
                _uow.ClubInfos.Add(club);
                _uow.Save();
            }
            else
            {
                var clb = _uow.ClubInfos.FindOne(a => a.ID == club.ID);
                clb.Addresses = club.Addresses;
                clb.ArabicName = club.ArabicName;
                clb.Tel = club.Tel;
                clb.EnglishName = club.EnglishName;
                clb.Active = club.Active;
                clb.Tel = club.Tel;
                _uow.Save();
            }
            if (club.ID != 0)
            {
                _Response.Code = 1;
                _Response.Message = club.ArabicName + " is Added";
            }
            else
            {
                _Response.Code = -1;
                _Response.Message = "Error Try Again!!";
            }
            return _Response;
        }


    }
}
