using Avalonia;
using System;

namespace SportsClub
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("=========== ОШИБКА ===========");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("===============================");
                Console.WriteLine();
                Console.WriteLine("Нажми Enter для выхода...");
                Console.ReadLine();
            }
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
    }
}