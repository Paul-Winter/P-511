namespace Напоминалка2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите время напоминания (часы и минуты в формате ЧЧ:MM):");
            string inputTime = Console.ReadLine();

            Console.WriteLine("Введите текст напоминания:");
            string message = Console.ReadLine();

            if (!TimeSpan.TryParse(inputTime, out TimeSpan targetTime))
            {
                Console.WriteLine("Неверный формат времени!");
                return;
            }

            Console.WriteLine($"Напоминание установлено на {targetTime:hh\\:mm}. Ожидание...");

            while (true)
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                // Проверяем с точностью до минуты
                if (currentTime.Hours == targetTime.Hours && currentTime.Minutes == targetTime.Minutes)
                {
                    Console.WriteLine("\n*** НАПОМИНАНИЕ! ***");
                    Console.WriteLine(message);

                    // Звуковой сигнал ПК
                    Console.Beep();
                    break;
                }

                // Ждем 30 секунд перед следующей проверкой
                Thread.Sleep(30000);
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
