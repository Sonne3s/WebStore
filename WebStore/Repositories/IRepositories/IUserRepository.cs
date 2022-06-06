using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Repositories.IRepositories
{
    public interface IUserRepository
    {
        UserModel Create(string email, string password);

        IUserModel CreateAnonimous();

        UserModel Update(UserModel user);

        List<UserModel> GetAll();

        bool Find(string login);

        UserModel Get(string login);

        UserModel Get(string login, string password);

        IUserModel GetAnonimous(string login);

        void DeleteAnonimous(AnonimousUserModel anonimous);

        List<UserRoleModel> GetAllRoles();

        List<UserRoleModel> GetUserRoles(UserModel user);

        UserRoleModel GetUserRole(UserRolesEnumeration roleId);
    }
}
