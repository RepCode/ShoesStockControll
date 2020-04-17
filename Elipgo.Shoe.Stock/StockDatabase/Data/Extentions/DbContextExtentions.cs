using Elipgo.ShoeStock.Database.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Elipgo.ShoeStock.Database.Data.Extentions
{
    public static class DbContextExtensions
    {
        public static void EnsureSeeded(this ApplicationDbContext context) // this method checks if there are any Cities or States, if not, it adds them 
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
