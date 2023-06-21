using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Models.Users;
using Microsoft.EntityFrameworkCore;

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
            return _context.Users
                .Include(u => u.Orders)
                .Include(u => u.Orders)
                    .ThenInclude(o => o.PaymentStatus)
                        .ThenInclude(ps => ps.Payments)
                .Include(u => u.Orders)
                    .ThenInclude(o => o.DeliveryAddress)
                .Include(u => u.Cart)
                .Include(u => u.Address)
                .Include(u => u.Contacts)
                .ToList();
        }

        public bool IfExists(int userId)
        {
            var user = _context.Users.FirstOrDefault(user => user.UserId == userId);
            return user == null ? false : true;
        }

        public bool IfExists(string email)
        {
            var user = _context.Users.FirstOrDefault(user => user.Email.Equals(email));
            return user == null ? false : true;
        }
        public string GetUserName(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(user => user.UserId == userId);
                return user.UserName;
            }
            catch
            {
                return "Annonymous";
            }
        }
    }
}
