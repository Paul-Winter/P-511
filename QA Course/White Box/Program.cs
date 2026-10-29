using ForTestLibrary;

namespace White_Box
{
    public class Prog
    {
        public static int Summa()
        {
            Calculator calculator = new Calculator();
            int result;
            Console.Write("Введите первое число: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int y = Int32.Parse(Console.ReadLine());
            result = calculator.Sum(x, y);
            return result;
        }
        public static int Submis()
        {
            Calculator calculator = new Calculator();
            int result;
            Console.Write("Введите первое число: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int y = Int32.Parse(Console.ReadLine());
            result = calculator.Sub(x, y);
            return result;
        }
        public static int Multy()
        {
            Calculator calculator = new Calculator();
            int result;
            Console.Write("Введите первое число: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int y = Int32.Parse(Console.ReadLine());
            result = calculator.Mul(x, y);
            return result;
        }
        public static int Divide()
        {
            Calculator calculator = new Calculator();
            int result;
            Console.Write("Введите первое число: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int y = Int32.Parse(Console.ReadLine());
            result = calculator.Div(x, y);
            return result;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КАЛЬКУЛЯТОР");
            bool flag = true;
            while (flag)
            {
                Console.Write("Введите код операции (+, -, *, /, q - для выхода):");
                char operation = Char.Parse(Console.ReadLine());
                switch (operation)
                {
                    case '+': Console.WriteLine($"{Prog.Summa()}"); break;
                    case '-': Console.WriteLine($"{Prog.Submis()}"); break;
                    case '*': Console.WriteLine($"{Prog.Multy()}"); break;
                    case '/': Console.WriteLine($"{Prog.Divide()}"); break;
                    case 'q': Console.WriteLine("До свидания!");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Неверный код операции!");
                        break;
                }
            }
        }
    }
}
