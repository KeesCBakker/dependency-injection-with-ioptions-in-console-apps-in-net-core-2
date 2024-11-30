﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.CommandLine;

static void ConfigureServices(IServiceCollection services)
{
    // configure logging
    services.AddLogging(builder =>
    {
        builder.AddConsole();
        builder.AddDebug();
    });

    // build config
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .AddEnvironmentVariables()
        .Build();

    void Configure<TConfig>(string sectionName) where TConfig : class
    {
        services
            .AddSingleton(p => p.GetRequiredService<IOptions<TConfig>>().Value)
            .AddOptions<TConfig>()
            .Bind(configuration.GetSection(sectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }

    Configure<AppOptions>(AppOptions.SectionName);

    // add services:
    // services.AddTransient<IMyRespository, MyConcreteRepository>();

    // add app
    services.AddTransient<App>();
}

// create service collection
var services = new ServiceCollection();
ConfigureServices(services);

// create service provider
using var serviceProvider = services.BuildServiceProvider();

// entry to run app
await serviceProvider.GetRequiredService<App>().InvokeAsync(args);