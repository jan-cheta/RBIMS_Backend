using Microsoft.Data.Sqlite;
using System;

namespace RBIMS_Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            //DATABASE INITIALIZATION
            DBInit dBInit = new DBInit();
            dBInit.initDB();

            // //UserCRUD
            // UserCRUD userCRUD = new UserCRUD();
            // userCRUD.addUser("jasella", "james", "anch", "dyl", "buddyblast");
            // userCRUD.updateUser(2, "jaslla", "jaes", "anh", "dl", "buddybla");
            // List<User> userList = userCRUD.readUser();
            // foreach(User user in userList){
            //     Console.WriteLine(user.Username + " : " + user.Password);
            // }
            // userCRUD.deleteUser(2);

            string first_name = "a",
                        last_name = "b",
                        middle_name = "c",
                        occupation = "d",
                        civil_status = "g",
                        citizenship = "df",
                        contact_num = "dfgds",
                        educ_attainment = "gsdg",
                        role_in_family = "dsgsdg",
                        remarks = "fgsdf";
                        
            DateTime date_of_birth = new DateTime(2003,5,12);
            char sex = 'm';
            int family_id = 2, household_id = 2;

            HouseholdCRUD householdCRUD  = new HouseholdCRUD();

            householdCRUD.addHousehold(2,2,"ching ching");

            InhabitantCRUD inhabitantCRUD = new InhabitantCRUD();

            inhabitantCRUD.addInhabitant(first_name,last_name,middle_name,occupation,date_of_birth,sex,civil_status,citizenship,contact_num,educ_attainment,role_in_family,remarks,family_id,household_id);
        }
        
        
        

        //---LOGIN FUNCTIONS---
        //TODO: VERIFICATION

        static void verify_user(){
            //TODO:
        }
        
        //---Household Table Section



        //---Resident Table Section---
    }
}