using GuessNumber.Abstractions;
using GuessNumber.Models;

namespace GuessNumber.Services;

public class TargetNumberService : ITargetNumberService
{
    private readonly int _value;

    public TargetNumberService(GameSettings gameSettings)
    {
        _value = new Random().Next(gameSettings.MinTargetValue, gameSettings.MaxTargetValue);
    }
    
    public int GetTargetNumber()
    {
        return _value;
    }
}