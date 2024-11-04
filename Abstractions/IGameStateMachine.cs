using GuessNumber.Enums;

namespace GuessNumber.Abstractions;

public interface IGameStateMachine
{
    GameAttemptResult MoveNextState(int number);
}