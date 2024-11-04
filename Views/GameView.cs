using GuessNumber.Abstractions;
using GuessNumber.Enums;

namespace GuessNumber.Views;

public class GameView : IGameView
{
    public int GetNumber()
    {
        bool isNumber = false;
        int number = 0;
        
        while (!isNumber)
        {
            Console.Write("Enter number: ");
            isNumber = int.TryParse(Console.ReadLine(), out number);

            if (!isNumber)
            {
                Console.WriteLine("Please enter a number!");
            }
        }
        return number;
    }

    public void ShowGameAttemptResult(GameAttemptResult result)
    {
        string message = result switch
        {
            GameAttemptResult.PlayerWon => "You won!",
            GameAttemptResult.GameOver => "You lose!",
            GameAttemptResult.LessTargetNumber => $"Your number is less than the target number!",
            GameAttemptResult.MoreTargetNumber => $"Your number is more than the target number!",
            _ => string.Empty
        };
        Console.WriteLine(message);
    }
}