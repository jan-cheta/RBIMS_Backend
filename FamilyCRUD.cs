using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RBIMS_Backend
{
    public class FamilyCRUD
    {
        private string connectionString = new DBInit().connectionString;
        public void addFamily(int householdId){
            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText = 
                @"
                    INSERT INTO family(household_id)
                    VALUES($household_id);
                ";

                using(SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                    command.Parameters.AddWithValue("household_id", householdId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Family> readFamily(){
            List<Family> familyList = new List<Family>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText =
                @"
                    SELECT * FROM family;
                ";
                
                using(SQLiteCommand command = new SQLiteCommand(commandText,connection))
                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        Family family = new Family{
                            FamilyId = reader.GetInt32(0),
                            HouseholdId = reader.GetInt32(1)
                        };
                        familyList.Add(family);
                    }
                }
                connection.Close();
            }
            return familyList;
        }

        public void updateFamily(int familyId, int householdId){
             using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText = @"UPDATE user 
                                        SET household_id = @household_id,
                                        WHERE family_id = @family_id";

                using(SQLiteCommand command = new SQLiteCommand(commandText, connection)){
                    command.Parameters.AddWithValue("@family_id", familyId);
                    command.Parameters.AddWithValue("@household_id", householdId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected < 1){
                        throw new EntityNotFoundException("Household/Family Not Found or No Updates Were Made.");
                    }
                }
                connection.Close();
            }
        }

        public void deleteFamily(int familyId){
             using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText =
                @"
                    DELETE FROM family
                    WHERE family_id = $family_id;
                ";
                using(SQLiteCommand command = new SQLiteCommand(commandText, connection)){
                    command.Parameters.AddWithValue("$family_id", familyId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected < 1){
                        throw new EntityNotFoundException("Household/Family Not Found");
                    }
                }
                connection.Close();
            }
        }
    }
}