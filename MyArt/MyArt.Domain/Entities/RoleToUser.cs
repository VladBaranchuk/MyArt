
namespace MyArt.Domain.Entities
{
    public class RoleToUser
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }

    }
}
