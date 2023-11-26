using Microsoft.EntityFrameworkCore;
using UserAPI.Context;
using UserAPI.Model;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public int BlockUnBlockUser(bool blockUnblockUser, User userExist)
        {
            userExist.IsBlocked = blockUnblockUser;
            _userDbContext.Entry(userExist).State=EntityState.Modified;
            return _userDbContext.SaveChanges(); 
        }

        public int DeleteUser(User userExist)
        {
           _userDbContext.UserList.Remove(userExist);
            return _userDbContext.SaveChanges();
        }

        public int EditUser(User userExist)
        {
            _userDbContext.Entry(userExist).State = EntityState.Modified;
            return _userDbContext.SaveChanges();
        }

        public List<User> GetAllUser()
        {
           return _userDbContext.UserList.ToList();
        }

        public User GetUserById(int id)
        {
            return _userDbContext.UserList.Where(p=>p.Id == id).FirstOrDefault();
        }

        public User GetUserByName(string name)
        {
            return _userDbContext.UserList.Where(p => p.Name == name).FirstOrDefault();
        }

        public User LogIn(string name, string password)
        {
            return _userDbContext.UserList.Where(p => p.Name == name&& p.Password==password).FirstOrDefault();
        }

        public int RegisterUser(User user)
        {
              _userDbContext.UserList.Add(user);
            return _userDbContext.SaveChanges();
        }
    }
}
