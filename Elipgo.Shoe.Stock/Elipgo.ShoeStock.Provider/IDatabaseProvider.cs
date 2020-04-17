using Elipgo.ShoeStock.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Provider
{
    public interface IDatabaseProvider
    {
        public IQueryable<Article> GetStoreArticles(int storeId);
        public IQueryable<Article> GetArticles();
        public IQueryable<Store> GetStores();
        public void AddStore(Store store);
        public Task Save();
        public Store GetStore(int storeId);
    }
}
