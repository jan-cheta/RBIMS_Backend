using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace RBIMS_Backend
{
    public class InhabitantCRUD
    {
         //---Inhabitant Table Section (CRUD)---
        private string connectionString = "Data Source=rbimstrial.db;";
        //Create Inhabitant 
        public void addInhabitant(string firstName, string lastName, string middleName, string occupation, DateTime dateOfBirth, char sex, string civilStatus, string citizenship, string contactNumber, string educationAttainment, string roleInFamily, string remarks, int familyId, int householdId){
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO users (first_name, last_name, middle_name, occupation, date_of_birth, sex, civil_status, citizenship, contact_num, educ_attainment, role_in_family, remarks, family_id, household_id)
                    VALUES($first_name, $last_name, $middle_name, $occupation, $date_of_birth, $sex, $civil_status, $citizenship, $contact_num, $educ_attainment, $role_in_family, $remarks, $family_id, $household_id);
                ";
                command.Parameters.AddWithValue("$first_name", firstName);
                command.Parameters.AddWithValue("$last_name", lastName);
                command.Parameters.AddWithValue("$middle_name", middleName);
                command.Parameters.AddWithValue("$occupation", occupation);
                command.Parameters.AddWithValue("$date_of_birth", dateOfBirth);
                command.Parameters.AddWithValue("$sex", sex);
                command.Parameters.AddWithValue("$civil_status", civilStatus);
                command.Parameters.AddWithValue("$citizenship", citizenship);
                command.Parameters.AddWithValue("$contact_num", contactNumber);
                command.Parameters.AddWithValue("$educ_attainment", educationAttainment);
                command.Parameters.AddWithValue("$role_in_family", roleInFamily);
                command.Parameters.AddWithValue("$remarks", remarks);
                command.Parameters.AddWithValue("$family_id", familyId);
                command.Parameters.AddWithValue("$household_id", householdId);
                command.ExecuteNonQuery();
            }
        }

        //Read Inhabitant
        public List<Inhabitant> readInhabitant(){
            List<Inhabitant> inhabitantList = new List<Inhabitant>();
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM inhabitant
                ";
                
                using(var reader = command.ExecuteReader()){
                    while(reader.Read()){
                        Inhabitant inhabitant = new Inhabitant{
                            InhabitantId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            MiddleName = reader.GetString(3),
                            Occupation = reader.GetString(4),
                            DateOfBirth = reader.GetDateTime(5),
                            Sex = reader.GetChar(6),
                            CivilStatus = reader.GetString(7),
                            Citizenship = reader.GetString(8),
                            ContactNumber = reader.GetString(9),
                            EducationAttainment = reader.GetString(10),

                        };
                        inhabitantList.Add(inhabitant);
                    }
                }
            }
            return inhabitantList;
        }

        //Update User
        public void updateInhabitant(string firstName, string lastName, string middleName, string occupation, DateTime dateOfBirth, char sex, string civilStatus, string citizenship, string contactNumber, string educationAttainment, string roleInFamily, string remarks, int familyId, int householdId){
            
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE inhabitant  
                                        SET first_name = $first_name,
                                            last_name = $last_name, 
                                            middle_name = $middle_name, 
                                            occupation = $occupation, 
                                            date_of_birth = $date_of_birth, 
                                            sex = $sex, 
                                            civil_status = $civil_status, 
                                            citizenship = $citizenship, 
                                            contact_num = $contact_num, 
                                            educ_attainment = $educ_attainment, 
                                            role_in_family = $role_in_family, 
                                            remarks = $remarks, 
                                            family_id = $family_id, 
                                            household_id = $household_id
                                        WHERE inhabitant_id = @inhabitant_id";

                command.Parameters.AddWithValue("$inhabitant_id", firstName);
                command.Parameters.AddWithValue("$first_name", firstName);
                command.Parameters.AddWithValue("$last_name", lastName);
                command.Parameters.AddWithValue("$middle_name", middleName);
                command.Parameters.AddWithValue("$occupation", occupation);
                command.Parameters.AddWithValue("$date_of_birth", dateOfBirth);
                command.Parameters.AddWithValue("$sex", sex);
                command.Parameters.AddWithValue("$civil_status", civilStatus);
                command.Parameters.AddWithValue("$citizenship", citizenship);
                command.Parameters.AddWithValue("$contact_num", contactNumber);
                command.Parameters.AddWithValue("$educ_attainment", educationAttainment);
                command.Parameters.AddWithValue("$role_in_family", roleInFamily);
                command.Parameters.AddWithValue("$remarks", remarks);
                command.Parameters.AddWithValue("$family_id", familyId);
                command.Parameters.AddWithValue("$household_id", householdId);
                int rowsAffected = command.ExecuteNonQuery();

                if(rowsAffected < 1)
                {
                    throw new EntityNotFoundException("Inhabitant Not Found or No Updates Were Made.");
                }
        }
    }

        //Delete Inhabitant
        public void delete_user(int inhabitant_id){
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM inhabitant
                    WHERE inhabitant_id = $inhabitant_id;
                ";
                command.Parameters.AddWithValue("$inhabitant_id", inhabitant_id);
                int rowsAffected = command.ExecuteNonQuery();

                if(rowsAffected < 1){
                    throw new EntityNotFoundException("Inhabitant Not Found");
                }
            }
        }
    }
}