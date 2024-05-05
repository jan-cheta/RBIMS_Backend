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
        FamilyCRUD crudFamily = new FamilyCRUD();
        
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

        public int getFamily(int household){
            List<Inhabitant> inhabitantList = crudInhabitant.readInhabitant();
            List<Family> familyList = crudFamily.readFamily();
            int familyId = -1;
            var familiesWithoutMembers = familyList
            .Where(family => !inhabitantList.Any(inhabitant => inhabitant.FamilyId == family.FamilyId))
            .ToList();

            foreach(var family in familiesWithoutMembers){
                familyId = family.FamilyId;
            }

            return familyId;
        }

        public int getHeadOfFamilyId(string name){
            List<Inhabitant> inhabitantList = crudInhabitant.readInhabitant();
            int familyId = -1;
            foreach(Inhabitant inhabitant in inhabitantList){
                if((inhabitant.LastName+", "+inhabitant.FirstName+" "+inhabitant.MiddleName.ToUpper()).Equals(name.ToUpper())){
                    familyId = inhabitant.FamilyId;
                }
            }
            return familyId;
        }
    }

}