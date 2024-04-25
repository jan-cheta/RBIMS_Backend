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

        public List<Family> readFamily(){
            List<Family> familyList = new List<Family>();
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM family;
                ";
                
                using(var reader = command.ExecuteReader()){
                    while(reader.Read()){
                        Family family = new Family{
                            FamilyId = reader.GetInt32(0),
                            HouseholdId = reader.GetInt32(1)
                        };
                        familyList.Add(family);
                    }
                }
            }
            return familyList;
        }

        public void updateFamily(int familyId, int householdId){
             using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE user 
                                        SET household_id = @household_id,
                                        WHERE family_id = @family_id";

                command.Parameters.AddWithValue("@family_id", familyId);
                command.Parameters.AddWithValue("@household_id", householdId);

                int rowsAffected = command.ExecuteNonQuery();

                if(rowsAffected < 1){
                    throw new EntityNotFoundException("Household/Family Not Found or No Updates Were Made.");
                }
            }
        }

        public void deleteFamily(int familyId){
             using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM family
                    WHERE family_id = $family_id;
                ";
                command.Parameters.AddWithValue("$family_id", familyId);

                int rowsAffected = command.ExecuteNonQuery();

                if(rowsAffected < 1){
                    throw new EntityNotFoundException("Household/Family Not Found");
                }
            }
        }
    }
}