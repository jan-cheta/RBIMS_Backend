using Microsoft.Data.Sqlite;
using System;

namespace RBIMS_Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            initDB();
            //add_user("ja", "anchet", "apon", "Jaran01", "admin");
            // remove_user(1);
        }
        
        //DATABASE INITIALIZATION
        static void initDB(){
            using (var connnection = new SqliteConnection("Data Source=rbimstrial.db;")){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS users (
                        user_id INTEGER PRIMARY KEY,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NUll,
                        middle_name TEXT NOT NULL,
                        user_level TEXT DEFAULT 'user',
                        pass_word TEXT NOT NULL 
                    );

                    CREATE TABLE IF NOT EXISTS household (
                        household_id INTEGER NOT NULL,
                        family_id INTEGER NOT NULL,
                        household_address TEXT, 
                        no_of_families INTEGER,
                        PRIMARY KEY (household_id, family_id)
                    );

                    CREATE TABLE IF NOT EXISTS resident (
                        resident_id INTEGER PRIMARY KEY,
                        first_name TEXT NOT NULL,
                        last_name TEXT NOT NUll,
                        middle_name TEXT NOT NULL,
                        occupation TEXT NOT NULL,
                        date_of_birth DATE NOT NULL,
                        sex char(1) NOT NULL,
                        civil_status TEXT NOT NULL,
                        citizenship TEXT NOT NULL,
                        contact_num TEXT,
                        educ_attainment TEXT,
                        role_in_family TEXT
                        remarks TEXT,
                        family_id INTEGER REFERENCES household(family_id),
                        household_id INTEGER REFERENCES household(household_id)
                    );

                    CREATE TABLE IF NOT EXISTS certification_request_form (
                        request_id INTEGER PRIMARY KEY,
                        resident_id INTEGER REFERENCES resident(resident_id),
                        date_requested DATE DEFAULT CURRENT_DATE,
                        form_status TEXT NOT NULL,
                        user_id INTEGER REFERENCES users(user_id)
                    );

                    CREATE TABLE IF NOT EXISTS certification_form (
                        certification_id INTEGER PRIMARY KEY,
                        request_id INTEGER REFERENCES certification_request_form(request_id),
                        resident_id INTEGER REFERENCES resident(resident_id),
                        date_issued DATE DEFAULT CURRENT_DATE,
                        cert_type TEXT NOT NULL,
                        purpose TEXT NOT NULL
                    );
                ";
                command.ExecuteNonQuery();
            }
        }

        //---Users Table Section (CRUD)---

        //Create User 
        static void add_user(string first_name, string last_name, string middle_name, string pass_word, string user_level = "user"){
            using (var connnection = new SqliteConnection("Data Source=rbimstrial.db;")){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO users (first_name, last_name, middle_name, user_level, pass_word)
                    VALUES($first_name, $last_name, $middle_name, $user_level, $pass_word);
                ";
                command.Parameters.AddWithValue("$first_name", first_name);
                command.Parameters.AddWithValue("$last_name", last_name);
                command.Parameters.AddWithValue("$middle_name", middle_name);
                command.Parameters.AddWithValue("$user_level", user_level);
                command.Parameters.AddWithValue("$pass_word", pass_word);
                command.ExecuteNonQuery();
            }
        }

        //Read User
        static void read_user(){
            //TODO:  
        }

        //Update User
        static void update_user(){
            //TODO:
        }

        //Delete User
        static void delete_user(int user_id){
            using (var connnection = new SqliteConnection("Data Source=rbimstrial.db;")){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM users
                    WHERE user_id = $user_id;
                ";
                command.Parameters.AddWithValue("$user_id", user_id);
                command.ExecuteNonQuery();
            }
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