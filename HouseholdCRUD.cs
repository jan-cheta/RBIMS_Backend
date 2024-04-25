using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace RBIMS_Backend
{
    public class HouseholdCRUD
    {
         private string connectionString = "Data Source=rbimstrial.db;";
        //Create User 
        public void addHousehold(string HouseholdAddress){
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO user (household_id, family_id, household_address)
                    VALUES(NULL, NULL, $household_address);
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
                            FamilyId = reader.GetInt16(1),
                            HouseholdAddress = reader.GetString(2)
                        };
                        householdList.Add(household);
                    }
                }
            }
            return householdList;
        }

        //Update User
        public void updateUser(int householdId, int familyId, string householdAddress){
            
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE user 
                                        SET household_address = @household_address,
                                        WHERE household_id = @household_id AND family_id = $family_id;";

                command.Parameters.AddWithValue("@household_address", householdAddress);
                command.Parameters.AddWithValue("@household_id", householdId);
                command.Parameters.AddWithValue("@family_id", familyId);

                int rowsAffected = command.ExecuteNonQuery();

                if(rowsAffected < 1){
                    throw new EntityNotFoundException("Household/Family Not Found or No Updates Were Made.");
                }
        }
    }

        //Delete User
        public void deleteUser(int householdId, int familyId){
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM household
                    WHERE household_id = $household_id AND family_id = $family_id;
                ";
                command.Parameters.AddWithValue("$household_id", householdId);
                command.Parameters.AddWithValue("$family_id", familyId);

                int rowsAffected = command.ExecuteNonQuery();

                if(rowsAffected < 1){
                    throw new EntityNotFoundException("Household/Family Not Found");
                }
            }
        }
    }
}