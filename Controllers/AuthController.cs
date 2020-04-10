using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NOWA.Helpers;
using NOWA.Models;
using NOWA.Repositories;
using NOWA.Wrappers;

namespace NOWA.Controllers{

    [Route("api/v1/[controller]")]
    [Authorize]
    public class AuthController : Controller{

        private readonly UserRepository userRepository;
        private readonly IConfiguration configuration;
        public AuthController(UserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] User user)
        {

            // Checking mandatory fields
            if (string.IsNullOrEmpty(user.Name) ||
                string.IsNullOrEmpty(user.Email))
                return Json(new SimpleResponser{ Success = false, Message = "It is mandatory to have Name and Email."});
            
            // Verifying the user does not exists already
            if(userRepository.UserAlreadyExists(user.Email))
                return Json(new SimpleResponser { Success = false, Message = "This email is token."});

            // Validate the password
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            if(!regex.IsMatch(user.Password))
                return Json(new SimpleResponser{ Success = false, Message = "Password should contain 8 character long and at least one number."});

            // Encrypt the password
            user.Password = CryptoHelper.GenerateSHA512String(user.Password);


            // Save the user
            userRepository.InsertUser(user);
            userRepository.Save();

            return Json(new SimpleResponser { Success = true, Message = "The user has been created." });
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User user){

            // Checking it has mandatory fields
            if(string.IsNullOrEmpty(user.Email) ||string.IsNullOrEmpty(user.Password))
                return Json(new SimpleResponser {Success = false, Message = "Email and Password are necessary."});

            // Checking the user exists in the database
            user.Password = CryptoHelper.GenerateSHA512String(user.Password);
            if(!userRepository.UserCredentialsAreCorrect(user.Email, user.Password))
                return Json(new SimpleResponser {Success = false, Message = "Credentials are not correct."});
            

            // Create the token based in the complete user info
            string JWT = JWTHelper.CreateToken(user, configuration);

            // Return the token
            return Json(new ComplexResponser<string> {Success = true, Message = "User loged.", Content = JWT});
        }
    }
}