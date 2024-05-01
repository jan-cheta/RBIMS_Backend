using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBIMS_Backend
{
    public class LogIn
    {
        UserCRUD crud = new UserCRUD();
        public bool loginValidate(string username, string password){
            List<User> users = crud.readUser();
            bool isValid = false;

            foreach(User user in users){
                if(user.Username.Equals(username) & user.Password.Equals(password)){
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

        public string userGetLevel(string username, string password){
            List<User> users = crud.readUser();

            string level = "";
            foreach(User user in users){
                if(user.Username.Equals(username) & user.Password.Equals(password)){
                    level = user.UserLevel;
                }
            }

            return level.ToUpper();
        }

        public bool signupValidate(string username){
            List<User> users = crud.readUser();
            bool isValid = true;

            foreach(User user in users){
                if(user.Username.Equals(username)){
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
    }
}