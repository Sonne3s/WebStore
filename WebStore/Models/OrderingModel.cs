using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class OrderingModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public UserModel User { get; set; }

        public Guid? AnonimousUserId { get; set; }

        public AnonimousUserModel AnonimousUser { get; set; }

        public List<OrderingItemModel> Items { get; set; }

        public OrderingInformationModel Information { get; set; }

        public int? InformationId { get; set; }

        public int Status { get; set; }
        
    }
}
