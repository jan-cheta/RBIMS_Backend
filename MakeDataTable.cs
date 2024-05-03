using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RBIMS_Backend
{
    public class MakeDataTable
    {
        private HouseholdCRUD householdCRUD = new HouseholdCRUD();
        private FamilyCRUD familyCRUD = new FamilyCRUD();
        private InhabitantCRUD inhabitantCRUD = new InhabitantCRUD();

        public DataTable makeHouseholdDataTable(){
            DataTable householdDT = new DataTable();

            householdDT.Columns.Add("Household ID", typeof(int));
            householdDT.Columns.Add("Address", typeof(string));
            
            List<Household> householdList = householdCRUD.readHousehold();
            foreach(Household household in householdList){
                householdDT.Rows.Add(household.HouseholdId,household.HouseholdAddress);
            }

            return householdDT;
        }

        

    }
}