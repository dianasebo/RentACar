using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RentACar.Server.DataAccess;
using RentACar.Shared.Models;

namespace RentACar.Server {
    internal class AdminBuilder {
        private readonly RentACarContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminBuilder (RentACarContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        internal void build () {
            CreateRoles(roleManager).Wait();
            CreateAdmin(userManager, roleManager, context).Wait();
        }

        private async Task CreateRoles (RoleManager<IdentityRole> roleManager) 
        {
            var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
            if (!adminRoleExists)
                await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        private async Task CreateAdmin (UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, RentACarContext context) {
            IdentityUser identityUserAdmin = await userManager.FindByEmailAsync ("admin@rentacar.ro");
            if (identityUserAdmin == null) {
                IdentityResult result = await CreateIdentityUserAdmin (userManager);
                if (result.Succeeded)
                    CreateApplicationUserAdmin (context);
                identityUserAdmin = await userManager.FindByEmailAsync ("admin@rentacar.ro");
            }

            var identityUserAdminRoles = await userManager.GetRolesAsync (identityUserAdmin);
            if (!identityUserAdminRoles.Contains("Admin"))
                await userManager.AddToRoleAsync (identityUserAdmin, "Admin");
        }

        private async Task<IdentityResult> CreateIdentityUserAdmin (UserManager<IdentityUser> userManager) {
            var identityUser = new IdentityUser 
            {
                UserName = "admin@rentacar.ro",
                Email = "admin@rentacar.ro"
            };
            return await userManager.CreateAsync (identityUser, "Admin1234!");
        }
        
        private void CreateApplicationUserAdmin (RentACarContext context) {
            var user = new User 
            {
                Email = "admin@rentacar.ro",
                Firstname = "",
                Lastname = ""
            };
            context.UserInfo.Add (user);
        }
    }
}