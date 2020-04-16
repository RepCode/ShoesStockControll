using AutoMapper;
using Elipgo.ShoeStock.Api.Utils;
using Elipgo.ShoeStock.Database.Data;
using Elipgo.ShoeStock.Provider;
using Microsoft.EntityFrameworkCore;

namespace Elipgo.ShoeStock.UnitTests
{
    public static class CommonTestUtils
    {
        private static int Count = 0;
        public static IMapper InitializeMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            return mockMapper.CreateMapper();
        }

        public static DatabaseProvider InitializeDatabaseProvider()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("testDatabase" + Count);
            Count++;
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);
            return new DatabaseProvider(_dbContext);
        }
    }
}
