using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBIMS_Backend
{
    public class NewRecord
    {
        HouseholdCRUD crudHousehold = new HouseholdCRUD();
        InhabitantCRUD  crudInhabitant = new InhabitantCRUD();
        public bool validateNewHouseHold(string householdAddress){
            List<Household> householdList = crudHousehold.readHousehold();

            foreach(Household household in householdList){
                if(household.HouseholdAddress.Equals(householdAddress)){
                    return false;
                }
            }
            return true;
        }

        public bool validateNewInhabitant(string first_name, string last_name, string middle_name, string suffix){
            List<Inhabitant> inhabitantList= crudInhabitant.readInhabitant();
            
            foreach(Inhabitant inhabitant in inhabitantList){
                if(
                    inhabitant.FirstName.Equals(first_name)&
                    inhabitant.LastName.Equals(last_name)&
                    inhabitant.MiddleName.Equals(middle_name)&
                    inhabitant.Suffix.Equals(suffix)){
                        return false;
                    }
            }
            return true;
        }

        public List<Inhabitant> findHeadOfFamily(int householdId){
            List<Inhabitant> inhabitantList = crudInhabitant.readInhabitant();
            List<Inhabitant> familyHeadList = new List<Inhabitant>();

            foreach(Inhabitant inhabitant in inhabitantList){
                if(inhabitant.HouseholdId == householdId){
                    familyHeadList.Add(inhabitant);
                }
            }

            return familyHeadList;
        }
    }
}