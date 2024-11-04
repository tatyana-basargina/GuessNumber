using GuessNumber.Abstractions;
using GuessNumber.Enums;

namespace GuessNumber.Services;

public class Game : IGame
{
    private readonly IGameStateMachine _stateMachine;
    private readonly IGameView _gameView;

    public Game(IGameStateMachine stateMachine, IGameView gameView)
    {
        _stateMachine = stateMachine;
        _gameView = gameView;
    }

    public void Run()
    {
        while (true)
        {
            int number = _gameView.GetNumber();
            GameAttemptResult result = _stateMachine.MoveNextState(number);
            _gameView.ShowGameAttemptResult(result);

            if (result is GameAttemptResult.PlayerWon or GameAttemptResult.GameOver)
            {
                return;
            }
        }
    }
}