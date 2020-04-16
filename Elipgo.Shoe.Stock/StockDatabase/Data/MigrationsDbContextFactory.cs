using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elipgo.ShoeStock.Database.Data
{
    public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("server=localhost;database=ShoeStock;Integrated Security=SSPI;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
