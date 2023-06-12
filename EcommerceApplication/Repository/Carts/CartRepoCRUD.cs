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
            if (_user == null)
            {
                _user = _userRepoCRUD.Read(UserId);
            }
            if (_user != null && Product != null)
            {
                if (_user.Cart == null)
                {
                    _user.Cart = new Cart();
                }
                if (_user.Cart.Products == null)
                {
                    _user.Cart.Products = new List<CartItems>();
                }
                CartItems item = new CartItems();
                item.Product = Product;
                item.Quantity = 1;
                _user.Cart.Products.Add(new CartItems());
            }
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteProduct(int UserId, Product Product)
        {
            return true;
        }

        public Cart ReadCart(int UserId)
        {
            return null;
        }

        public bool UpdateProduct(int UserId, Product Product, int quantity)
        {
            return true;
        }
    }
}
