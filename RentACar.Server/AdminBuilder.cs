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


            IdentityUser identityUserDiana = await userManager.FindByEmailAsync ("diana.sebo@gmail.com");
            if (identityUserDiana == null) {
                IdentityResult result = await CreateIdentityUserDiana (userManager);
                if (result.Succeeded)
                    CreateApplicationUserDiana (context);
            }

            IdentityUser identityUserAmeteo = await userManager.FindByEmailAsync ("stan.ameteo@gmail.com");
            if (identityUserAmeteo == null) {
                IdentityResult result = await CreateIdentityUserAmeteo (userManager);
                if (result.Succeeded)
                    CreateApplicationUserAmeteo (context);
            }
            
            await context.SaveChangesAsync();
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
                Lastname = "",
                IsAdmin = true
            };
            context.UserInfo.Add (user);
        }
        private async Task<IdentityResult> CreateIdentityUserAmeteo (UserManager<IdentityUser> userManager) {
            var identityUser = new IdentityUser 
            {
                UserName = "stan.ameteo@gmail.com",
                Email = "stan.ameteo@gmail.com"
            };
            return await userManager.CreateAsync (identityUser, "Ameteo2010!");
        }
        
        private void CreateApplicationUserAmeteo (RentACarContext context) {
            var user = new User 
            {
                Email = "stan.ameteo@gmail.com",
                Firstname = "Ameteo",
                Lastname = "Stan",
                City = "Timisoara",
                Address = "Strada lunga",
                IsAdmin = false
            };
            context.UserInfo.Add (user);
        }
        private async Task<IdentityResult> CreateIdentityUserDiana (UserManager<IdentityUser> userManager) {
            var identityUser = new IdentityUser 
            {
                UserName = "diana.sebo@gmail.com",
                Email = "diana.sebo@gmail.com"
            };
            return await userManager.CreateAsync (identityUser, "Ameteo2010!");
        }
        
        private void CreateApplicationUserDiana (RentACarContext context) {
            var user = new User 
            {
                Email = "diana.sebo@gmail.com",
                Firstname = "Diana",
                Lastname = "Sebo",
                City = "Timisoara",
                Address = "Strada aia",
                IsAdmin = false
            };
            context.UserInfo.Add (user);
        }
    }
}