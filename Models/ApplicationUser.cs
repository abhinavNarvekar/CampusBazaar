using Microsoft.AspNetCore.Identity;

namespace ECommerceMVC.Models
{
    public enum YearType
    {
        FE,
        SE,
        TE,
        BE
    }

    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string Department { get; set; } = null!;
        public YearType Year { get; set; }
    }
}