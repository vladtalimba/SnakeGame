using SnakeGame.Classes;
using SnakeGame.Interfaces;
using System.Linq.Expressions;

public class Program
{
    public static void Main(string[] args)
    {
        IGame game = new Game();

        game.StartGame();
    }
}