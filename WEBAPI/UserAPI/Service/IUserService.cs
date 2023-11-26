using UserAPI.Model;

namespace UserAPI.Service
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        bool RegisterUser(User user);
        bool EditUser(int id, User user);
        bool BlockUnBlockUser(int id, bool blockUnblockUser);
        User LogIn(LoginUser loginUser);
        bool DeleteUser(int id);
        User GetUserById(int id);
    }
}
