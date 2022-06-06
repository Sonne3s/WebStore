using WebStore.Models;
using WebStore.Repositories.IRepositories;

namespace WebStore.Repositories.Fillers
{
    public class FakeUserFiller
    {
        private static IUserRepository _userRepository;
        private static List<UserModel> values;

        static FakeUserFiller()
        {
            _userRepository = new UserRepository();
            values = FakeUserFiller.Initial();
        }

        public static List<UserModel> Get() => values;

        private static List<UserModel> Initial()
        {
            return new List<UserModel>()
            {
                new UserModel
                {
                    Id = Guid.NewGuid(),
                    Login = "email@example.com",
                    Password = "12345",
                    Roles = _userRepository.GetAllRoles(),
                },
            };
        }
    }
}
