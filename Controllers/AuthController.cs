using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NOWA.Helpers;
using NOWA.Models;
using NOWA.Repositories;
using NOWA.Wrappers;

namespace NOWA.Controllers{

    [Route("api/v1/[controller]")]
    [Authorize]
    public class AuthController : Controller{

        private readonly UserRepository userRepository;
        public AuthController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("[action")]
        [AllowAnonymous]
        public IActionResult Register(User user)
        {

            // Checking mandatory fields
            if (string.IsNullOrEmpty(user.Name) ||
                string.IsNullOrEmpty(user.Email))
                return Json(new SimpleResponser{ Success = false, Message = "It is mandatory to have Name and Email."});
            
            // Validate the password
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            if(!regex.IsMatch(user.Password))
                return Json(new SimpleResponser{ Success = false, Message = "Password should contain 8 character long and at least one number."});

            // Encrypt the password
            user.Password = CryptoHelper.GenerateSHA512String(user.Password);


            // Save the user
            userRepository.InsertUser(user);

            return Json(new SimpleResponser { Success = true, Message = "The user has been created." });
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public IActionResult Login(User user){

            // Checking the user exists in the database
            
            // Create the token based in the complete user info

            // Return the token

            return null;
        }
    }
}