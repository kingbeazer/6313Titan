using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _6313Titan.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("UserId", this.UserId.ToString()));
            // Add custom user claims here
            return userIdentity;
        }
        public string UserId { get; set; }

    }

    namespace App.Extensions
    {
        public static class IdentityExtensions
        {
            public static string GetUserId(this IIdentity identity)
            {
                var claim = ((ClaimsIdentity)identity).FindFirst("UserId");
                // Test for null to avoid issues during local testing
                return (claim != null) ? claim.Value : string.Empty;
            }
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Portal> Portals { get; set; }
        public DbSet<PortalUser> PortalUsers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}