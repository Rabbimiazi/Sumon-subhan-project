using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Resturant.Models;
using System;

[assembly: OwinStartupAttribute(typeof(Resturant.Startup))]
namespace Resturant
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultAdminRoles();
        }

        public void CreateDefaultAdminRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admin"))
            {
                role.Name = "Admin";
                roleManager.Create(role);

                var userId = Guid.NewGuid().ToString();
                ApplicationUser user = new ApplicationUser();
                user.UserName = "ruposhibanglacox@gmail.com";
                user.Email = "ruposhibanglacox@gmail.com";
                user.Id = userId;

                PasswordHasher hasher = new PasswordHasher();
                string pass = hasher.HashPassword("@Test123");
                user.PasswordHash = pass;
                var check = userManager.Create(user);

                if (check.Succeeded)
                {
                    userManager.AddToRoles(user.Id, "Admin");

                }
                else
                {
                    var e = new Exception("Could not add default Admin");
                    var enumerator = check.Errors.GetEnumerator();
                    foreach (var error in check.Errors)
                    {
                        e.Data.Add(enumerator.Current, error);
                    }

                    throw e;
                }
            }
        }
    }
}
