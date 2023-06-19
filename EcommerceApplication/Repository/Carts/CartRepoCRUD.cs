using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Carts;
using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Models.Carts;
using EcommerceApplication.Models.Products;
using EcommerceApplication.Models.Users;

namespace EcommerceApplication.Repository.Carts
{
    public class CartRepoCRUD : ICartRepoCRUD
    {
        private readonly DataContext _context;
        private readonly IUserRepoCRUD _userRepoCRUD;
        private User? _user;
        public CartRepoCRUD(DataContext context, IUserRepoCRUD userRepoCRUD)
        {
            _context = context;
            _userRepoCRUD = userRepoCRUD;
        }

        public bool AddProduct(int UserId, Product Product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int UserId, int productId)
        {
            throw new NotImplementedException();
        }

        public Cart ReadCart(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(int UserId, int productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
