using Elipgo.ShoeStock.Api.Controllers;
using Elipgo.ShoeStock.Api.Dtos.Responses;
using Elipgo.ShoeStock.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Elipgo.ShoeStock.UnitTests
{
    public class ArticlesControllerTests
    {
        [Fact]
        public async Task TestGetAllArticles()
        {
            var provider = CommonTestUtils.InitializeDatabaseProvider();
            provider.AddStore(new Store() { Address = "Test Address1", Name = "TestName1", Articles = new List<Article>() { new Article() { } } });
            provider.AddStore(new Store() { Address = "Test Address2", Name = "TestName2", Articles = new List<Article>() { new Article() { } } });
            await provider.Save();
            var controller = new ArticlesController(provider, CommonTestUtils.InitializeMapper());

            var result = controller.GetArticles();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<ArticlesListResponseDto>(okResult.Value);
            Assert.Equal(2, model.Articles.Count);
            Assert.Equal(2, model.TotalElements);
            Assert.Equal(200, okResult.StatusCode);
            return;
        }

        [Fact]
        public async Task TestGetAllStoreArticles()
        {
            var provider = CommonTestUtils.InitializeDatabaseProvider();
            provider.AddStore(new Store() { Address = "Test Address1", Name = "TestName1", Articles = new List<Article>() { new Article() { }, new Article() { } } });
            provider.AddStore(new Store() { Address = "Test Address2", Name = "TestName2", Articles = new List<Article>() { new Article() { } } });
            await provider.Save();
            var controller = new ArticlesController(provider, CommonTestUtils.InitializeMapper());

            var result = controller.GetStoreArticles(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<ArticlesListResponseDto>(okResult.Value);
            Assert.Equal(2, model.Articles.Count);
            Assert.Equal(2, model.TotalElements);
            Assert.Equal(200, okResult.StatusCode);
            return;
        }

        [Fact]
        public void TestGetStoreArticlesNotFound()
        {
            var provider = CommonTestUtils.InitializeDatabaseProvider();
            var controller = new ArticlesController(provider, CommonTestUtils.InitializeMapper());

            var result = controller.GetStoreArticles(1);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
            return;
        }
    }
}
