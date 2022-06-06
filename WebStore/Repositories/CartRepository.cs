using Microsoft.EntityFrameworkCore;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.Fillers;
using WebStore.Repositories.IRepositories;

namespace WebStore.Repositories
{
    public class CartRepository : ICartRepository
    {
        public OrderingModel Create(IUserModel user)
        {
            using(var db = new Context())
            {
                var ordering = new OrderingModel
                {
                    UserId = (user as UserModel)?.Id,
                    AnonimousUserId = (user as AnonimousUserModel)?.Id,
                    Status = (int)OrderStatusEnumeration.Cart,
                };
                db.Orderings.Add(ordering);
                db.SaveChanges();

                return ordering;
            }
        }

        public void SetInformation(OrderingModel model, string email,  string fullName,  string phone,  string company,  string address,  string dateAndTime,  string other,  int deliveryType)
        {
            using(var db = new Context())
            {
                model.Information = new OrderingInformationModel
                {
                    FullName = fullName,
                    DateAndTime = dateAndTime,
                    DeliveryType = deliveryType,
                    Address = address,
                    Company = company,
                    Email = email,
                    Other = other,
                    Phone = phone,
                };

                db.SaveChanges();
            }
        }

        public void SetStatus(OrderingModel model, OrderStatusEnumeration status)
        {
            using (var db = new Context())
            {
                model.Status = (int)status;

                db.SaveChanges();
            }
        }

        public OrderingModel GetCart(IUserModel user, bool includeItems)
        {
            using (var db = new Context())
            {
                var orderings = db.Orderings.AsQueryable();
                if(includeItems)
                {
                    orderings = orderings.Include(o => o.Items).ThenInclude(i => i.Product).ThenInclude(p => p.ProductType);
                    orderings = orderings.Include(o => o.Items).ThenInclude(i => i.Product).ThenInclude(p => p.Producer);
                    orderings = orderings.Include(o => o.Items).ThenInclude(i => i.Product).ThenInclude(p => p.Images);
                }
                if (user is UserModel)
                {
                    return orderings.FirstOrDefault(o => o.UserId == user.Id && o.Status == (int)OrderStatusEnumeration.Cart);
                }
                else
                {
                    return orderings.FirstOrDefault(o => o.AnonimousUserId == user.Id && o.Status == (int)OrderStatusEnumeration.Cart);
                }
            }
        }

        public List<OrderingModel> GetAll(IUserModel user, OrderStatusEnumeration status)
        {
            using (var db = new Context())
            {
                switch (status)
                {
                    case OrderStatusEnumeration.Actively:
                        return db.Orderings.Where(o => o.UserId == user.Id && o.Status == (int)OrderStatusEnumeration.Actively).ToList();
                    case OrderStatusEnumeration.Done:
                        return db.Orderings.Where(o => o.UserId == user.Id && o.Status == (int)OrderStatusEnumeration.Done).ToList();
                    case OrderStatusEnumeration.Cancelled:
                        return db.Orderings.Where(o => o.UserId == user.Id && o.Status == (int)OrderStatusEnumeration.Cancelled).ToList();
                }

                return db.Orderings.ToList();
            }
        }

        public decimal GetTotal(IUserModel user)
        {
            return this.GetCart(user, true)?.Items?.Sum(i => i.Product.Price * i.Count) ?? 0;
        }

        public bool ChangeUser(UserModel user, AnonimousUserModel anonimous)
        {
            using (var db = new Context())
            {
                db.Orderings.Where(o => o.UserId == anonimous.Id).ToList().ForEach(o =>
                {
                    o.UserId = user.Id;
                    o.User = user;
                });

                return true;
            }
        }

        public OrderingModel ClearCart(IUserModel user)
        {
            using (var db = new Context())
            {
                OrderingModel cart;
                if (user is UserModel)
                {
                    cart = db.Orderings.Include(c => c.Items).FirstOrDefault(o => o.UserId == user.Id && o.Status == (int)OrderStatusEnumeration.Cart);
                }
                else
                {
                    cart = db.Orderings.Include(c => c.Items).FirstOrDefault(o => o.AnonimousUserId == user.Id && o.Status == (int)OrderStatusEnumeration.Cart);
                }
                db.OrderingItems.RemoveRange(cart.Items);
                db.SaveChanges();

                return cart;
            }
        }

        public OrderingItemModel GetCartItem(Guid cartId, int productId)
        {
            using (var db = new Context())
            {
                return db.OrderingItems.FirstOrDefault(i => i.OrderingId == cartId && i.ProductId == productId);
            }
        }
        public OrderingItemModel CreateCartItem(Guid cartId, int productId)
        {
            using (var db = new Context())
            {
                var newItem = new OrderingItemModel
                {
                    OrderingId = cartId,
                    ProductId = productId
                };
                db.OrderingItems.Add(newItem);
                db.SaveChanges();

                return newItem;
            }
        }

        public OrderingItemModel RemoveCartItem(int id)
        {
            using (var db = new Context())
            {
                var item = db.OrderingItems.FirstOrDefault(i => i.Id == id);
                db.OrderingItems.Remove(item);
                db.SaveChanges();

                return item;
            }
        }

        public OrderingItemModel UpdateCartItemCounter(int id, int term)
        {
            using (var db = new Context())
            {
                var item = db.OrderingItems.FirstOrDefault(i => i.Id == id);
                item.Count += term;
                db.OrderingItems.Update(item);
                db.SaveChanges();

                return item;
            }
        }
    }
}
