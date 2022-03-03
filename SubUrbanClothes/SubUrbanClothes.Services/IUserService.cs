using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubUrbanClothes.Database;

namespace SubUrbanClothes.Services
{
    interface IUserService
    {
        User UserProfile();
        void Register(User user, ConfirmPasswordDTO confirmPassword);
        void LogIn(User loggingUser);
        void LogOut();
        void EditProfile(User updatedUser, ConfirmPasswordDTO confirmPassword);
        List<Product> GetMyList();
        void DeleteUser();
        string Base64Encode(string plainText);
        void CheckIfThereIsALoggedUser();
    }
}
