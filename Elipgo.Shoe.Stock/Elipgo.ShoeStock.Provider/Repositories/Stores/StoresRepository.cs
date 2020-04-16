using Elipgo.ShoeStock.Database.Data;
using Elipgo.ShoeStock.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elipgo.ShoeStock.Provider.Repositories.Stores
{
    internal class StoresRepository : Repository<Store>
    {
        public StoresRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
