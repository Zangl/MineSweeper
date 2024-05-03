using ZanglMineSweeper;
using ZanglMineSweeper.Interfaces;

public class Executor
{
    private readonly IGame _game;

    public Executor(IGame game)
    {
        _game = game;
    }

    public void Execute()
    { 
        Console.WriteLine(_game.StatusText);
        while (!_game.GameOver)
        {
            Console.WriteLine("Enter Direction U,D,L,R");
            string input = Console.ReadLine();

            switch (input)
            {
                case "U":
                    _game.GetBoard().MovePlayer(Direction.Up);
                    break;
                case "D":
                    _game.GetBoard().MovePlayer(Direction.Down);
                    break;
                case "L":
                    _game.GetBoard().MovePlayer(Direction.Left);
                    break;
                case "R":
                    _game.GetBoard().MovePlayer(Direction.Right);
                    break;
            }
            Console.WriteLine(_game.StatusText);
        }
    }
}