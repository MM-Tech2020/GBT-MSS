using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel.VMDataModel
{
    public class VMClub
    {
        public int ID { get; set; }
        [Display(Name ="Club Name")]
        public string EnglishName { get; set; }
        [Display(Name = "Club Name")]
        public string ArabicName { get; set; }
        public Nullable<int> Active { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Club Address")]
        public string Addresses { get; set; }
        public string Tel { get; set; }
    }
}
