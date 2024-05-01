using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RBIMS_Backend
{
    public class UserCRUD
    {
        //---Users Table Section (CRUD)---
        
        private string connectionString = new DBInit().connectionString;
        //Create User 
        public void addUser(string username, string firstName, string lastName, string middleName, string password, string userLevel = "user"){
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText =
                @"
                    INSERT INTO user (username, first_name, last_name, middle_name, user_level, pass_word)
                    VALUES(@username, @first_name, @last_name, @middle_name, @user_level, @pass_word);
                ";

                using (SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@first_name", firstName);
                    command.Parameters.AddWithValue("@last_name", lastName);
                    command.Parameters.AddWithValue("@middle_name", middleName);
                    command.Parameters.AddWithValue("@user_level", userLevel);
                    command.Parameters.AddWithValue("@pass_word", password);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Read User
        public List<User> readUser(){
            List<User> userList = new List<User>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();
                string commandText =
                @"
                    SELECT * FROM user;
                ";
                using (SQLiteCommand command = new SQLiteCommand(commandText,connection))
                using (SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        userList.Add(
                            new User{
                                UserId = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                MiddleName = reader.GetString(4),
                                UserLevel = reader.GetString(5),
                                Password = reader.GetString(6)
                            }
                        );
                    }
                }
            connection.Close();                           
            }
            return userList;
        }

        //Update User
        public void updateUser(int userId, string username, string firstName, string lastName, string middleName, string password, string userLevel = "user"){
            
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string commandText = @"UPDATE user 
                                        SET username = @username,
                                            first_name = @first_name,
                                            last_name = @last_name,
                                            middle_name = @middle_name,
                                            user_level = @user_level,
                                            pass_word = @password
                                        WHERE user_id = @user_id;";
                using (SQLiteCommand command = new SQLiteCommand(commandText,connection)){
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
            connection.Close();
        }
    }

        //Delete User
        public void deleteUser(int userId){
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)){
                connection.Open();

                string commandText =
                @"
                    DELETE FROM user
                    WHERE user_id = @user_id;
                ";
                using (SQLiteCommand command = new SQLiteCommand(commandText,connection)){
                    command.Parameters.AddWithValue("@user_id", userId);
                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected < 1){
                    throw new EntityNotFoundException("User Not Found");
                    }
                }
            }
        }
    }
}