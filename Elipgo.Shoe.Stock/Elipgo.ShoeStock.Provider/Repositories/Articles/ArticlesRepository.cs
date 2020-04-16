using Elipgo.ShoeStock.Database.Data;
using Elipgo.ShoeStock.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elipgo.ShoeStock.Provider.Repositories.Articles
{
    internal class ArticlesRepository : Repository<Article>
    {
        public ArticlesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
