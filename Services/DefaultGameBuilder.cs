using GuessNumber.Abstractions;
using GuessNumber.Models;
using GuessNumber.Views;
using Microsoft.Extensions.DependencyInjection;

namespace GuessNumber.Services;

public class DefaultGameBuilder : IGameBuilder
{
    public IServiceCollection Services { get; } = new ServiceCollection();

    public IGameBuilder Configure(GameSettings gameSettings)
    {
        Services.AddSingleton(gameSettings);
        return this;
    }

    public IGame Build()
    {
        return Services
            .AddSingleton<IGameStateMachine, GameStateMachine>()
            .AddSingleton<ITargetNumberService, TargetNumberService>()
            .AddSingleton<IGameView, GameView>()
            .AddSingleton<IGame, Game>()
            .BuildServiceProvider()
            .GetRequiredService<IGame>();
    }
}