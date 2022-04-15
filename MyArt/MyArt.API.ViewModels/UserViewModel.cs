
namespace MyArt.API.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
    }
}
