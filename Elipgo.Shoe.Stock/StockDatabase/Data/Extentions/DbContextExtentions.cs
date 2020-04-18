using Elipgo.ShoeStock.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Database.Data.Extentions
{
    public static class DbContextExtensions
    {
        public static async Task EnsureSeeded(this ApplicationDbContext context, UserManager<User> userManager) // this method checks if there are any Cities or States, if not, it adds them 
        {
            if (!context.Stores.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var stores = JsonConvert.DeserializeObject<List<Store>>(File.ReadAllText(Path.Combine("." + Path.DirectorySeparatorChar, "SeedData") + Path.DirectorySeparatorChar + "stores.json"));
                        context.AddRange(stores);
                        context.SaveChanges();

                        context.Roles.Add(new IdentityRole() { Name = "admin", NormalizedName = "ADMIN" });
                        context.SaveChanges();
                        var adminUser = new User() { Email = "administration@superzapatos.com", UserName = "admin" };
                        await userManager.CreateAsync(adminUser, "Password1!");
                        await userManager.CreateAsync(new User() { Email = "usuario@superzapatos.com", UserName = "usuario" }, "Password1!");
                        context.SaveChanges();
                        await userManager.AddToRoleAsync(adminUser, "admin");

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
