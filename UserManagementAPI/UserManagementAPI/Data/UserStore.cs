using UserManagementAPI.Models;

namespace UserManagementAPI.Data
{
    public static class UserStore
    {
        public static List<User> Users = new List<User>
        {
            new User { Id = 1, Name = "Smit Patel", Email = "smit@test.com" }
        };
    }
}