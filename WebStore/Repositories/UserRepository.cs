using Microsoft.EntityFrameworkCore;
using WebStore.Models;
using WebStore.Models.Enumerations;
using WebStore.Repositories.Fillers;
using WebStore.Repositories.IRepositories;

namespace WebStore.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserModel Create(string email, string password)
        {
            using (var db = new Context())
            {
                var newUser = new UserModel
                {
                    Login = email,
                    Password = password,
                    Roles = new List<UserRoleModel>()
                };
                db.Users.Add(newUser);
                db.SaveChanges();

                return newUser;
            }
        }

        public IUserModel CreateAnonimous()
        {
            using (var db = new Context())
            {
                var guid = Guid.NewGuid();

                var newUser = new AnonimousUserModel
                {
                    Id = guid,
                    Login = guid.ToString(),
                    Roles = new List<UserRoleModel>(),
                };
                db.AnonimousUsers.Add(newUser);
                db.SaveChanges();

                return newUser;
            }
        }

        public UserModel Update(UserModel user)
        {
            using (var db = new Context())
            {
                var bdUser = this.Get(user.Login);
                bdUser.FirstName = user.FirstName;
                bdUser.MiddleName = user.MiddleName;
                bdUser.LastName = user.LastName;
                bdUser.Address = user.Address;
                bdUser.Phone = user.Phone;
                bdUser.Company = user.Company;
                db.Users.Update(bdUser);
                db.SaveChanges();

                return bdUser;
            }
        }

        public List<UserModel> GetAll()
        {
            using (var db = new Context())
            {
                return db.Users.ToList();
            }
        }

        public bool Find(string login)
        {
            using (var db = new Context())
            {
                return db.Users.Any(u => u.Login == login);
            }
        }

        private void CreateAdmin()
        {
            using (var db = new Context())
            {
                var admin = db.Users.Include(u => u.Roles).FirstOrDefault(u => u.Login == "email@example.com");

                if(admin != null)
                {
                    admin.Roles = db.UserRoles.ToList();
                    db.Users.Update(admin);
                    db.SaveChanges();
                }
            }
        }

        public UserModel Get(string login)
        {
            using (var db = new Context())
            {
                this.CreateAdmin();

                return db.Users.Include(u => u.Roles).FirstOrDefault(u => u.Login == login);
            }
        }

        public UserModel Get(string login, string password)
        {
            using (var db = new Context())
            {
                this.CreateAdmin();

                return db.Users.Include(u => u.Roles).FirstOrDefault(u => u.Login == login && u.Password == password);
            }
        }

        public IUserModel GetAnonimous(string login)
        {
            using (var db = new Context())
            {
                return db.AnonimousUsers.FirstOrDefault(u => u.Login == login);
            }
        }

        public void DeleteAnonimous(AnonimousUserModel anonimous)
        {
            if(anonimous != null)
            {
                using (var db = new Context())
                {
                    db.AnonimousUsers.Remove(anonimous);
                }
            }
        }

        public List<UserRoleModel> GetAllRoles()
        {
            using (var db = new Context())
            {
                return db.UserRoles.ToList();
            }
        }

        public List<UserRoleModel> GetUserRoles(UserModel user)
        {
            using (var db = new Context())
            {
                return db.UserRoles.Where(r => r.Users.Contains(user)).ToList();
            }
        }

        public UserRoleModel GetUserRole(UserRolesEnumeration roleId)
        {
            using (var db = new Context())
            {
                return db.UserRoles.FirstOrDefault(r => r.Id == roleId);
            }
        }
    }
}
