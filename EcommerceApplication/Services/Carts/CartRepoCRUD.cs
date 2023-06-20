using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Carts;
using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Models.Carts;
using EcommerceApplication.Models.Products;
using EcommerceApplication.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Repository.Carts
{
    public class CartRepoCRUD : ICartRepoCRUD
    {
        private readonly DataContext _context;
        public CartRepoCRUD(DataContext context, IUserRepoCRUD userRepoCRUD)
        {
            _context = context;
        }


        public Cart ReadCart(int UserId)
        {
            User user = _context.Users
                .Include(x => x.Cart)
                    .ThenInclude(c => c.Products)
                        .ThenInclude(ci => ci.Product)
                .FirstOrDefault(u => u.UserId == UserId);
            if (user == null)
            {
                return null;
            }
            else return user.Cart;
        }

        public bool AddProduct(int UserId, int ProductId, int Quantity)
        {
            try
            {
                User user = _context.Users
                .Include(u => u.Cart)
                    .ThenInclude(c => c.Products)
                        .ThenInclude(ci => ci.Product)
                .FirstOrDefault(u => u.UserId == UserId);
                Product product = _context.Products.FirstOrDefault(u => u.ProductId == ProductId);
                if (user == null || product == null)
                {
                    return false;
                }
                bool add = true;
                foreach(CartItems ci in user.Cart.Products)
                {
                    if(ci.Product.ProductId == ProductId)
                    {
                        ci.IncreaseQuantity(Quantity);
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    user.Cart.Products.Add(new CartItems(product, Quantity));
                    return _context.SaveChanges() > 0 ? true : false;
                }
                return _context.SaveChanges() > 0 ? true : false;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteProduct(int UserId, int productId)
        {
            try
            {
                User user = _context.Users
                .Include(u => u.Cart)
                    .ThenInclude(c => c.Products)
                        .ThenInclude(ci => ci.Product)
                .FirstOrDefault(u => u.UserId == UserId);
                if (user == null)
                {
                    return false;
                }
                bool deleted = false;
                foreach (CartItems ci in user.Cart.Products)
                {
                    if (ci.Product.ProductId == productId)
                    {
                        user.Cart.Products.Remove(ci);
                        deleted = true;
                        break;
                    }
                }
                if (deleted)
                {
                    return _context.SaveChanges() > 0 ? true : false;
                }
                return false;
            }
            catch { return false; }
        }

        public bool UpdateProduct(int UserId, int productId, int quantity)
        {
            try
            {
                User user = _context.Users
                .Include(u => u.Cart)
                    .ThenInclude(c => c.Products)
                        .ThenInclude(ci => ci.Product)
                .FirstOrDefault(u => u.UserId == UserId);
                if (user == null)
                {
                    return false;
                }
                int newQuantity = 0;
                bool updated = false;
                foreach (CartItems ci in user.Cart.Products)
                {
                    if (ci.Product.ProductId == productId)
                    {
                        ci.IncreaseQuantity(quantity);
                        newQuantity = ci.Quantity;
                        updated = true;
                        break;
                    }
                }
                if (updated)
                {
                    if(newQuantity <= 0) return DeleteProduct(UserId, productId);
                    return _context.SaveChanges() > 0 ? true : false;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
