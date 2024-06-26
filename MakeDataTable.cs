using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RBIMS_Backend
{
    public class MakeDataTable
    {

        public DataTable makeHouseholdDataTable(List <Household> households){
            DataTable householdDT = new DataTable();

            householdDT.Columns.Add("Household ID", typeof(int));
            householdDT.Columns.Add("House No.", typeof(string));
            householdDT.Columns.Add("Street", typeof(string));
            householdDT.Columns.Add("Sitio", typeof(string));

            foreach(Household household in households){
                householdDT.Rows.Add(household.HouseholdId,household.HouseNo,household.Street,household.Sitio);
            }

            return householdDT;
        }

        public DataTable makeInhabitantDataTable(List<Inhabitant> inhabitants){
            DataTable inhabitantDT = new DataTable();

            inhabitantDT.Columns.Add("Inhabitant ID", typeof(int));
            inhabitantDT.Columns.Add("First Name", typeof(string));
            inhabitantDT.Columns.Add("Last Name", typeof(string));
            inhabitantDT.Columns.Add("Middle Name", typeof(string));
            inhabitantDT.Columns.Add("Suffix", typeof(string));
            inhabitantDT.Columns.Add("Occupation", typeof(string));
            inhabitantDT.Columns.Add("Date Of Birth", typeof(string));
            inhabitantDT.Columns.Add("Sex", typeof(char));
            inhabitantDT.Columns.Add("Civil Status", typeof(string));
            inhabitantDT.Columns.Add("Citizenship", typeof(string));
            inhabitantDT.Columns.Add("Contact Number", typeof(string));
            inhabitantDT.Columns.Add("Educational Attainment", typeof(string));
            inhabitantDT.Columns.Add("Role In Family", typeof(string));
            inhabitantDT.Columns.Add("Remarks", typeof(string));
            inhabitantDT.Columns.Add("Family ID", typeof(int));
            inhabitantDT.Columns.Add("Household ID", typeof(int));

            foreach(Inhabitant inhabitant in inhabitants){
                inhabitantDT.Rows.Add(inhabitant.InhabitantId,
                inhabitant.FirstName,
                inhabitant.LastName,
                inhabitant.MiddleName,
                inhabitant.Suffix,
                inhabitant.Occupation,
                inhabitant.DateOfBirth,
                inhabitant.Sex,
                inhabitant.CivilStatus,
                inhabitant.Citizenship,
                inhabitant.ContactNumber,
                inhabitant.EducationAttainment,
                inhabitant.RoleInFamily,
                inhabitant.Remarks,
                inhabitant.FamilyId,
                inhabitant.HouseholdId);
            }

            return inhabitantDT;
        }

    }
}