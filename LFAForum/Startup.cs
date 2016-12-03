using LFAForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LFAForum.Startup))]
namespace LFAForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //createRoleandUsers();
        }


        // In this method we will create default User roles and Admin user for login   
        //private void createRoleandUsers()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        //    // In Startup iam creating first Admin Role and creating a default Admin User 
        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        // first we create Admin role
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Admin";
        //        roleManager.Create(role);

        //        //Here we create a Admin super user who will maintain the website
        //        var user = new ApplicationUser();
        //        user.UserName = "abhishek";
        //        user.Email = "a.bhandari075@gmail.com";

        //        string userPWD = "Flash137!";

        //        var chkUser = UserManager.Create(user, userPWD);

        //        //Add default User to Role Admin   
        //        if (chkUser.Succeeded)
        //        {
        //            var result1 = UserManager.AddToRole(user.Id, "Admin");

        //        }
        //    }

        //    // Creating Manager role 
        //    if (!roleManager.RoleExists("AuthUser"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "AuthUser";
        //        roleManager.Create(role);

        //    }

        //    // creating Creating Employee role    
        //    if (!roleManager.RoleExists("User"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "User";
        //        roleManager.Create(role);

        //    }
        //}   
    }
    
}


