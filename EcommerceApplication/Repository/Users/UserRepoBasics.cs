using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Models.Users;

namespace EcommerceApplication.Repository.Users
{
    public class UserRepoBasics : IUserRepoBasics
    {
        private readonly DataContext _context;
        public UserRepoBasics(DataContext context)
        {
            _context = context;
        }
        public ICollection<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public bool IfExists(int userId)
        {
            Console.WriteLine("I'm here!!!!!!!!!!!!!!!!!!!!!!!!!!! finding the user {0}", userId);
            var user = _context.Users.FirstOrDefault(user => user.UserId == userId);
            return user == null ? false : true;
        }

        public bool IfExists(string email)
        {
            var user = _context.Users.FirstOrDefault(user => user.Email.Equals(email));
            return user == null ? false : true;
        }
    }
}
