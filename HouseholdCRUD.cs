using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RBIMS_Backend
{
    public class HouseholdCRUD
    {
         
        private string connectionString = new DBInit().connectionString;
        //Create User 
        public void addHousehold(string houseNo, string street, string sitio){
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText =
                @"
                    INSERT INTO household (house_no, street, sitio)
                    VALUES(@house_no, @street, @sitio);
                ";

                using (SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                    command.Parameters.AddWithValue("@house_no", houseNo);
                    command.Parameters.AddWithValue("@street", street);
                    command.Parameters.AddWithValue("@sitio", sitio);

                command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Read User
        public List<Household> readHousehold(){
            List<Household> householdList = new List<Household>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText =
                @"
                    SELECT * FROM household;
                ";
                using(SQLiteCommand command = new SQLiteCommand(commandText,connection))
                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        Household household = new Household{
                            HouseholdId = reader.GetInt32(0),
                            HouseNo = reader.GetString(1),
                            Street = reader.GetString(2),
                            Sitio  = reader.GetString(3)
                        };
                        householdList.Add(household);
                    }
                }
                connection.Close();
            }
            return householdList;
        }

        //Update User
        public void updateHousehold(int householdId, string houseNo, string street, string sitio){
            
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string commandText = @"UPDATE user 
                                        SET house_no = @houseNo,
                                            street = @street,
                                            sitio = @sitio,
                                        WHERE household_id = @household_id";

                using(SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                    command.Parameters.AddWithValue("@houseNo", houseNo);
                    command.Parameters.AddWithValue("@street", street);
                    command.Parameters.AddWithValue("@sitio", sitio);
                    command.Parameters.AddWithValue("@household_id", householdId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected < 1){
                        throw new EntityNotFoundException("Household/Family Not Found or No Updates Were Made.");
                    }
                }
                connection.Close();
            }
        }

        //Delete User
        public void deleteHousehold(int householdId){
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText =
                @"
                    DELETE FROM household
                    WHERE household_id = @household_id;
                ";

                using (SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                    command.Parameters.AddWithValue("$household_id", householdId);

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