using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMEducationsinfo
    {
        public int ID { get; set; }
        public int? EducationDegreetype { get; set; }
        public VMEducationdDgreeType EducationDegreetypee { get; set; }
        public string EducationAuthority { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int? PersonalID { get; set; }
    }
}
