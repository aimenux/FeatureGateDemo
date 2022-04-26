using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using WebApi;

namespace Tests;

public class WebApiTestFixture : WebApplicationFactory<Startup>
{
    public bool IsGetInfoFeatureEnabled { get; set; } = true;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context, configBuilder) =>
        {
            configBuilder.AddInMemoryCollection(new Dictionary<string, string>
            {
                [FeatureFlags.GetInfoFeature.ToConfigurationKeyName()] = IsGetInfoFeatureEnabled.ToString()
            });
        });

        builder.ConfigureTestServices(services =>
        {
        });
    }
}