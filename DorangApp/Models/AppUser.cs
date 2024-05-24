using Microsoft.AspNetCore.Identity;

namespace DorangApp.Models
{
    public class AppUser: IdentityUser
    {
        public string Name {  get; set; }
        public string Surname{ get; set; }
    }
}
