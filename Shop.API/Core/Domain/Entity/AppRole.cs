namespace Shop.API.Core.Domain.Entity
{
    public class AppRole
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public AppRole()
        {
            AppUsers = new List<AppUser>();
        }
    }
}
