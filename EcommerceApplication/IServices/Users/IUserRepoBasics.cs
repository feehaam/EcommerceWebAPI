using EcommerceApplication.Models.Users;

namespace EcommerceApplication.IRepository.Users
{
    public interface IUserRepoBasics
    {
        public ICollection<User> GetAllUsers();
        public bool IfExists(int userId);
        public bool IfExists(string email);
        public string GetUserName(int userId);
    }
}
