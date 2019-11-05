using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMJobInfo
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Datefrom { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Dateto { get; set; }
        public string Jobtitle { get; set; }
        [DataType(DataType.MultilineText)]
        public string Jobdetailes { get; set; }
        public Nullable<int> PersonalID { get; set; }
        public Nullable<int> jobcotogory { get; set; }
        public VMjobcatogory jobcotogoryy { get; set; }
        public bool IsCurrent { get; set; }
    }
}
