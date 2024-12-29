using System.Threading.Tasks;
using BoilerplatePOC.Models.TokenAuth;
using BoilerplatePOC.Web.Controllers;
using Shouldly;
using Xunit;

namespace BoilerplatePOC.Web.Tests.Controllers
{
    public class HomeController_Tests: BoilerplatePOCWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}