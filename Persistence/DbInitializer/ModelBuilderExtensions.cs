//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Persistence.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace Persistence.DbInitializer
//{
//    public static class ModelBuilderExtensions
//    {

//        public static async void Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
//        {
//            // Add roles supported
//            await roleManager.CreateAsync(new IdentityRole("admin"));
//            await roleManager.CreateAsync(new IdentityRole("customer"));


//            string adminUserName = "quanbichvan1@gmail.com";
//            var hasher = new PasswordHasher
//            var adminUser = new ApplicationUser
//            {
//                Id = "1cce4e8f-d7e0-43e0-b4cf-f776282ee387",
//                FullName = "Quan Bich Van",
//                Email = "quanbichvan1@gmail.com",
//                PhoneNumber = "0906333687",
//                Address = "Hồ Chí Minh",
//                BirthDate = new DateTime(1999, 03, 03),
//                UserName = "quanbichvan1@gmail.com",
//                NormalizedUserName = "QUANBICHVAN1@GMAIL.COM",
//                PasswordHash = "Dongvu196"
//            };


//            // Add new user and their role
//            await userManager.CreateAsync(adminUser, "Dongvu196");
//            adminUser = await userManager.FindByNameAsync(adminUserName);
//            await userManager.AddToRoleAsync(adminUser, "admin");
//        }
//    }
//}
