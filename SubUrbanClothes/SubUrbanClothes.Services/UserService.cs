using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubUrbanClothes.Database;

namespace SubUrbanClothes.Services
{
    public class UserService : IUserService
    {
        private SubUrbanClothesDbContext database;

        public UserService(SubUrbanClothesDbContext database)
        {
            this.database = database;
        }

        public User UserProfile()
        {
            CheckIfThereIsALoggedUser();

            return database.Users.FirstOrDefault(u => u.IsLoggedIn == true);
        }

        public void Register(User user, ConfirmPasswordDTO confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("Invalid input for password.");
            }
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrEmpty(user.FirstName))
            {
                throw new ArgumentException("Invalid input for first name.");
            }
            if (string.IsNullOrWhiteSpace(confirmPassword.ConfirmPassword) || string.IsNullOrEmpty(confirmPassword.ConfirmPassword))
            {
                throw new ArgumentException("Invalid input for confirmation password.");
            }
            if (user.Password != confirmPassword.ConfirmPassword)
            {
                throw new ArgumentException("Password and confirmation password don't match.");
            }

            user.Password = Base64Encode(user.Password);

            database.Users.Add(user);
            database.SaveChanges();
        }


        public void LogIn(User loggingUser)
        {    
            if (database.Users.Any(x => x.IsLoggedIn == true))
            {
                throw new AccessViolationException("You are logged in, please logout and try again!");
            }
            if (string.IsNullOrEmpty(loggingUser.Password) || string.IsNullOrWhiteSpace(loggingUser.Password))
            {
                throw new InvalidOperationException("Wrong password.");
            }

            database.SaveChanges();
        }

        public void LogOut()
        {
            foreach (var dbUser in database.Users)
            {
                dbUser.IsLoggedIn = false;
                database.Users.Update(dbUser);
            }

            database.SaveChanges();
        }


        public void EditProfile(User updatedUser, ConfirmPasswordDTO confirmPassword)
        {
            User user = database.Users.FirstOrDefault(u => u.IsLoggedIn == true);

            if (string.IsNullOrEmpty(confirmPassword.ConfirmPassword) || string.IsNullOrWhiteSpace(confirmPassword.ConfirmPassword))
            {
                throw new ArgumentException("Wrong confirmation password.");
            }
            if (Base64Encode(confirmPassword.ConfirmPassword) != user.Password)
            {
                throw new ArgumentException("Wrong confirmation password.");
            }
            if (!string.IsNullOrWhiteSpace(updatedUser.Password) || !string.IsNullOrEmpty(updatedUser.Password))
            {
                user.Password = Base64Encode(updatedUser.Password);
            }
            if (!string.IsNullOrWhiteSpace(updatedUser.FirstName) || !string.IsNullOrEmpty(updatedUser.FirstName))
            {
                user.FirstName = updatedUser.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(updatedUser.LastName) || !string.IsNullOrEmpty(updatedUser.LastName))
            {
                user.LastName = updatedUser.LastName;
            }

            database.SaveChanges();
        }

        public void DeleteUser()
        {
            User userToRemove = database.Users.FirstOrDefault(u => u.IsLoggedIn == true);
            database.Users.Remove(userToRemove);
            database.SaveChanges();
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public void CheckIfThereIsALoggedUser()
        {
            List<User> users = database.Users.ToList();

            if (!users.Exists(u => u.IsLoggedIn == true))
            {
                throw new AccessViolationException("You must log in first!");
            }
        }
    }
}
