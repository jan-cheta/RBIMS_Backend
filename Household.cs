using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBIMS_Backend
{
    public class Household
    {
       public int HouseholdId{ get; set; }
       public string HouseNo { get; set;} = string.Empty;
       public string Street { get; set;} = string.Empty;
       public string Sitio { get; set;} = string.Empty;
    }
}