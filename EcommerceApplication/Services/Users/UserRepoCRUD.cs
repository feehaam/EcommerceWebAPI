using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Models.Carts;
using EcommerceApplication.Models.Users;
using Microsoft.EntityFrameworkCore;

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
                User.Cart = new Cart();
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
                var FoundUser = _context.Users
                    .Include(u => u.Orders)
                    .Include(u => u.Orders)
                        .ThenInclude(o => o.PaymentStatus)
                            .ThenInclude(ps => ps.Payments)
                    .Include(u => u.Orders)
                        .ThenInclude(o => o.DeliveryAddress)
                    .Include(u => u.Cart)
                    .Include(u => u.Address)
                    .Include(u => u.Contacts)
                    .FirstOrDefault(u => u.UserId == UserId);
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
                var FoundUser = _context.Users
                    .Include(u => u.Orders)
                    .Include(u => u.Orders)
                        .ThenInclude(o => o.PaymentStatus)
                            .ThenInclude(ps => ps.Payments)
                    .Include(u => u.Orders)
                        .ThenInclude(o => o.DeliveryAddress)
                    .Include(u => u.Cart)
                    .Include(u => u.Address)
                    .Include(u => u.Contacts)
                    .FirstOrDefault(user => user.Email.Equals(email));
                return FoundUser;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool Delete(int UserId)
        {
            try
            {
                _context.Users.Remove(Read(UserId));
                if (_context.SaveChanges() > 0)
                {
                    Address address = _context.Addresses.FirstOrDefault(a => a.AddressId == UserId);
                    if (address != null)
                    {
                        _context.Addresses.Remove(address);
                        _context.SaveChanges();
                    }
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
