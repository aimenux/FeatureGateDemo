using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tests;

public class DummyControllerTests : IClassFixture<WebApiTestFixture>
{
    [Fact]
    public async Task ShouldGetOkStatusCodeWhenFeatureIsEnabled()
    {
        // arrange
        var fixture = new WebApiTestFixture();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync("/dummy/info");

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task ShouldGetNotFoundStatusCodeWhenFeatureIsDisabled()
    {
        // arrange
        var fixture = new WebApiTestFixture
        {
            IsGetInfoFeatureEnabled = false
        };
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync("/dummy/info");

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}