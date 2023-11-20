namespace JCAApi.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<UserPermission> Permissions { get; set; }
    }

    public enum UserPermission
    {
        Default,
        Admin
    }
}
