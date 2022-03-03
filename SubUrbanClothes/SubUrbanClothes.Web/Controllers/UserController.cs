using SubUrbanClothes.Services;
using SubUrbanClothes.Database;
using Microsoft.AspNetCore.Mvc;
using SubUrbanClothes.Web.Models;

namespace SubUrbanClothes.Web.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult UserProfile()
        {
            User user = new User();
            try
            {
                user = this.userService.UserProfile();
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user, ConfirmPasswordDTO confirmPassword1)
        {
            try
            {
                this.userService.Register(user, confirmPassword1);
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(User user)
        {
            try
            {
                this.userService.LogIn(user);
            }
            catch (MissingMemberException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            catch (AccessViolationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            userService.LogOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditProfile(User user, ConfirmPasswordDTO confirmPassword1)
        {
            try
            {
                this.userService.EditProfile(user, confirmPassword1);
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ExceptionHandling", "Exception", new ExMessDTO(ex.Message));
            }
            return RedirectToAction("UserProfile");
        }

        public IActionResult DeleteUser()
        {
            userService.DeleteUser();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AreYouSure()
        {
            return View();
        }
    }
}
