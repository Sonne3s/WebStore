using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Repositories.Fillers
{
    public class FakeUserRoleFiller
    {
        private static List<UserRoleModel> values;

        static FakeUserRoleFiller() => values = Initial();

        public static List<UserRoleModel> Get() => values;

        private static List<UserRoleModel> Initial() => Enum.GetValues<UserRolesEnumeration>().Select(e => new UserRoleModel(){ Id = e }).ToList();
    }
}
