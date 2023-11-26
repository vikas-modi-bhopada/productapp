using UserAPI.Model;

namespace UserAPI.Repository
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        int BlockUnBlockUser(bool blockUnblockUser, User userExist);
        int DeleteUser(User userExist); 
        List<User> GetAllUser();
        User LogIn(string name, string password);
        User GetUserByName(string name);
        int RegisterUser(User user);
        int EditUser(User userExist);
    }
}
