using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBIMS_Backend
{
    public class Household
    {
       public int HouseholdId{ get; set; }
       public int FamilyId { get; set; }
       public string HouseholdAddress { get; set;} = string.Empty;
    }
}