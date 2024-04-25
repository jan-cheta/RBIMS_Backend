using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace RBIMS_Backend
{
    public class UserCRUD
    {
        //---Users Table Section (CRUD)---
        private string connectionString = "Data Source=rbimstrial.db;";
        //Create User 
        public void addUser(string username, string firstName, string lastName, string middleName, string password, string userLevel = "user"){
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO user (username, first_name, last_name, middle_name, user_level, pass_word)
                    VALUES(NULL, $username, $first_name, $last_name, $middle_name, $user_level, $pass_word);
                ";
                command.Parameters.AddWithValue("$username", username);
                command.Parameters.AddWithValue("$first_name", firstName);
                command.Parameters.AddWithValue("$last_name", lastName);
                command.Parameters.AddWithValue("$middle_name", middleName);
                command.Parameters.AddWithValue("$user_level", userLevel);
                command.Parameters.AddWithValue("$pass_word", password);
                command.ExecuteNonQuery();
            }
        }

        //Read User
        public List<User> readUser(){
            List<User> userList = new List<User>();
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    SELECT * FROM user;
                ";
                
                using(var reader = command.ExecuteReader()){
                    while(reader.Read()){
                        User user = new User{
                            UserId = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            LastName = reader.GetString(3),
                            MiddleName = reader.GetString(4),
                            UserLevel = reader.GetString(5),
                            Password = reader.GetString(6)
                        };
                        userList.Add(user);
                    }
                }
            }
            return userList;
        }

        //Update User
        public void updateUser(int userId, string username, string firstName, string lastName, string middleName, string userLevel, string password){
            
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE user 
                                        SET username = @username,
                                            first_name = @first_name,
                                            last_name = @last_name,
                                            middle_name = @middle_name,
                                            user_level = @user_level,
                                            pass_word = @password
                                        WHERE user_id = @user_id;";

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@first_name", firstName);
                command.Parameters.AddWithValue("@last_name", lastName);
                command.Parameters.AddWithValue("@middle_name", middleName);
                command.Parameters.AddWithValue("@user_level", userLevel);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@user_id", userId);

                int rowsAffected = command.ExecuteNonQuery();

               if(rowsAffected < 1)
                {
                    throw new EntityNotFoundException("User Not Found or No Updates Were Made.");
                }
        }
    }

        //Delete User
        public void deleteUser(int userId){
            using (var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var command = connnection.CreateCommand();
                command.CommandText =
                @"
                    DELETE FROM user
                    WHERE user_id = $user_id;
                ";
                command.Parameters.AddWithValue("$user_id", userId);
                int rowsAffected = command.ExecuteNonQuery();

                if(rowsAffected < 1){
                    throw new EntityNotFoundException("User Not Found");
                }
            }
        }
    }
}