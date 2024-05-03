using Microsoft.Extensions.DependencyInjection;
using ZanglMineSweeper;
using ZanglMineSweeper.Interfaces;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            services
                .AddSingleton<Executor, Executor>()
                .BuildServiceProvider()
                .GetService<Executor>()
                .Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        try
        {
            services
                .AddSingleton<IGame, Game>()
                .AddSingleton<IBoard, Board>()
                .AddSingleton<IPlayer, Player>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}