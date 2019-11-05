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
    public class BusinessBranch
    {
        IUnitOfWork _uow;
        public BusinessBranch() : this(new UnitOfWork())
        {

        }

        public BusinessBranch(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public VMBranch GetFirstBranch(int ID)
        {
            
            var brnch= _uow.Branchs.FindOne(a=>a.ID == ID);
            VMBranch _Response = new VMBranch
            {
                Address=brnch.Address,
                BrancheTaxID=brnch.BrancheTaxID,
                BranchName=brnch.BranchName,
                Fax=brnch.Fax,
                ID=brnch.ID,
                IsDeleted=brnch.IsDeleted,
                Tel=brnch.Tel,
                Club=new VMClub
                {
                    ID=brnch.ClubInfo.ID,
                    Tel=brnch.ClubInfo.Tel,
                    Active=brnch.ClubInfo.Active,
                    Addresses=brnch.ClubInfo.Addresses,
                    ArabicName=brnch.ClubInfo.ArabicName,
                    EnglishName=brnch.ClubInfo.EnglishName,
                }
            };
            return _Response;
        }

        public List<VMBranch> GetBranchByClub(int ClubID,int start,int size)
        {

        
            List<VMBranch> branches = new List<VMBranch>() ;
           branches = _uow.Branchs.GetAll().OrderBy(a => a.ID).Skip(start - 1).Take(size).Select(b => new VMBranch
            {
                ID = b.ID,
                Address = b.Address,
                BranchName = b.BranchName,
                BrancheTaxID = b.BrancheTaxID,
                Fax = b.Fax,
                Tel = b.Tel,
                IsDeleted = b.IsDeleted,
                Club = new VMClub
                {
                    ID = b.ClubInfo.ID,
                    Active = b.ClubInfo.Active,
                    Addresses = b.ClubInfo.Addresses,
                    ArabicName = b.ClubInfo.ArabicName,
                    EnglishName = b.ClubInfo.EnglishName,
                    Tel = b.ClubInfo.Tel,
                }
            }).ToList();

            return branches;
        }

        public VMResponse DeActiveBranch(int ID)
        {
            VMResponse _Response = new VMResponse();

            var _Branch = _uow.Branchs.FindOne(a=>a.ID == ID);
            _Branch.IsDeleted = (!_Branch.IsDeleted);
            _uow.Save();
            _Response.Code = 1;
            _Response.Message = _Branch.BranchName + (_Branch.IsDeleted?" Is Active":"Is DeActive");
            return _Response;
        }

        public VMResponse Add(Branch brnch)
        {
            VMResponse _Response = new VMResponse();

            if(brnch.ID == 0)
            {
                _uow.Branchs.Add(brnch);
                _uow.Save();
            }
            else
            {
                var br=_uow.Branchs.FindOne(a=>a.ID==brnch.ID);
                br.Address = brnch.Address;
                br.Fax = brnch.Fax;
                br.Tel = brnch.Tel;
                br.ClubID = brnch.ClubID;
                br.BranchName = brnch.BranchName;
                br.BrancheTaxID = brnch.BrancheTaxID;
                br.IsDeleted = brnch.IsDeleted;
                _uow.Save();
            }
            if(brnch.ID != 0)
            {
                _Response.Code = 1;
                _Response.Message = brnch.BranchName + " is Added";
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
