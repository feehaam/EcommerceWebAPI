using EcommerceApplication.Models.Users;

namespace EcommerceApplication.IRepository.Users
{
    public interface IUserRepoCRUD
    {
        public bool Create(User User);
        public User Read(int UserId);
        public bool Update(User User);
        public bool Delete(User User);
    }
}
