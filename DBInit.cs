using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RBIMS_Backend
{
    public class DBInit
    {
        public string connectionString = "Data Source=rbimstrial.db;";
        //DATABASE INITIALIZATION
        public void initSuperAdmin(){
            UserCRUD crud = new UserCRUD();
            List<User> userList = crud.readUser();

            if(userList.Count()<1){
                crud.addUser("rbimsSiblot", "rbims", "rbims", "rbims", "rbimsAdmin", "admin");
            }
        }
        public void initDB(){
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();
                
                string commandText =
                @"
                    CREATE TABLE IF NOT EXISTS user (
                        user_id INTEGER PRIMARY KEY,
                        username TEXT UNIQUE,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NUll,
                        middle_name TEXT NOT NULL,
                        user_level TEXT DEFAULT 'user',
                        pass_word TEXT NOT NULL 
                    );

                    CREATE TABLE IF NOT EXISTS family (
                        family_id INTEGER PRIMARY KEY,
                        household_id INTEGER REFERENCES household(household_id)
                    );

                    CREATE TABLE IF NOT EXISTS household (
                        household_id INTEGER PRIMARY KEY,
                        house_no TEXT,
                        street TEXT,
                        sitio TEXT
                    );

                    CREATE TABLE IF NOT EXISTS inhabitant (
                        inhabitant_id INTEGER PRIMARY KEY,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NUll,
                        middle_name TEXT NOT NULL,
                        suffix TEXT,
                        occupation TEXT NOT NULL,
                        date_of_birth DATETIME NOT NULL,
                        sex TEXT NOT NULL,
                        civil_status TEXT NOT NULL,
                        citizenship TEXT NOT NULL,
                        contact_num TEXT,
                        educ_attainment TEXT,
                        role_in_family TEXT,
                        remarks TEXT,
                        family_id INTEGER REFERENCES family(family_id),
                        household_id INTEGER REFERENCES household(household_id)
                    );

                    CREATE TABLE IF NOT EXISTS certification_request_form (
                        request_id INTEGER PRIMARY KEY,
                        inhabitant_id INTEGER REFERENCES resident(inhabitant_id),
                        date_requested DATE DEFAULT CURRENT_DATE,
                        form_status TEXT NOT NULL,
                        user_id INTEGER REFERENCES users(user_id)
                    );

                    CREATE TABLE IF NOT EXISTS certification_form (
                        certification_id INTEGER PRIMARY KEY,
                        request_id INTEGER REFERENCES certification_request_form(request_id),
                        inhabitant_id INTEGER REFERENCES resident(inhabitant_id),
                        date_issued DATE DEFAULT CURRENT_DATE,
                        cert_type TEXT NOT NULL,
                        purpose TEXT NOT NULL
                    );

                ";
                using (SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            initSuperAdmin();
        }
    }
}