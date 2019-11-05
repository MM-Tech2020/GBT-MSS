using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMPersonaldata
    {
        public int ID { get; set; }
        public string Firstname_EN { get; set; }
        public string MiddelName_EN { get; set; }
        public string Lastname_EN { get; set; }
        public string Firstname_Ar { get; set; }
        public string MiddelName_Ar { get; set; }
        public string Lastname_Ar { get; set; }
        public string Photopath { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
    }

    public enum Gender
    {
        Male,Female
    }
}
