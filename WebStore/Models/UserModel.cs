using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Models.Enumerations;
using WebStore.Repositories;

namespace WebStore.Models
{
    [Table("Users")]

    public class UserModel : IUserModel // : BaseUserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Company { get; set; }

        public List<UserRoleModel> Roles { get; set; } = new List<UserRoleModel>();

        public bool IsAnonimous { get; set; } = false;
    }
}
