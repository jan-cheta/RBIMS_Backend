using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace RBIMS_Backend
{
    public class FamilyCRUD
    {
        private string connectionString = new DBInit().connectionString;
        public void addFamily(int householdId){
            using(var connection = new SqliteConnection(connectionString)){
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = 
                @"
                    INSERT INTO family(household_id)
                    VALUES($household_id);
                ";
                command.Parameters.AddWithValue("household_id", householdId);

                command.ExecuteNonQuery();
            }
        }

        public void readFamily(){

        }

        public void updateFamily(){

        }

        public void deleteFamily(){

        }
    }
}