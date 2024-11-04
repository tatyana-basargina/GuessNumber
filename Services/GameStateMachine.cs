using GuessNumber.Abstractions;
using GuessNumber.Enums;
using GuessNumber.Models;

namespace GuessNumber.Services;

public class GameStateMachine : IGameStateMachine
{
    private readonly int _numberAttempts;
    private readonly ITargetNumberService _targetNumberService;
    
    private int _counterAttempts;
    
    public GameStateMachine(GameSettings gameSettings, ITargetNumberService targetNumberService)
    {
        _numberAttempts = gameSettings.NumberAttempts;
        _targetNumberService = targetNumberService;
    }
    
    public GameAttemptResult MoveNextState(int number)
    {
        if (_counterAttempts >= _numberAttempts)
        {
            return GameAttemptResult.GameOver;
        }
        
        _counterAttempts++;
        
        if (number == _targetNumberService.GetTargetNumber())
        {
            return GameAttemptResult.PlayerWon;
        }
        
        if (number > _targetNumberService.GetTargetNumber())
        {
            return GameAttemptResult.MoreTargetNumber;
        }
        
        return GameAttemptResult.LessTargetNumber;
    }
}