using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBIMS_Backend
{
    public class Inhabitant
    {
        public int InhabitantId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string EducationAttainment { get; set; } = string.Empty;
        public string RoleInFamily { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public int FamilyId { get; set; }
        public int HouseholdId { get; set; }
    }
}