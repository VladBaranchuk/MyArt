
namespace MyArt.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RoleToUser> RoleToUsers { get; set; }
    }
}
