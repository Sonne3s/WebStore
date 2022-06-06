namespace WebStore.Models
{
    public interface IUserModel
    {
        Guid Id { get; set; }

        string Login { get; set; }

        List<UserRoleModel> Roles { get; set; }

        bool IsAnonimous { get; set; }
    }
}
