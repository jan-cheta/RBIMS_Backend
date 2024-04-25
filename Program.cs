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

            //UserCRUD
            UserCRUD userCRUD = new UserCRUD();
            userCRUD.addUser("jasella", "james", "anch", "dyl", "buddyblast");
            userCRUD.updateUser(2, "jaslla", "jaes", "anh", "dl", "buddybla");
            List<User> userList = userCRUD.readUser();
            foreach(User user in userList){
                Console.WriteLine(user.Username + " : " + user.Password);
            }
            userCRUD.deleteUser(2);
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