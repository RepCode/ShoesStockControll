using Elipgo.ShoeStock.Database.Data;
using Elipgo.ShoeStock.Database.Models;
using Elipgo.ShoeStock.Provider.Repositories.Articles;
using Elipgo.ShoeStock.Provider.Repositories.Stores;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Elipgo.ShoeStock.Provider
{
    public class DatabaseProvider : IDatabaseProvider
    {
        ApplicationDbContext _context;
        private StoresRepository stores;
        private ArticlesRepository articles;

        public DatabaseProvider(ApplicationDbContext context)
        {
            _context = context;
            stores = new StoresRepository(context);
            articles = new ArticlesRepository(context);
        }

        public IQueryable<Article> GetStoreArticles(int storeId)
        {
            var store = stores.Get(x => x.Id == storeId).Include(x => x.Articles).FirstOrDefault();
            if (store == null)
            {
                return null;
            }
            return store.Articles.AsQueryable();
        }

        public IQueryable<Article> GetArticles()
        {
            return articles.Get().Include(x => x.Store);
        }
        public IQueryable<Store> GetStores()
        {
            return stores.Get();
        }
        public void AddStore(Store store)
        {
            stores.Insert(store);
            return;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
            return;
        }
    }
}
