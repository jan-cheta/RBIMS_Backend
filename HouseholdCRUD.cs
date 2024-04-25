using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace RBIMS_Backend
{
    public class HouseholdCRUD
    {
         
        private string connectionString = new DBInit().connectionString;
        //Create User 
        public void addHousehold(string HouseholdAddress){
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO household (household_address)
                    VALUES($household_address);
                ";
                command.Parameters.AddWithValue("$household_address", HouseholdAddress);

                command.ExecuteNonQuery();
            }
        }

        //Read User
        public List<Household> readHousehold(){
            List<Household> householdList = new List<Household>();
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM household;
                ";
                
                using(var reader = command.ExecuteReader()){
                    while(reader.Read()){
                        Household household = new Household{
                            HouseholdId = reader.GetInt16(0),
                            HouseholdAddress = reader.GetString(1)
                        };
                        householdList.Add(household);
                    }
                }
            }
            return householdList;
        }

        //Update User
        public void updateHousehold(int householdId, int familyId, string householdAddress){
            
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE user 
                                        SET household_address = @household_address,
                                        WHERE household_id = @household_id";

                command.Parameters.AddWithValue("@household_address", householdAddress);
                command.Parameters.AddWithValue("@household_id", householdId);

                int rowsAffected = command.ExecuteNonQuery();

                if(rowsAffected < 1){
                    throw new EntityNotFoundException("Household/Family Not Found or No Updates Were Made.");
                }
            }
        }

        //Delete User
        public void deleteHousehold(int householdId, int familyId){
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM household
                    WHERE household_id = $household_id;
                ";
                command.Parameters.AddWithValue("$household_id", householdId);

                int rowsAffected = command.ExecuteNonQuery();

                if(rowsAffected < 1){
                    throw new EntityNotFoundException("Household/Family Not Found");
                }
            }
        }
    }
}