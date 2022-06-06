using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class BaseUserModel : IUserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual Guid Id { get; set; }

        public virtual string Login { get; set; }

        public virtual List<UserRoleModel> Roles { get; set; }

        public virtual bool IsAnonimous { get; set; } = true;
    }
}
