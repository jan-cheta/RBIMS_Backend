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