using GuessNumber.Enums;

namespace GuessNumber.Abstractions;

public interface IGameView
{
    int GetNumber();
    void ShowGameAttemptResult(GameAttemptResult gameAttemptResult);
}