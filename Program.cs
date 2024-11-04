using GuessNumber.Abstractions;
using GuessNumber.Models;
using GuessNumber.Services;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
    
IGame game = new DefaultGameBuilder()
    .Configure(configuration.GetSection(nameof(GameSettings)).Get<GameSettings>() 
               ?? throw new Exception("GameSettings not found.") )
    .Build();

game.Run();