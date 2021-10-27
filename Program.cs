using System;
using DataHandler;
using GenerateTables.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
	.AddUserSecrets<DataHandlerService>()
	.Build();

IServiceCollection services = new ServiceCollection();
services.AddDbContext<AAtims>(options => 
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());

services.AddSingleton<IDataHandlerService, DataHandlerService>();
ServiceProvider serviceProvider = services.BuildServiceProvider();
IServiceScope scope = serviceProvider.CreateScope();
Console.WriteLine("Getting Required Service. May take a while");
await scope.ServiceProvider.GetRequiredService<IDataHandlerService>().Run();

await serviceProvider.DisposeAsync();
