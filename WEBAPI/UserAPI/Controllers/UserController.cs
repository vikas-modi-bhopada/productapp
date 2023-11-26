using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Model;
using UserAPI.Service;
using ProductWebApplication.MVC.ExceptionAttribute;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionHandler]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly ITokenGenerator _tokenGenerator;
        public UserController(IUserService userService, ITokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            List<User> users = _userService.GetAllUsers();
            return Ok(users);
        }
        [Route("RegisterUser")]
        [HttpPost]
        public ActionResult RegisterUser(User user)
       
        {
            bool RegisterUserStatus = _userService.RegisterUser(user);
            return Ok(RegisterUserStatus);
        }

        [Route("DeleteUser/{id:int}")]
        [HttpDelete]

        public ActionResult DeleteUser(int id )
        {
            bool userDeleteStatus = _userService.DeleteUser(id);
            return Ok(userDeleteStatus);
        }
        [Route("GetUserById/{id:int}")]
        [HttpGet]
        public ActionResult GetUserById(int id)
        {
            User user = _userService.GetUserById(id);
            return Ok(user);
        }

        [Route ("EditUser/{id:int}")]
        [HttpPut]
        public ActionResult EditUser(int id ,User user)
        {
            bool editUserStatus = _userService.EditUser(id, user);
            return Ok(editUserStatus);
        }
        [Route("BlockUnBlockUser")]
        [HttpPut]
        public ActionResult BlockUnBlockUser(int id, bool blockUnblockUser)
        {
            bool blockUnblockStatus = _userService.BlockUnBlockUser(id,blockUnblockUser);
            return Ok(blockUnblockStatus);
        }
        [Route("LogIn")]
        [HttpPost]
        public ActionResult LogIn(LoginUser loginUser)
        {
            User user = _userService.LogIn(loginUser);
            string userToken = _tokenGenerator.GenerateToken(user.Id, user.Name);
            return Ok(userToken);
        }



    }
}
