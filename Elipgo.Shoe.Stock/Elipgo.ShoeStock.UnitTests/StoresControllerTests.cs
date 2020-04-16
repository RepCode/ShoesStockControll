using Elipgo.ShoeStock.Api.Controllers;
using Elipgo.ShoeStock.Api.Dtos.Responses;
using Elipgo.ShoeStock.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace Elipgo.ShoeStock.UnitTests
{
    public class StoresControllerTests
    {
        [Fact]
        public async Task TestGetAllStores()
        {
            var provider = CommonTestUtils.InitializeDatabaseProvider();
            provider.AddStore(new Store() { Address = "Test Address1", Name = "TestName1" });
            provider.AddStore(new Store() { Address = "Test Address2", Name = "TestName2" });
            await provider.Save();

            var controller = new StoresController(provider, CommonTestUtils.InitializeMapper());
            var result = controller.GetStores();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<StoresListResponseDto>(okResult.Value);
            Assert.Equal(2, model.Stores.Count);
            Assert.Equal(2, model.TotalElements);
            Assert.Equal(200, okResult.StatusCode);
            return;
        }
    }
}
