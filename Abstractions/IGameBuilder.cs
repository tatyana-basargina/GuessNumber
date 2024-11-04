using Microsoft.Extensions.DependencyInjection;

namespace GuessNumber.Abstractions;

public interface IGameBuilder
{
    IServiceCollection Services { get; }
    IGame Build();
}