using ProductWebApplication.MVC.Exceptions;
using UserAPI.Model;
using UserAPI.Repository;


namespace UserAPI.Service
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool BlockUnBlockUser(int id, bool blockUnblockUser)
        {
            User userExist = _userRepository.GetUserById(id);
            if (userExist == null)
            {
                return false;
            }
            else
            {
                int blockStatus = _userRepository.BlockUnBlockUser(blockUnblockUser, userExist);
                if(blockStatus == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteUser(int id)
        {
            User UserExist = _userRepository.GetUserById(id);
            if (UserExist != null)
            {
                int userDeleteStatus = _userRepository.DeleteUser(UserExist);
                if(userDeleteStatus == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool EditUser(int id, User user)
        {
            //User userExist = _userRepository.GetUserById(id);
            //if(userExist == null)
            //{
            //    return false;
            //}
            //else
            //{
                user.Id= id;
                int userEditStatus=_userRepository.EditUser(user); 
                if(userEditStatus == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            //}

        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUser();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        
        public User LogIn(LoginUser loginUser)
        {
            User user = _userRepository.LogIn(loginUser.Name, loginUser.Password);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserCredentialInvalidException($"Wrong Creadential");
            }
        }

        public bool RegisterUser(User user)
        {
            var userExist = _userRepository.GetUserByName(user.Name);
            if (userExist == null)
            {
               int RegisterUserStatus= _userRepository.RegisterUser(user);
               if(RegisterUserStatus == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                throw new UserAlreadyExits($"User Already Exist !!");
            }

        }
        
    }
}
