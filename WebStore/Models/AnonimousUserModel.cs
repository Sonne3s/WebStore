using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    [Table("AnonimousUsers")]
    public class AnonimousUserModel : IUserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string Login { get; set; }

        public List<UserRoleModel> Roles { get; set; }

        public bool IsAnonimous { get; set; } = true;
    }
}
