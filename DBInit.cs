using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace RBIMS_Backend
{
    public class DBInit
    {
        private string connectionString = "Data Source=rbimstrial.db;";
        //DATABASE INITIALIZATION
        public void initSuperAdmin(){
            int count = 0;
            using(var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    SELECT COUNT(*) FROM user                
                ";
                
                count = Convert.ToInt16(command.ExecuteScalar());
            }

            if(count == 0){
                using(var connnection = new SqliteConnection(connectionString)){
                connnection.Open();
                
                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO user
                    VALUES(NULL, 'krocojan', 'Jan Ryan', 'Ancheta', 'Arpon', 'admin', 'kroc');                
                ";
                
                command.ExecuteNonQuery();
            }
            }
        }
        public void initDB(){
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
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

                    CREATE TABLE IF NOT EXISTS household (
                        household_id INTEGER NOT NULL,
                        family_id INTEGER NOT NULL,
                        household_address TEXT, 
                        PRIMARY KEY (household_id, family_id)
                    );

                    CREATE TABLE IF NOT EXISTS inhabitant (
                        inhabitant_id INTEGER PRIMARY KEY,
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
                command.ExecuteNonQuery();
            }
            initSuperAdmin();
        }
    }
}