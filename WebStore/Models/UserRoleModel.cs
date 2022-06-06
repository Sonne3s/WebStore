using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Models.Enumerations;

namespace WebStore.Models
{
    public class UserRoleModel
    {
        public UserRolesEnumeration Id { get; set; }

        [NotMapped]
        public string Name {
            get 
            {
                return Enum.GetName(typeof(UserRolesEnumeration), this.Id);
            } 
        }

        public List<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
