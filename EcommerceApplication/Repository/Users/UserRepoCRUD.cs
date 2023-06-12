using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Models.Users;

namespace EcommerceApplication.Repository.Users
{
    public class UserRepoCRUD : IUserRepoCRUD
    {
        private readonly DataContext _context;
        public UserRepoCRUD(DataContext context)
        {
            _context = context;
        }

        public bool Create(User User)
        {
            try
            {
                _context.Users.Add(User);
                return _context.SaveChanges() > 0 ? true : false;
            }
            catch {
                return false;
            }
        }
        public User? Read(int UserId)
        {
            try
            {
                var FoundUser = _context.Users.SingleOrDefault(u => u.UserId == UserId);
                return FoundUser;
            }
            catch
            {
                return new User { UserId = -1 };
            }
        }
        public User? Read(string email)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(user => user.Email.Equals(email));
                return user;
            }
            catch
            {
                return new User { UserId = -1 };
            }
        }

        public bool Update(User User)
        {
            try
            {
                _context.Users.Update(User);
                return _context.SaveChanges() > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(User User)
        {
            try
            {
                _context.Users.Remove(User);
                return _context.SaveChanges() > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
    }
}
