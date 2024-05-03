using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RBIMS_Backend
{
    public class InhabitantCRUD
    {
         //---Inhabitant Table Section (CRUD)---
       
        private string connectionString = new DBInit().connectionString;
        //Create Inhabitant 
        public void addInhabitant(string firstName, string lastName, string middleName, string suffix, string occupation, DateTime dateOfBirth, string sex, string civilStatus, string citizenship, string contactNumber, string educationAttainment, string roleInFamily, string remarks, int familyId, int householdId){
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                    string commandText =
                    @"
                        INSERT INTO inhabitant  (
                        first_name,
                        last_name,
                        middle_name,
                        suffix,
                        occupation,
                        date_of_birth,
                        sex,
                        civil_status,
                        citizenship,
                        contact_num,
                        educ_attainment,
                        role_in_family,
                        remarks,
                        family_id,
                        household_id
                    )
                        VALUES(@first_name, @last_name, @middle_name, @suffix, @occupation, @date_of_birth, @sex, @civil_status, @citizenship, @contact_num, @educ_attainment, @role_in_family, @remarks, @family_id, @household_id);
                    ";

                    using (SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                        command.Parameters.AddWithValue("@first_name", firstName);
                        command.Parameters.AddWithValue("@last_name", lastName);
                        command.Parameters.AddWithValue("@middle_name", middleName);
                        command.Parameters.AddWithValue("@suffix", suffix);
                        command.Parameters.AddWithValue("@occupation", occupation);
                        command.Parameters.AddWithValue("@date_of_birth", dateOfBirth);
                        command.Parameters.AddWithValue("@sex", sex);
                        command.Parameters.AddWithValue("@civil_status", civilStatus);
                        command.Parameters.AddWithValue("@citizenship", citizenship);
                        command.Parameters.AddWithValue("@contact_num", contactNumber);
                        command.Parameters.AddWithValue("@educ_attainment", educationAttainment);
                        command.Parameters.AddWithValue("@role_in_family", roleInFamily);
                        command.Parameters.AddWithValue("@remarks", remarks);
                        command.Parameters.AddWithValue("@family_id", familyId);
                        command.Parameters.AddWithValue("@household_id", householdId);
                        command.ExecuteNonQuery();
                    }
                connection.Close();
            }
        }

        //Read Inhabitant
        public List<Inhabitant> readInhabitant(){
            List<Inhabitant> inhabitantList = new List<Inhabitant>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText =
                @"
                    SELECT * FROM inhabitant
                ";
                
                using (SQLiteCommand command = new SQLiteCommand(commandText,connection))
                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        Inhabitant inhabitant = new Inhabitant{
                            InhabitantId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            MiddleName = reader.GetString(3),
                            Suffix = reader.GetString(4),
                            Occupation = reader.GetString(5),
                            DateOfBirth = reader.GetDateTime(6),
                            Sex = reader.GetString(7),
                            CivilStatus = reader.GetString(8),
                            Citizenship = reader.GetString(9),
                            ContactNumber = reader.GetString(10),
                            RoleInFamily = reader.GetString(11),
                            Remarks = reader.GetString(12),
                            EducationAttainment = reader.GetString(13),
                            FamilyId = reader.GetInt32(14),
                            HouseholdId = reader.GetInt32(15)
                        };
                        inhabitantList.Add(inhabitant);
                    }
                }
                connection.Close();
            }
        return inhabitantList;
        }

        //Update User
        public void updateInhabitant(string firstName, string lastName, string middleName, string occupation, DateTime dateOfBirth, char sex, string civilStatus, string citizenship, string contactNumber, string educationAttainment, string roleInFamily, string remarks, int familyId, int householdId){
            
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText = @"UPDATE inhabitant  
                                        SET first_name = @first_name,
                                            last_name = @last_name, 
                                            middle_name = @middle_name, 
                                            occupation = @occupation, 
                                            date_of_birth = @date_of_birth, 
                                            sex = @sex, 
                                            civil_status = @civil_status, 
                                            citizenship = @citizenship, 
                                            contact_num = @contact_num, 
                                            educ_attainment = @educ_attainment, 
                                            role_in_family = @role_in_family, 
                                            remarks = @remarks, 
                                            family_id = @family_id, 
                                            household_id = @household_id
                                        WHERE inhabitant_id = @inhabitant_id";

                using (SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                    command.Parameters.AddWithValue("@inhabitant_id", firstName);
                    command.Parameters.AddWithValue("@first_name", firstName);
                    command.Parameters.AddWithValue("@last_name", lastName);
                    command.Parameters.AddWithValue("@middle_name", middleName);
                    command.Parameters.AddWithValue("@occupation", occupation);
                    command.Parameters.AddWithValue("@date_of_birth", dateOfBirth);
                    command.Parameters.AddWithValue("@sex", sex);
                    command.Parameters.AddWithValue("@civil_status", civilStatus);
                    command.Parameters.AddWithValue("@citizenship", citizenship);
                    command.Parameters.AddWithValue("@contact_num", contactNumber);
                    command.Parameters.AddWithValue("@educ_attainment", educationAttainment);
                    command.Parameters.AddWithValue("@role_in_family", roleInFamily);
                    command.Parameters.AddWithValue("@remarks", remarks);
                    command.Parameters.AddWithValue("@family_id", familyId);
                    command.Parameters.AddWithValue("@household_id", householdId);
                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected < 1)
                    {
                        throw new EntityNotFoundException("Inhabitant Not Found or No Updates Were Made.");
                    }
                }
            connection.Close();
            }
        }

        //Delete Inhabitant
        public void delete_user(int inhabitant_id){
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText =
                @"
                    DELETE FROM inhabitant
                    WHERE inhabitant_id = @inhabitant_id;
                ";

                using (SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                    command.Parameters.AddWithValue("@inhabitant_id", inhabitant_id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected < 1){
                        throw new EntityNotFoundException("Inhabitant Not Found");
                    }
                }
                connection.Close();
            }
        }
    }
}