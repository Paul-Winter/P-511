using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace sea_wars
{
    public class Game
    {
        public int[,] deck1 = new int[12, 12];
        public int[,] deck2 = new int[12, 12];
        protected char[] symbols = new char[10];
        protected string password1;
        protected string password2;
        protected const int symbolssum = 64;
        public int status1;
        public int status2;
        public Profiles profiles = new Profiles();
        protected Random rand = new Random();
        public Game()
        {
            status1 = 0; status2 = 0;
            for (int i = 0; i < 10; i++)
            {
                symbols[i] = (char)(i + symbolssum + 1);
            }
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    deck1[i, j] = 0;
                    deck2[i, j] = 0;
                }
            }
        }

        public void Cleardecks()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    deck1[i, j] = 0;
                    deck2[i, j] = 0;
                }
            }
        }
        public void Cleardeck1()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    deck1[i, j] = 0;
                }
            }
        }
        public void Cleardeck2()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    deck2[i, j] = 0;
                }
            }
        }
        /*public void Printdeck1build()
        {
            Console.WriteLine("_ - Пустое поле\no - поле вокруг корабля\nX - корабль\n");
            Console.Write("\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            for (int i = 1; i < 11; i++)
            {
                Console.Write("\n" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck1[i, j] == 0)
                        Console.Write("_ ");
                    else if (deck1[i, j] == 1)
                        Console.Write("o ");
                    else if (deck1[i, j] == 2)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
            }
        }
        public void Printdeck2build()
        {
            Console.WriteLine("_ - Пустое поле\no - поле вокруг корабля\nX - корабль\n");
            Console.Write("\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            for (int i = 1; i < 11; i++)
            {
                Console.Write("\n" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck2[i, j] == 0)
                        Console.Write("_ ");
                    else if (deck2[i, j] == 1)
                        Console.Write("o ");
                    else if (deck2[i, j] == 2)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
            }
        }
        public void Printdeck1public()
        {
            Console.WriteLine("_ - Пустое поле\nO - Промах или поле вокруг разбитого корабля\nx - корабль\nX - попадание по кораблю\n");
            Console.Write("\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            for (int i = 1; i < 11; i++)
            {
                Console.Write("\n" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck1[i, j] == 0 || deck1[i, j] == 1)
                        Console.Write("_ ");
                    else if (deck1[i, j] == 3 || deck1[i, j] == 5)
                        Console.Write("O ");
                    else if (deck1[i, j] == 2)
                        Console.Write("x ");
                    else if (deck1[i, j] == 4)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
            }
        }
        public void Printdeck1private()
        {
            Console.WriteLine("_ - Пустое поле\nO - Промах или поле вокруг разбитого корабля\nX - попадание по кораблю\n");
            Console.Write("\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            for (int i = 1; i < 11; i++)
            {
                Console.Write("\n" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck1[i, j] == 0 || deck1[i, j] == 1 || deck1[i, j] == 2)
                        Console.Write("_ ");
                    else if (deck1[i, j] == 3 || deck1[i, j] == 5)
                        Console.Write("O ");
                    else if (deck1[i, j] == 4)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
            }
        }
        public void Printdeck2public()
        {
            Console.WriteLine("_ - Пустое поле\nO - Промах или поле вокруг разбитого корабля\nx - корабль\nX - попадание по кораблю\n");
            Console.Write("\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            for (int i = 1; i < 11; i++)
            {
                Console.Write("\n" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck2[i, j] == 0 || deck2[i, j] == 1)
                        Console.Write("_ ");
                    else if (deck2[i, j] == 3 || deck2[i, j] == 5)
                        Console.Write("O ");
                    else if (deck2[i, j] == 2)
                        Console.Write("x ");
                    else if (deck2[i, j] == 4)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
            }
        }
        public void Printdeck2private()
        {
            Console.WriteLine("_ - Пустое поле\nO - Промах или поле вокруг разбитого корабля\nX - попадание по кораблю\n");
            Console.Write("\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            for (int i = 1; i < 11; i++)
            {
                Console.Write("\n" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck2[i, j] == 0 || deck2[i, j] == 1 || deck2[i, j] == 2)
                        Console.Write("_ ");
                    else if (deck2[i, j] == 3 || deck2[i, j] == 5)
                        Console.Write("O ");
                    else if (deck2[i, j] == 4)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
            }
        }
        public virtual void Print2decks()
        {
            Console.WriteLine("_ - Пустое поле\nO - Промах или поле вокруг разбитого корабля\nX - попадание по кораблю\n");
            Console.WriteLine("\t\t1 Доска\t\t\t\t\t2 Доска");
            Console.Write("\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            Console.Write("\t\t\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            for (int i = 1; i < 11; i++)
            {
                Console.Write("\n" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck1[i, j] == 0 || deck1[i, j] == 1 || deck1[i, j] == 2)
                        Console.Write("_ ");
                    else if (deck1[i, j] == 3 || deck1[i, j] == 5)
                        Console.Write("O ");
                    else if (deck1[i, j] == 4)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
                Console.Write("\t\t" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck2[i, j] == 0 || deck2[i, j] == 1 || deck2[i, j] == 2)
                        Console.Write("_ ");
                    else if (deck2[i, j] == 3 || deck2[i, j] == 5)
                        Console.Write("O ");
                    else if (deck2[i, j] == 4)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
            }
        }*/
        private string ReadToken()
        {
            string token = "";
            int ch;
            while ((ch = Console.Read()) != -1)
            {
                char c = (char)ch;
                if (char.IsWhiteSpace(c))
                {
                    if (token.Length > 0) break;
                }
                else
                {
                    token += c;
                }
            }
            return token;
        }
        private string ReadStringWithDigitsSplit(out int num, out char letter)
        {
            string token = ReadToken();
            num = 0;
            letter = '\0';
            string numStr = "";
            int i = 0;
            while (i < token.Length && char.IsDigit(token[i]))
            {
                numStr += token[i];
                i++;
            }
            if (numStr.Length > 0) num = int.Parse(numStr);
            if (i < token.Length) letter = token[i];
            return token;
        }
        public int Checkdeck()
        {
            bool temper = false;
            while (!temper)
            {
                Console.Write("\n\nВведите пароль своей доски (0 - выход): ");
                string temp = ReadToken();
                if (profiles.Checkpassword1(temp))
                {
                    Console.Clear();
                    Console.Write("\n\nВНИМАНИЕ!!! Сейчас будет показаны местоположения кораблей на 1 доске. Если 2 игрок не смотрит, напишите '+': ");
                    char temp1 = '-';
                    while (temp1 != '+')
                    {
                        string tk = ReadToken();
                        if (tk.Length > 0) temp1 = tk[0];
                    }
                    Console.Write("\n\n");
                    Console.Write("\n\nНапишите '+' для очистки консоли: ");
                    temp1 = '-';
                    while (temp1 != '+')
                    {
                        string tk = ReadToken();
                        if (tk.Length > 0) temp1 = tk[0];
                    }
                    Console.Clear();
                    Console.Write("Напишите любой символ: ");
                    temper = true;
                }
                else if (profiles.Checkpassword2(temp))
                {
                    Console.Clear();
                    Console.Write("\n\nВНИМАНИЕ!!! Сейчас будет показаны местоположения кораблей на 2 доске. Если 1 игрок не смотрит, напишите '+': ");
                    char temp1 = '-';
                    while (temp1 != '+')
                    {
                        string tk = ReadToken();
                        if (tk.Length > 0) temp1 = tk[0];
                    }
                    Console.Write("\n\n");
                    Console.Write("\n\nНапишите '+' для очистки консоли: ");
                    temp1 = '-';
                    while (temp1 != '+')
                    {
                        string tk = ReadToken();
                        if (tk.Length > 0) temp1 = tk[0];
                    }
                    Console.Clear();
                    Console.Write("Напишите любой символ: ");
                    temper = true;
                }
                else if (temp == "0")
                {
                    temper = true;
                }
                else
                {
                    Console.WriteLine("Пароль неверный, попробуйте еще раз.");
                }
            }
            return 0;
        }
        public void Setshipdeck1(int lenght)
        {
            Console.Clear();
            bool temp = false;
            Console.WriteLine("\n\nПостановка " + lenght + "-палубного корабля на доску 1\n");
            int temp1 = 0; char temp2 = 'А'; bool temp3 = false; bool temp4 = false; int reboot = 0;
            int A = 0, B = 0;
            while (!temp)
            {
                while (!temp3)
                {
                    reboot++;
                    if (reboot == 10)
                    {
                        Console.Write("Произошел сбой! Откат изменений...");
                        temp3 = true;
                        temp = true;
                        break;
                    }
                    Console.Write("Выберите позицию хвоста корабля (цифру от 1 до 10 и заглавную английскую букву от " + symbols[0] + " до " + symbols[9] + " слитно(1A, 2B)): ");
                    ReadStringWithDigitsSplit(out A, out temp2);
                    B = (int)temp2 - symbolssum;
                    if (A >= 1 && A <= 10 && B >= 1 && B <= 10 && deck1[A, B] == 0)
                        temp3 = true;
                    else
                        Console.WriteLine("\nПрограмма не смогла определить позицию хвоста или в этой позиции нельзя установить корабль! Попробуйте еще раз\n");
                }
                if (lenght == 1)
                {
                    Console.WriteLine("Позиция корабля " + A + temp2);
                    deck1[A, B] = 2; deck1[A - 1, B] = 1; deck1[A + 1, B] = 1;
                    deck1[A, B - 1] = 1; deck1[A - 1, B - 1] = 1; deck1[A + 1, B - 1] = 1;
                    deck1[A, B + 1] = 1; deck1[A + 1, B + 1] = 1; deck1[A - 1, B + 1] = 1;
                    temp = true;
                    temp3 = true;
                    break;
                }
                Console.WriteLine("Позиция хвоста " + A + temp2);
                reboot = 0;
                temp3 = false;
                while (!temp3)
                {
                    reboot++;
                    if (reboot == 10)
                    {
                        Console.Write("Произошел сбой! Откат изменений...");
                        temp3 = true;
                        temp = true;
                        break;
                    }
                    Console.Write("Выберите направление корабля\n1 - влево\n2 - вверх\n3 - вправо\n4 - вниз\nВыбор: ");
                    string tk = ReadToken();
                    if (int.TryParse(tk, out temp1))
                    {
                        while (temp1 < 1 || temp1 > 4)
                        {
                            Console.Write("Неккоректный ввод, еще раз: ");
                            string tk2 = ReadToken();
                            int.TryParse(tk2, out temp1);
                        }
                    }
                    switch (temp1)
                    {
                        case 1:
                            temp4 = false;
                            if ((B - lenght + 1) > 0)
                            {
                                for (int i = B - lenght + 1; i < B; i++)
                                {
                                    if (deck1[A, i] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((B - lenght + 1) < 1 || temp4 == true)
                            {
                                Console.WriteLine("Нельзя поставить корабль влево, выберите другое направление");
                                break;
                            }
                            Console.WriteLine("\nНачальная и конечная позиция корабля " + A + (char)(B + symbolssum + 1 - lenght) + " - " + A + (char)(B + symbolssum) + "\nВыполняется постановка...");
                            for (int i = 0; i < lenght; i++)
                            {
                                deck1[A, B - i] = 2;
                                deck1[A - 1, B - i] = 1;
                                deck1[A + 1, B - i] = 1;
                            }
                            deck1[A, B - lenght] = 1; deck1[A - 1, B - lenght] = 1; deck1[A + 1, B - lenght] = 1;
                            deck1[A, B + 1] = 1; deck1[A + 1, B + 1] = 1; deck1[A - 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 2:
                            temp4 = false;
                            if ((A - lenght + 1) > 0)
                            {
                                for (int i = A - lenght + 1; i < A; i++)
                                {
                                    if (deck1[i, B] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((A - lenght + 1) < 1 || temp4 == true)
                            {
                                Console.WriteLine("Нельзя поставить корабль вверх, выберите другое направление");
                                break;
                            }
                            Console.WriteLine("\nНачальная и конечная позиция корабля " + (A - lenght + 1) + (char)(B + symbolssum) + " - " + A + (char)(B + symbolssum) + "\nВыполняется постановка...");
                            for (int i = 0; i < lenght; i++)
                            {
                                deck1[A - i, B] = 2;
                                deck1[A - i, B - 1] = 1;
                                deck1[A - i, B + 1] = 1;
                            }
                            deck1[A - lenght, B] = 1; deck1[A - lenght, B - 1] = 1; deck1[A - lenght, B + 1] = 1;
                            deck1[A + 1, B] = 1; deck1[A + 1, B - 1] = 1; deck1[A + 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 3:
                            temp4 = false;
                            if ((B + lenght - 1) < 11)
                            {
                                for (int i = B; i < B + lenght - 1; i++)
                                {
                                    if (deck1[A, i] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((B + lenght - 1) > 10 || temp4 == true)
                            {
                                Console.WriteLine("Нельзя поставить корабль вправо, выберите другое направление");
                                break;
                            }
                            Console.WriteLine("\nНачальная и конечная позиция корабля " + A + (char)(B + symbolssum) + " - " + A + (char)(B + symbolssum + lenght - 1) + "\nВыполняется постановка...");
                            for (int i = 0; i < lenght; i++)
                            {
                                deck1[A, B + i] = 2;
                                deck1[A - 1, B + i] = 1;
                                deck1[A + 1, B + i] = 1;
                            }
                            deck1[A, B + lenght] = 1; deck1[A - 1, B + lenght] = 1; deck1[A + 1, B + lenght] = 1;
                            deck1[A, B - 1] = 1; deck1[A + 1, B - 1] = 1; deck1[A - 1, B - 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 4:
                            temp4 = false;
                            if ((A + lenght - 1) < 11)
                            {
                                for (int i = A; i < A + lenght - 1; i++)
                                {
                                    if (deck1[i, B] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((A + lenght - 1) > 10 || temp4 == true)
                            {
                                Console.WriteLine("Нельзя поставить корабль вниз, выберите другое направление");
                                break;
                            }
                            Console.WriteLine("\nНачальная и конечная позиция корабля " + A + (char)(B + symbolssum) + " - " + (A + lenght - 1) + (char)(B + symbolssum) + "\nВыполняется постановка...");
                            for (int i = 0; i < lenght; i++)
                            {
                                deck1[A + i, B] = 2;
                                deck1[A + i, B - 1] = 1;
                                deck1[A + i, B + 1] = 1;
                            }
                            deck1[A + lenght, B] = 1; deck1[A + lenght, B - 1] = 1; deck1[A + lenght, B + 1] = 1;
                            deck1[A - 1, B] = 1; deck1[A - 1, B - 1] = 1; deck1[A - 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public int Setdeck1()
        {
            Console.Write("ВНИМАНИЕ!! Сейчас будет установка первой доски, не допускайте подглядывание 2 игрока.\nЕсли 2 игрок не наблюдает, напишите \"+\":");
            char temp = '+';
            string tk = ReadToken();
            if (tk.Length > 0) temp = tk[0];
            while (temp != '+')
            {
                string tk2 = ReadToken();
                if (tk2.Length > 0) temp = tk2[0];
            }
            int ship1 = 4; int ship2 = 3; int ship3 = 2; int ship4 = 1; int reboot = 0;
            int temp1;
            while (ship1 != 0 || ship2 != 0 || ship3 != 0 || ship4 != 0)
            {
                Console.Write("\n\nВыберите количество палуб корабля (1 - " + ship1 + " шт, 2 - " + ship2 + " шт, 3 - " + ship3 + " шт, 4 - " + ship4 + " шт) для расстановки : ");
                reboot++;
                if (reboot == 50)
                {
                    Console.Clear();
                    Console.Write("\n\nПроизошел сбой! Откат изменений...\n\n");
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            deck1[i, j] = 0;
                        }
                    }
                    ship1 = 0; ship2 = 0; ship3 = 0; ship4 = 0;
                    return 1;
                }
                string tk3 = ReadToken();
                if (int.TryParse(tk3, out temp1))
                {
                    switch (temp1)
                    {
                        case 1:
                            if (ship1 == 0)
                            {
                                Console.Write("Однопалубные корабли закончились!");
                                break;
                            }
                            ship1--;
                            Setshipdeck1(1);
                            break;
                        case 2:
                            if (ship2 == 0)
                            {
                                Console.Write("Двухпалубные корабли закончились!");
                                break;
                            }
                            ship2--;
                            Setshipdeck1(2);
                            break;
                        case 3:
                            if (ship3 == 0)
                            {
                                Console.Write("Трехпалубные корабли закончились!");
                                break;
                            }
                            ship3--;
                            Setshipdeck1(3);
                            break;
                        case 4:
                            if (ship4 == 0)
                            {
                                Console.Write("Четырехпалубные корабли закончились!");
                                break;
                            }
                            ship4--;
                            Setshipdeck1(4);
                            break;
                        default:
                            Console.WriteLine("Неверный ввод, попробуйте еще раз...");
                            break;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Итоговая доска 1:");
            Console.Write("\n\nНапишите \"+\" чтобы очистить консоль: ");
            string tk4 = ReadToken();
            if (tk4.Length > 0) temp = tk4[0];
            while (temp != '+')
            {
                string tk5 = ReadToken();
                if (tk5.Length > 0) temp = tk5[0];
            }
            Console.Clear();
            return 0;
        }
        public virtual int Setshipdeck2(int lenght)
        {
            Console.Clear();
            bool temp = false;
            Console.WriteLine("\n\nПостановка " + lenght + "-палубного корабля на доску 2\n");
            int temp1 = 0; char temp2 = 'А'; bool temp3 = false; bool temp4 = false; int reboot = 0;
            int A = 0, B = 0;
            while (!temp)
            {
                while (!temp3)
                {
                    reboot++;
                    if (reboot == 10)
                    {
                        Console.Write("Произошел сбой! Откат изменений...");
                        temp3 = true;
                        temp = true;
                        break;
                    }
                    Console.Write("Выберите позицию хвоста корабля (цифру от 1 до 10 и заглавную английскую букву от " + symbols[0] + " до " + symbols[9] + " слитно(1A, 2B)): ");
                    ReadStringWithDigitsSplit(out A, out temp2);
                    B = (int)temp2 - symbolssum;
                    if (A >= 1 && A <= 10 && B >= 1 && B <= 10 && deck2[A, B] == 0)
                        temp3 = true;
                    else
                        Console.WriteLine("\nПрограмма не смогла определить позицию хвоста или в этой позиции нельзя установить корабль! Попробуйте еще раз\n");
                }
                if (lenght == 1)
                {
                    Console.WriteLine("Позиция корабля " + A + temp2);
                    deck2[A, B] = 2; deck2[A - 1, B] = 1; deck2[A + 1, B] = 1;
                    deck2[A, B - 1] = 1; deck2[A - 1, B - 1] = 1; deck2[A + 1, B - 1] = 1;
                    deck2[A, B + 1] = 1; deck2[A + 1, B + 1] = 1; deck2[A - 1, B + 1] = 1;
                    temp = true;
                    temp3 = true;
                    break;
                }
                Console.WriteLine("Позиция хвоста " + A + temp2);
                reboot = 0;
                temp3 = false;
                while (!temp3)
                {
                    reboot++;
                    if (reboot == 10)
                    {
                        Console.Write("Произошел сбой! Откат изменений...");
                        temp3 = true;
                        temp = true;
                        break;
                    }
                    Console.Write("Выберите направление корабля\n1 - влево\n2 - вверх\n3 - вправо\n4 - вниз\nВыбор: ");
                    string tk = ReadToken();
                    if (int.TryParse(tk, out temp1))
                    {
                        while (temp1 < 1 || temp1 > 4)
                        {
                            Console.Write("Неккоректный ввод, еще раз: ");
                            string tk2 = ReadToken();
                            int.TryParse(tk2, out temp1);
                        }
                    }
                    switch (temp1)
                    {
                        case 1:
                            temp4 = false;
                            if ((B - lenght + 1) > 0)
                            {
                                for (int i = B - lenght + 1; i < B; i++)
                                {
                                    if (deck2[A, i] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((B - lenght + 1) < 1 || temp4 == true)
                            {
                                Console.WriteLine("Нельзя поставить корабль влево, выберите другое направление");
                                break;
                            }
                            Console.WriteLine("\nНачальная и конечная позиция корабля " + A + (char)(B + symbolssum - lenght + 1) + " - " + A + (char)(B + symbolssum) + "\nВыполняется постановка...");
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A, B - i] = 2;
                                deck2[A - 1, B - i] = 1;
                                deck2[A + 1, B - i] = 1;
                            }
                            deck2[A, B - lenght] = 1; deck2[A - 1, B - lenght] = 1; deck2[A + 1, B - lenght] = 1;
                            deck2[A, B + 1] = 1; deck2[A + 1, B + 1] = 1; deck2[A - 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 2:
                            temp4 = false;
                            if ((A - lenght + 1) > 0)
                            {
                                for (int i = A - lenght + 1; i < A; i++)
                                {
                                    if (deck2[i, B] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((A - lenght + 1) < 1 || temp4 == true)
                            {
                                Console.WriteLine("Нельзя поставить корабль вверх, выберите другое направление");
                                break;
                            }
                            Console.WriteLine("\nНачальная и конечная позиция корабля " + (A - lenght + 1) + (char)(B + symbolssum) + " - " + A + (char)(B + symbolssum) + "\nВыполняется постановка...");
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A - i, B] = 2;
                                deck2[A - i, B - 1] = 1;
                                deck2[A - i, B + 1] = 1;
                            }
                            deck2[A - lenght, B] = 1; deck2[A - lenght, B - 1] = 1; deck2[A - lenght, B + 1] = 1;
                            deck2[A + 1, B] = 1; deck2[A + 1, B - 1] = 1; deck2[A + 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 3:
                            temp4 = false;
                            if ((B + lenght - 1) < 11)
                            {
                                for (int i = B; i < B + lenght - 1; i++)
                                {
                                    if (deck2[A, i] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((B + lenght - 1) > 10 || temp4 == true)
                            {
                                Console.WriteLine("Нельзя поставить корабль вправо, выберите другое направление");
                                break;
                            }
                            Console.WriteLine("\nНачальная и конечная позиция корабля " + A + (char)(B + symbolssum) + " - " + A + (char)(B + symbolssum + lenght - 1) + "\nВыполняется постановка...");
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A, B + i] = 2;
                                deck2[A - 1, B + i] = 1;
                                deck2[A + 1, B + i] = 1;
                            }
                            deck2[A, B + lenght] = 1; deck2[A - 1, B + lenght] = 1; deck2[A + 1, B + lenght] = 1;
                            deck2[A, B - 1] = 1; deck2[A + 1, B - 1] = 1; deck2[A - 1, B - 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 4:
                            temp4 = false;
                            if ((A + lenght - 1) < 11)
                            {
                                for (int i = A; i < A + lenght - 1; i++)
                                {
                                    if (deck2[i, B] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((A + lenght - 1) > 10 || temp4 == true)
                            {
                                Console.WriteLine("Нельзя поставить корабль вниз, выберите другое направление");
                                break;
                            }
                            Console.WriteLine("\nНачальная и конечная позиция корабля " + A + (char)(B + symbolssum) + " - " + (A + lenght - 1) + (char)(B + symbolssum) + "\nВыполняется постановка...");
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A + i, B] = 2;
                                deck2[A + i, B - 1] = 1;
                                deck2[A + i, B + 1] = 1;
                            }
                            deck2[A + lenght, B] = 1; deck2[A + lenght, B - 1] = 1; deck2[A + lenght, B + 1] = 1;
                            deck2[A - 1, B] = 1; deck2[A - 1, B - 1] = 1; deck2[A - 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            return 0;
        }
        public virtual int Setdeck2()
        {
            Console.Write("ВНИМАНИЕ!! Сейчас будет установка второй доски, не допускайте подглядывание 1 игрока.\nЕсли 1 игрок не наблюдает, напишите \"+\":");
            char temp = '+';
            string tk = ReadToken();
            if (tk.Length > 0) temp = tk[0];
            while (temp != '+')
            {
                string tk2 = ReadToken();
                if (tk2.Length > 0) temp = tk2[0];
            }
            int ship1 = 4; int ship2 = 3; int ship3 = 2; int ship4 = 1; int reboot = 0;
            int temp1;
            while (ship1 != 0 || ship2 != 0 || ship3 != 0 || ship4 != 0)
            {
                Console.Write("\n\nВыберите количество палуб корабля (1 - " + ship1 + " шт, 2 - " + ship2 + " шт, 3 - " + ship3 + " шт, 4 - " + ship4 + " шт) для расстановки : ");
                reboot++;
                if (reboot == 50)
                {
                    Console.Clear();
                    Console.Write("\n\nПроизошел сбой! Откат изменений...\n\n");
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            deck2[i, j] = 0;
                        }
                    }
                    ship1 = 0; ship2 = 0; ship3 = 0; ship4 = 0;
                    return 1;
                }
                string tk3 = ReadToken();
                if (int.TryParse(tk3, out temp1))
                {
                    switch (temp1)
                    {
                        case 1:
                            if (ship1 == 0)
                            {
                                Console.Write("Однопалубные корабли закончились!");
                                break;
                            }
                            ship1--;
                            Setshipdeck2(1);
                            break;
                        case 2:
                            if (ship2 == 0)
                            {
                                Console.Write("Двухпалубные корабли закончились!");
                                break;
                            }
                            ship2--;
                            Setshipdeck2(2);
                            break;
                        case 3:
                            if (ship3 == 0)
                            {
                                Console.Write("Трехпалубные корабли закончились!");
                                break;
                            }
                            ship3--;
                            Setshipdeck2(3);
                            break;
                        case 4:
                            if (ship4 == 0)
                            {
                                Console.Write("Четырехпалубные корабли закончились!");
                                break;
                            }
                            ship4--;
                            Setshipdeck2(4);
                            break;
                        default:
                            Console.WriteLine("Неверный ввод, попробуйте еще раз...");
                            break;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Итоговая доска 2:");
            Console.Write("\n\nНапишите \"+\" чтобы очистить консоль: ");
            string tk4 = ReadToken();
            if (tk4.Length > 0) temp = tk4[0];
            while (temp != '+')
            {
                string tk5 = ReadToken();
                if (tk5.Length > 0) temp = tk5[0];
            }
            Console.Clear();
            return 0;
        }
        public int Setshipdeck1auto(int lenght)
        {
            bool temp = false;
            int temp1 = 0;
            bool temp3 = false;
            bool temp4 = false;
            int reboot = 0;
            int A = 0, B = 0;
            while (!temp)
            {
                while (!temp3)
                {
                    A = rand.Next(1, 11);
                    B = rand.Next(1, 11);
                    if (A >= 1 && A <= 10 && B >= 1 && B <= 10 && deck1[A, B] == 0)
                        temp3 = true;
                }
                if (lenght == 1)
                {
                    deck1[A, B] = 2; deck1[A - 1, B] = 1; deck1[A + 1, B] = 1;
                    deck1[A, B - 1] = 1; deck1[A - 1, B - 1] = 1; deck1[A + 1, B - 1] = 1;
                    deck1[A, B + 1] = 1; deck1[A + 1, B + 1] = 1; deck1[A - 1, B + 1] = 1;
                    temp = true;
                    temp3 = true;
                    break;
                }
                reboot = 0;
                temp3 = false;
                while (!temp3)
                {
                    reboot++;
                    if (reboot == 50)
                    {
                        Setshipdeck1auto(lenght);
                        return 0;
                    }
                    temp1 = rand.Next(1, 5);
                    if (A >= 1 && A <= 10 && B >= 1 && B <= 10)
                    {
                        switch (temp1)
                        {
                            case 1:
                                temp4 = false;
                                if ((B - lenght + 1) > 0)
                                {
                                    for (int i = B - lenght + 1; i < B; i++)
                                    {
                                        if (deck1[A, i] != 0)
                                            temp4 = true;
                                    }
                                }
                                if ((B - lenght + 1) < 1 || temp4 == true)
                                {
                                    break;
                                }
                                for (int i = 0; i < lenght; i++)
                                {
                                    deck1[A, B - i] = 2;
                                    deck1[A - 1, B - i] = 1;
                                    deck1[A + 1, B - i] = 1;
                                }
                                deck1[A, B - lenght] = 1; deck1[A - 1, B - lenght] = 1; deck1[A + 1, B - lenght] = 1;
                                deck1[A, B + 1] = 1; deck1[A + 1, B + 1] = 1; deck1[A - 1, B + 1] = 1;
                                temp = true;
                                temp3 = true;
                                break;
                            case 2:
                                temp4 = false;
                                if ((A - lenght + 1) > 0)
                                {
                                    for (int i = A - lenght + 1; i < A; i++)
                                    {
                                        if (deck1[i, B] != 0)
                                            temp4 = true;
                                    }
                                }
                                if ((A - lenght + 1) < 1 || temp4 == true)
                                {
                                    break;
                                }
                                for (int i = 0; i < lenght; i++)
                                {
                                    deck1[A - i, B] = 2;
                                    deck1[A - i, B - 1] = 1;
                                    deck1[A - i, B + 1] = 1;
                                }
                                deck1[A - lenght, B] = 1; deck1[A - lenght, B - 1] = 1; deck1[A - lenght, B + 1] = 1;
                                deck1[A + 1, B] = 1; deck1[A + 1, B - 1] = 1; deck1[A + 1, B + 1] = 1;
                                temp = true;
                                temp3 = true;
                                break;
                            case 3:
                                temp4 = false;
                                if (B + lenght - 1 < 11)
                                {
                                    for (int i = B; i < B + lenght; i++)
                                    {
                                        if (deck1[A, i] != 0)
                                            temp4 = true;
                                    }
                                }
                                if ((B + lenght - 1) > 10 || temp4 == true)
                                {
                                    break;
                                }
                                for (int i = 0; i < lenght; i++)
                                {
                                    deck1[A, B + i] = 2;
                                    deck1[A - 1, B + i] = 1;
                                    deck1[A + 1, B + i] = 1;
                                }
                                for (int i = -1; i < 2; i++)
                                {
                                    deck1[A + i, B + lenght] = 1;
                                    deck1[A + i, B - 1] = 1;
                                }
                                temp = true;
                                temp3 = true;
                                break;
                            case 4:
                                temp4 = false;
                                if ((A + lenght - 1) < 11)
                                {
                                    for (int i = A; i < A + lenght - 1; i++)
                                    {
                                        if (deck1[i, B] != 0)
                                            temp4 = true;
                                    }
                                }
                                if ((A + lenght) > 11 || temp4 == true)
                                {
                                    break;
                                }
                                for (int i = 0; i < lenght; i++)
                                {
                                    deck1[A + i, B] = 2;
                                    deck1[A + i, B - 1] = 1;
                                    deck1[A + i, B + 1] = 1;
                                }
                                for (int i = -1; i < 2; i++)
                                {
                                    deck1[A + lenght, B + i] = 1;
                                    deck1[A - 1, B + i] = 1;
                                }
                                temp = true;
                                temp3 = true;
                                break;
                        }
                    }
                }
            }
            return 0;
        }
        public int Setdeck1auto()
        {
            int ship1 = 4; int ship2 = 3; int ship3 = 2; int ship4 = 1;
            int temp1;
            while (ship1 != 0 || ship2 != 0 || ship3 != 0 || ship4 != 0)
            {
                temp1 = rand.Next(1, 5);
                switch (temp1)
                {
                    case 1:
                        if (ship1 == 0) { break; }
                        ship1--;
                        Setshipdeck1auto(1);
                        break;
                    case 2:
                        if (ship2 == 0) { break; }
                        ship2--;
                        Setshipdeck1auto(2);
                        break;
                    case 3:
                        if (ship3 == 0) { break; }
                        ship3--;
                        Setshipdeck1auto(3);
                        break;
                    case 4:
                        if (ship4 == 0) { break; }
                        ship4--;
                        Setshipdeck1auto(4);
                        break;
                }
            }
            return 0;
        }
        public static void ParseInput(string input, out int a, out int b)
        {
            a = 0;
            b = 0;

            if (string.IsNullOrEmpty(input)) return;

            string matchNumbers = Regex.Match(input, @"\d+").Value;
            string matchLetters = Regex.Match(input, @"[A-Za-z]").Value;

            if (int.TryParse(matchNumbers, out int parsedA))
            {
                a = parsedA;
            }

            if (!string.IsNullOrEmpty(matchLetters))
            {
                char letter = char.ToUpper(matchLetters[0]);
                b = letter - 'A' + 1;
            }
        }
        public int Setshipdeck2auto(int lenght)
        {
            bool temp = false;
            int temp1 = 0;
            bool temp3 = false;
            bool temp4 = false;
            int reboot = 0;
            int A = 0, B = 0;
            while (!temp)
            {
                while (!temp3)
                {
                    A = rand.Next(1, 11);
                    B = rand.Next(1, 11);
                    if (A >= 1 && A <= 10 && B >= 1 && B <= 10 && deck2[A, B] == 0)
                        temp3 = true;
                }
                if (lenght == 1)
                {
                    deck2[A, B] = 2; deck2[A - 1, B] = 1; deck2[A + 1, B] = 1;
                    deck2[A, B - 1] = 1; deck2[A - 1, B - 1] = 1; deck2[A + 1, B - 1] = 1;
                    deck2[A, B + 1] = 1; deck2[A + 1, B + 1] = 1; deck2[A - 1, B + 1] = 1;
                    temp = true;
                    temp3 = true;
                    break;
                }
                reboot = 0;
                temp3 = false;
                while (!temp3)
                {
                    reboot++;
                    if (reboot == 50)
                    {
                        Setshipdeck2auto(lenght);
                        Setshipdeck2auto(lenght);
                        return 0;
                    }
                    temp1 = rand.Next(1, 5);
                    switch (temp1)
                    {
                        case 1:
                            temp4 = false;
                            if ((B - lenght + 1) > 0)
                            {
                                for (int i = B - lenght + 1; i < B; i++)
                                {
                                    if (deck2[A, i] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((B - lenght + 1) < 1 || temp4 == true)
                            {
                                break;
                            }
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A, B - i] = 2;
                                deck2[A - 1, B - i] = 1;
                                deck2[A + 1, B - i] = 1;
                            }
                            deck2[A, B - lenght] = 1; deck2[A - 1, B - lenght] = 1; deck2[A + 1, B - lenght] = 1;
                            deck2[A, B + 1] = 1; deck2[A + 1, B + 1] = 1; deck2[A - 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 2:
                            temp4 = false;
                            if ((A - lenght + 1) > 0)
                            {
                                for (int i = A - lenght + 1; i < A; i++)
                                {
                                    if (deck2[i, B] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((A - lenght + 1) < 1 || temp4 == true)
                            {
                                break;
                            }
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A - i, B] = 2;
                                deck2[A - i, B - 1] = 1;
                                deck2[A - i, B + 1] = 1;
                            }
                            deck2[A - lenght, B] = 1; deck2[A - lenght, B - 1] = 1; deck2[A - lenght, B + 1] = 1;
                            deck2[A + 1, B] = 1; deck2[A + 1, B - 1] = 1; deck2[A + 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 3:
                            temp4 = false;
                            if (B + lenght - 1 < 11)
                            {
                                for (int i = B; i < B + lenght; i++)
                                {
                                    if (deck2[A, i] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((B + lenght - 1) > 10 || temp4 == true)
                            {
                                break;
                            }
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A, B + i] = 2;
                                deck2[A - 1, B + i] = 1;
                                deck2[A + 1, B + i] = 1;
                            }
                            for (int i = -1; i < 2; i++)
                            {
                                deck2[A + i, B + lenght] = 1;
                                deck2[A + i, B - 1] = 1;
                            }
                            temp = true;
                            temp3 = true;
                            break;
                        case 4:
                            temp4 = false;
                            if ((A + lenght - 1) < 11)
                            {
                                for (int i = A; i < A + lenght - 1; i++)
                                {
                                    if (deck2[i, B] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((A + lenght) > 11 || temp4 == true)
                            {
                                break;
                            }
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A + i, B] = 2;
                                deck2[A + i, B - 1] = 1;
                                deck2[A + i, B + 1] = 1;
                            }
                            for (int i = -1; i < 2; i++)
                            {
                                deck2[A + lenght, B + i] = 1;
                                deck2[A - 1, B + i] = 1;
                            }
                            temp = true;
                            temp3 = true;
                            break;
                    }
                }
            }
            return 0;
        }
        public int Setdeck2auto()
        {
            int ship1 = 4; int ship2 = 3; int ship3 = 2; int ship4 = 1;
            int temp1;
            while (ship1 != 0 || ship2 != 0 || ship3 != 0 || ship4 != 0)
            {
                temp1 = rand.Next(1, 5);
                switch (temp1)
                {
                    case 1:
                        if (ship1 == 0) { break; }
                        ship1--;
                        Setshipdeck2auto(1);
                        break;
                    case 2:
                        if (ship2 == 0) { break; }
                        ship2--;
                        Setshipdeck2auto(2);
                        break;
                    case 3:
                        if (ship3 == 0) { break; }
                        ship3--;
                        Setshipdeck2auto(3);
                        break;
                    case 4:
                        if (ship4 == 0) { break; }
                        ship4--;
                        Setshipdeck2auto(4);
                        break;
                }
            }
            return 0;
        }
        public virtual void Kill()
        {
            Console.Clear();
            Console.Write("\n\nУбит!");
        }
        public bool Checkbot(bool C)
        {
            int temp1 = 2; int temp2 = 2; int temp3 = 2; int temp4 = 2; bool temp = false;
            int ship1 = 0; int ship2 = 0; int ship3 = 0; int ship4 = 0;
            int[,] Checkdeck = new int[12, 12];
            if (C == true)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        Checkdeck[i, j] = deck1[i, j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        Checkdeck[i, j] = deck2[i, j];
                    }
                }
            }
            for (int A = 1; A < 11; A++)
            {
                for (int B = 1; B < 11; B++)
                {
                    temp4 = 2; temp3 = 2;
                    if (Checkdeck[A, B] == 2)
                    {
                        if (Checkdeck[A + 1, B] == 2) temp4 = 1;
                        if (Checkdeck[A, B + 1] == 2) temp3 = 1;
                        if (temp1 != 1 && temp2 != 1 && temp3 != 1 && temp4 != 1)
                        {
                            ship1++;
                            Checkdeck[A, B] = 1;
                        }
                        if (temp3 == 1)
                        {
                            if (Checkdeck[A, B + 2] == 2)
                            {
                                if (Checkdeck[A, B + 3] == 2)
                                {
                                    Checkdeck[A, B + 3] = 1;
                                    ship4++;
                                }
                                Checkdeck[A, B + 2] = 1;
                                ship3++;
                            }
                            Checkdeck[A, B + 1] = 1;
                            Checkdeck[A, B] = 1;
                            ship2++;
                        }
                        if (temp4 == 1)
                        {
                            if (Checkdeck[A + 2, B] == 2)
                            {
                                if (Checkdeck[A + 3, B] == 2)
                                {
                                    Checkdeck[A + 3, B] = 1;
                                    ship4++;
                                }
                                Checkdeck[A + 2, B] = 1;
                                ship3++;
                            }
                            Checkdeck[A + 1, B] = 1;
                            Checkdeck[A, B] = 1;
                            ship2++;
                        }
                    }
                }
            }
            if (ship1 == 4 && ship2 == 3 && ship3 == 2 && ship4 == 1) return true;
            else return false;
        }
        public virtual int Check(int A, int B)
        {
            Console.WriteLine("\nВыбранная позиция для удара " + A + (char)(B + symbolssum));
            int temp1 = 2; int temp2 = 2; int temp3 = 2; int temp4 = 2;
            int tempA = A; int tempB = B;
            bool still_alive = false;

            if (status1 == 1 || status1 == 2 || status2 == 0)
            {
                if (deck2[A, B] == 0 || deck2[A, B] == 1)
                {
                    deck2[A, B] = 3;
                    Console.Clear();
                    Console.WriteLine("\n\nПромах!");
                    status1 = 0; status2 = 1;
                    return 0;
                }
                else if (deck2[A, B] == 2)
                {
                    deck2[A, B] = 4;
                    status1 = 2; status2 = 0;

                    if (deck2[A, B - 1] == 2 || deck2[A, B - 1] == 4) temp1 = 0;
                    if (deck2[A - 1, B] == 2 || deck2[A - 1, B] == 4) temp2 = 0;
                    if (deck2[A, B + 1] == 2 || deck2[A, B + 1] == 4) temp3 = 0;
                    if (deck2[A + 1, B] == 2 || deck2[A + 1, B] == 4) temp4 = 0;

                    if (temp1 == 0)
                    {
                        if (deck2[A, B - 2] == 2 || deck2[A, B - 2] == 4) temp1 = 2;
                        if (temp1 == 2)
                            if (deck2[A, B - 3] == 2 || deck2[A, B - 2] == 2 || deck2[A, B] == 2 || deck2[A, B - 1] == 2) still_alive = true;
                        if (temp1 == 0)
                            if (deck2[A, B - 1] == 2 || deck2[A, B] == 2) still_alive = true;
                    }
                    if (temp3 == 0)
                    {
                        if (deck2[A, B + 2] == 2 || deck2[A, B + 2] == 4) temp3 = 2;
                        if (temp3 == 2)
                            if (deck2[A, B + 3] == 2 || deck2[A, B + 2] == 2 || deck2[A, B] == 2 || deck2[A, B + 1] == 2) still_alive = true;
                        if (temp3 == 0)
                            if (deck2[A, B + 1] == 2 || deck2[A, B] == 2) still_alive = true;
                    }
                    if (temp2 == 0)
                    {
                        if (deck2[A - 2, B] == 2 || deck2[A - 2, B] == 4) temp2 = 2;
                        if (temp2 == 2)
                            if (deck2[A - 3, B] == 2 || deck2[A - 2, B] == 2 || deck2[A, B] == 2 || deck2[A - 1, B] == 2) still_alive = true;
                        if (temp2 == 0)
                            if (deck2[A - 1, B] == 2 || deck2[A, B] == 2) still_alive = true;
                    }
                    if (temp4 == 0)
                    {
                        if (deck2[A + 2, B] == 2 || deck2[A + 2, B] == 4) temp4 = 2;
                        if (temp4 == 2)
                            if (deck2[A + 3, B] == 2 || deck2[A + 2, B] == 2 || deck2[A, B] == 2 || deck2[A + 1, B] == 2) still_alive = true;
                        if (temp4 == 0)
                            if (deck2[A + 1, B] == 2 || deck2[A, B] == 2) still_alive = true;
                    }

                    if (still_alive)
                    {
                        Console.Clear();
                        Console.WriteLine("\nПопал!");
                    }
                    else
                    {
                        if (deck2[A + 1, B] == 4) temp4 = 1;
                        if (deck2[A - 1, B] == 4) temp2 = 1;
                        if (deck2[A, B - 1] == 4) temp1 = 1;
                        if (deck2[A, B + 1] == 4) temp3 = 1;

                        if (temp1 != 1 && temp2 != 1 && temp3 != 1 && temp4 != 1)
                        {
                            deck2[A - 1, B] = 5; deck2[A + 1, B] = 5; deck2[A, B + 1] = 5; deck2[A, B - 1] = 5;
                            deck2[A - 1, B - 1] = 5; deck2[A + 1, B - 1] = 5; deck2[A - 1, B + 1] = 5; deck2[A + 1, B + 1] = 5;
                            Kill();
                        }
                        if (temp1 == 1 && temp3 == 1)
                        {
                            if (deck2[A, B - 2] == 4)
                            {
                                deck2[A, B - 3] = 5; deck2[A, B + 2] = 5;
                                for (int i = B - 3; i < B + 3; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                            else if (deck2[A, B + 2] == 4)
                            {
                                deck2[A, B + 3] = 5; deck2[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 4; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                            else
                            {
                                deck2[A, B + 2] = 5; deck2[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 3; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                        }
                        if (temp2 == 1 && temp4 == 1)
                        {
                            if (deck2[A - 2, B] == 4)
                            {
                                deck2[A - 3, B] = 5; deck2[A + 2, B] = 5;
                                for (int i = A - 3; i < A + 3; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                return 2;
                            }
                            else if (deck2[A + 2, B] == 4)
                            {
                                deck2[A + 3, B] = 5; deck2[A - 2, B] = 5;
                                for (int i = A - 2; i < A + 4; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                return 2;
                            }
                            else
                            {
                                deck2[A + 2, B] = 5; deck2[A - 2, B] = 5;
                                for (int i = A - 2; i < A + 3; i++) { deck2[i, B + 1] = 5; deck2[i, B - 1] = 5; }
                                return 2;
                            }
                        }
                        if (temp1 == 1)
                        {
                            if (deck2[A, B - 2] == 4)
                            {
                                if (deck2[A, B - 3] == 4)
                                {
                                    deck2[A, B + 1] = 5; deck2[A, B - 4] = 5;
                                    for (int i = B - 4; i < B + 2; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                    return 2;
                                }
                                deck2[A, B + 1] = 5; deck2[A, B - 3] = 5;
                                for (int i = B - 3; i < B + 2; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                            deck2[A, B + 1] = 5; deck2[A, B - 2] = 5;
                            for (int i = B - 2; i < B + 2; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                            return 2;
                        }
                        if (temp3 == 1)
                        {
                            if (deck2[A, B + 2] == 4)
                            {
                                if (deck2[A, B + 3] == 4)
                                {
                                    deck2[A, B - 1] = 5; deck2[A, B + 4] = 5;
                                    for (int i = B - 1; i < B + 5; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                    return 2;
                                }
                                deck2[A, B - 1] = 5; deck2[A, B + 3] = 5;
                                for (int i = B - 1; i < B + 4; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                            deck2[A, B - 1] = 5; deck2[A, B + 2] = 5;
                            for (int i = B - 1; i < B + 3; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                            return 2;
                        }
                        if (temp2 == 1)
                        {
                            if (deck2[A - 2, B] == 4)
                            {
                                if (deck2[A - 3, B] == 4)
                                {
                                    deck2[A + 1, B] = 5; deck2[A - 4, B] = 5;
                                    for (int i = A - 4; i < A + 2; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                    return 2;
                                }
                                deck2[A + 1, B] = 5; deck2[A - 3, B] = 5;
                                for (int i = A - 3; i < A + 2; i++) { deck2[i, B + 1] = 5; deck2[i, B - 1] = 5; }
                                return 2;
                            }
                            deck2[A + 1, B] = 5; deck2[A - 2, B] = 5;
                            for (int i = A - 2; i < A + 2; i++) { deck2[i, B + 1] = 5; deck2[i, B - 1] = 5; }
                            return 2;
                        }
                        if (temp4 == 1)
                        {
                            if (deck2[A + 2, B] == 4)
                            {
                                if (deck2[A + 3, B] == 4)
                                {
                                    deck2[A - 1, B] = 5; deck2[A + 4, B] = 5;
                                    for (int i = A - 1; i < A + 5; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                    return 2;
                                }
                                deck2[A - 1, B] = 5; deck2[A + 3, B] = 5;
                                for (int i = A - 1; i < A + 4; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                return 2;
                            }
                            deck2[A - 1, B] = 5; deck2[A + 2, B] = 5;
                            for (int i = A - 1; i < A + 3; i++) { deck2[i, B + 1] = 5; deck2[i, B - 1] = 5; }
                            return 2;
                        }
                    }
                }
                return 0;
            }
            else if (status2 == 1 || status2 == 2 || status1 == 0)
            {
                if (deck1[A, B] == 0 || deck1[A, B] == 1)
                {
                    deck1[A, B] = 3;
                    Console.Clear();
                    Console.WriteLine("\n\nПромах!");
                    status2 = 0; status1 = 1;
                    return 0;
                }
                else if (deck1[A, B] == 2)
                {
                    deck1[A, B] = 4;
                    status2 = 2; status1 = 0;

                    if (deck1[A, B - 1] == 2 || deck1[A, B - 1] == 4) temp1 = 0;
                    if (deck1[A - 1, B] == 2 || deck1[A - 1, B] == 4) temp2 = 0;
                    if (deck1[A, B + 1] == 2 || deck1[A, B + 1] == 4) temp3 = 0;
                    if (deck1[A + 1, B] == 2 || deck1[A + 1, B] == 4) temp4 = 0;

                    if (temp1 == 0)
                    {
                        if (deck1[A, B - 2] == 2 || deck1[A, B - 2] == 4) temp1 = 2;
                        if (temp1 == 2)
                            if (deck1[A, B - 3] == 2 || deck1[A, B - 2] == 2 || deck1[A, B] == 2 || deck1[A, B - 1] == 2) still_alive = true;
                        if (temp1 == 0)
                            if (deck1[A, B - 1] == 2 || deck1[A, B] == 2) still_alive = true;
                    }
                    if (temp3 == 0)
                    {
                        if (deck1[A, B + 2] == 2 || deck1[A, B + 2] == 4) temp3 = 2;
                        if (temp3 == 2)
                            if (deck1[A, B + 3] == 2 || deck1[A, B + 2] == 2 || deck1[A, B] == 2 || deck1[A, B + 1] == 2) still_alive = true;
                        if (temp3 == 0)
                            if (deck1[A, B + 1] == 2 || deck1[A, B] == 2) still_alive = true;
                    }
                    if (temp2 == 0)
                    {
                        if (deck1[A - 2, B] == 2 || deck1[A - 2, B] == 4) temp2 = 2;
                        if (temp2 == 2)
                            if (deck1[A - 3, B] == 2 || deck1[A - 2, B] == 2 || deck1[A, B] == 2 || deck1[A - 1, B] == 2) still_alive = true;
                        if (temp2 == 0)
                            if (deck1[A - 1, B] == 2 || deck1[A, B] == 2) still_alive = true;
                    }
                    if (temp4 == 0)
                    {
                        if (deck1[A + 2, B] == 2 || deck1[A + 2, B] == 4) temp4 = 2;
                        if (temp4 == 2)
                            if (deck1[A + 3, B] == 2 || deck1[A + 2, B] == 2 || deck1[A, B] == 2 || deck1[A + 1, B] == 2) still_alive = true;
                        if (temp4 == 0)
                            if (deck1[A + 1, B] == 2 || deck1[A, B] == 2) still_alive = true;
                    }

                    if (still_alive)
                    {
                        Console.Clear();
                        Console.WriteLine("\nПопал!");
                    }
                    else
                    {
                        if (deck1[A + 1, B] == 4) temp4 = 1;
                        if (deck1[A - 1, B] == 4) temp2 = 1;
                        if (deck1[A, B - 1] == 4) temp1 = 1;
                        if (deck1[A, B + 1] == 4) temp3 = 1;

                        if (temp1 != 1 && temp2 != 1 && temp3 != 1 && temp4 != 1)
                        {
                            deck1[A - 1, B] = 5; deck1[A + 1, B] = 5; deck1[A, B + 1] = 5; deck1[A, B - 1] = 5;
                            deck1[A - 1, B - 1] = 5; deck1[A + 1, B - 1] = 5; deck1[A - 1, B + 1] = 5; deck1[A + 1, B + 1] = 5;
                            Kill();
                        }
                        if (temp1 == 1 && temp3 == 1)
                        {
                            if (deck1[A, B - 2] == 4)
                            {
                                deck1[A, B - 3] = 5; deck1[A, B + 2] = 5;
                                for (int i = B - 3; i < B + 3; i++) { deck1[A - 1, i] = 5; deck1[A + 1, i] = 5; }
                                return 2;
                            }
                            else if (deck1[A, B + 2] == 4)
                            {
                                deck1[A, B + 3] = 5; deck1[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 4; i++) { deck1[A - 1, i] = 5; deck1[A + 1, i] = 5; }
                                return 2;
                            }
                            else
                            {
                                deck1[A, B + 2] = 5; deck1[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 3; i++) { deck1[A - 1, i] = 5; deck1[A + 1, i] = 5; }
                                return 2;
                            }
                        }
                        if (temp2 == 1 && temp4 == 1)
                        {
                            if (deck1[A - 2, B] == 4)
                            {
                                deck1[A - 3, B] = 5; deck1[A + 2, B] = 5;
                                for (int i = A - 3; i < A + 3; i++) { deck1[i, B - 1] = 5; deck1[i, B + 1] = 5; }
                                return 2;
                            }
                            else if (deck1[A + 2, B] == 4)
                            {
                                deck1[A + 3, B] = 5; deck1[A - 2, B] = 5;
                                for (int i = A - 2; i < A + 4; i++) { deck1[i, B - 1] = 5; deck1[i, B + 1] = 5; }
                                return 2;
                            }
                            else
                            {
                                deck1[A + 2, B] = 5; deck1[A - 2, B] = 5;
                                for (int i = B - 2; i < B + 3; i++) { deck1[i, B + 1] = 5; deck1[i, B - 1] = 5; }
                                return 2;
                            }
                        }
                        if (temp1 == 1)
                        {
                            if (deck1[A, B - 2] == 4)
                            {
                                if (deck1[A, B - 3] == 4)
                                {
                                    deck1[A, B + 1] = 5; deck1[A, B - 4] = 5;
                                    for (int i = B - 4; i < B + 2; i++) { deck1[A - 1, i] = 5; deck1[A + 1, i] = 5; }
                                    return 2;
                                }
                                deck1[A, B + 1] = 5; deck1[A, B - 3] = 5;
                                for (int i = B - 3; i < B + 2; i++) { deck1[A - 1, i] = 5; deck1[A + 1, i] = 5; }
                                return 2;
                            }
                            deck1[A, B + 1] = 5; deck1[A, B - 2] = 5;
                            for (int i = B - 2; i < B + 2; i++) { deck1[A - 1, i] = 5; deck1[A + 1, i] = 5; }
                            return 2;
                        }
                        if (temp3 == 1)
                        {
                            if (deck1[A, B + 2] == 4)
                            {
                                if (deck1[A, B + 3] == 4)
                                {
                                    deck1[A, B - 1] = 5; deck1[A, B + 4] = 5;
                                    for (int i = B - 1; i < B + 5; i++) { deck1[A - 1, i] = 5; deck1[A + 1, i] = 5; }
                                    return 2;
                                }
                                deck1[A, B - 1] = 5; deck1[A, B + 3] = 5;
                                for (int i = B - 1; i < B + 4; i++) { deck1[A - 1, i] = 5; deck1[A + 1, i] = 5; }
                                return 2;
                            }
                            deck1[A, B - 1] = 5; deck1[A, B + 2] = 5;
                            for (int i = B - 1; i < B + 3; i++) { deck1[A - 1, i] = 5; deck1[A + 1, i] = 5; }
                            return 2;
                        }
                        if (temp2 == 1)
                        {
                            if (deck1[A - 2, B] == 4)
                            {
                                if (deck1[A - 3, B] == 4)
                                {
                                    deck1[A + 1, B] = 5; deck1[A - 4, B] = 5;
                                    for (int i = A - 4; i < A + 2; i++) { deck1[i, B - 1] = 5; deck1[i, B + 1] = 5; }
                                    return 2;
                                }
                                deck1[A + 1, B] = 5; deck1[A - 3, B] = 5;
                                for (int i = A - 3; i < A + 2; i++) { deck1[i, B + 1] = 5; deck1[i, B - 1] = 5; }
                                return 2;
                            }
                            deck1[A + 1, B] = 5; deck1[A - 2, B] = 5;
                            for (int i = A - 2; i < A + 2; i++) { deck1[i, B + 1] = 5; deck1[i, B - 1] = 5; }
                            return 2;
                        }
                        if (temp4 == 1)
                        {
                            if (deck1[A + 2, B] == 4)
                            {
                                if (deck1[A + 3, B] == 4)
                                {
                                    deck1[A - 1, B] = 5; deck1[A + 4, B] = 5;
                                    for (int i = A - 1; i < A + 5; i++) { deck1[i, B - 1] = 5; deck1[i, B + 1] = 5; }
                                    return 2;
                                }
                                deck1[A - 1, B] = 5; deck1[A + 3, B] = 5;
                                for (int i = A - 1; i < A + 4; i++) { deck1[i, B - 1] = 5; deck1[i, B + 1] = 5; }
                                return 2;
                            }
                            deck1[A - 1, B] = 5; deck1[A + 2, B] = 5;
                            for (int i = A - 1; i < A + 3; i++) { deck1[i, B + 1] = 5; deck1[i, B - 1] = 5; }
                            return 2;
                        }
                    }
                }
                return 0;
            }
            else
            {
                Console.WriteLine("Ошибка");
                return 0;
            }
        }
        public int Checkwin()
        {
            bool temp1 = false;
            bool temp2 = false;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (deck1[i, j] == 2)
                    {
                        temp1 = true;
                    }
                    if (deck2[i, j] == 2)
                    {
                        temp2 = true;
                    }
                }
            }
            if (temp1 && temp2) return 0;
            else if (!temp1) return 2;
            else if (!temp2) return 1;
            else return 0;
        }
        public virtual void Step(int row, int col)
        {
            bool temp3 = false;
            int temp1 = 0;
            char temp2 = '\0';
            int A = 11;
            int B = 11;
            if (status1 == 1 || status1 == 2 || status2 == 0)
            {
                Console.WriteLine("\n\nХод 1 игрока\n");
                temp3 = false;
                while (!temp3)
                {
                    Console.Write("Выберите позицию для удара (цифру от 1 до 10 и заглавную английскую букву от " + symbols[0] + " до " + symbols[9] + " (A1, B2) (0K для просмотра доск)): ");
                    
                    if (A == 0 && B == 11)
                    {
                        Checkdeck();
                    }
                    if (A >= 1 && A <= 10 && B >= 1 && B <= 10 && deck2[A, B] != 3 && deck2[A, B] != 4 && deck2[A, B] != 5)
                        temp3 = true;
                    else
                        Console.WriteLine("\nПрограмма не смогла определить позицию удара или в эту позицию нельзя ударить! Попробуйте еще раз\n");
                }
                Check(A, B);
            }
            else if (status2 == 1 || status2 == 2 || status1 == 0)
            {
                Console.WriteLine("\n\nХод 2 игрока\n");
                temp3 = false;
                while (!temp3)
                {
                    Console.Write("Выберите позицию для удара (цифру от 1 до 10 и заглавную английскую букву от " + symbols[0] + " до " + symbols[9] + " (A1, B2) (0K для просмотра доск)): ");
                    
                    if (A == 0 && B == 11)
                    {
                        Checkdeck();
                    }
                    if (A >= 1 && A <= 10 && B >= 1 && B <= 10 && deck1[A, B] != 3 && deck1[A, B] != 4 && deck1[A, B] != 5)
                        temp3 = true;
                    else
                        Console.WriteLine("\nПрограмма не смогла определить позицию удара или в эту позицию нельзя ударить! Попробуйте еще раз\n");
                }
                Check(A, B);
            }
            else
            {
                Console.WriteLine("Ошибка, ход 1 игрока.");
                status1 = 1;
                status2 = 0;
            }
        }
    }
    public class Botgame : Game
    {
        protected int botcordb;
        protected int botcorda;
        private Random rand = new Random();

        public Botgame()
        {
            password2 = "vanvonadonvsajnalgfnlajn5yg1tg1eg31134foangaojgfagojavnoaovodaijov dadv voiansovnaojnfoajofv ";
            status1 = 0;
            status2 = 0;
            for (int i = 0; i < 10; i++)
            {
                symbols[i] = (char)(i + symbolssum + 1);
            }
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    deck1[i, j] = 0;
                    deck2[i, j] = 0;
                }
            }
        }
        /*public override void Print2decks()
        {
            Console.WriteLine("_ - Пустое поле\nO - Промах или поле вокруг разбитого корабля\nX - попадание по кораблю\n");
            Console.WriteLine("\t\t1 Доска\t\t\t\t\t2 Доска");
            Console.Write("\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            Console.Write("\t\t\t");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(symbols[i] + " ");
            }
            for (int i = 1; i < 11; i++)
            {
                Console.Write("\n" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck1[i, j] == 0 || deck1[i, j] == 1)
                        Console.Write("_ ");
                    else if (deck1[i, j] == 3 || deck1[i, j] == 5)
                        Console.Write("O ");
                    else if (deck1[i, j] == 2)
                        Console.Write("x ");
                    else if (deck1[i, j] == 4)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
                Console.Write("\t\t" + i + "\t");
                for (int j = 1; j < 11; j++)
                {
                    if (deck2[i, j] == 0 || deck2[i, j] == 1 || deck2[i, j] == 2)
                        Console.Write("_ ");
                    else if (deck2[i, j] == 3 || deck2[i, j] == 5)
                        Console.Write("O ");
                    else if (deck2[i, j] == 4)
                        Console.Write("X ");
                    else
                        Console.Write("? ");
                }
            }
        }*/
        public override int Setshipdeck2(int lenght)
        {
            bool temp = false;
            int temp1 = 0;
            char temp2 = 'А';
            bool temp3 = false;
            bool temp4 = false;
            int reboot = 0;
            int A = 0, B = 0;
            while (!temp)
            {
                while (!temp3)
                {
                    reboot++;
                    if (reboot == 10)
                    {
                        temp3 = true;
                        temp = true;
                        break;
                    }
                    A = rand.Next(10) + 1;
                    B = rand.Next(10) + 1;
                    if (A >= 1 && A <= 10 && B >= 1 && B <= 10 && deck2[A, B] == 0)
                        temp3 = true;
                }
                if (lenght == 1)
                {
                    deck2[A, B] = 2;
                    deck2[A - 1, B] = 1;
                    deck2[A + 1, B] = 1;
                    deck2[A, B - 1] = 1;
                    deck2[A - 1, B - 1] = 1;
                    deck2[A + 1, B - 1] = 1;
                    deck2[A, B + 1] = 1;
                    deck2[A + 1, B + 1] = 1;
                    deck2[A - 1, B + 1] = 1;
                    temp = true;
                    temp3 = true;
                    break;
                }
                reboot = 0;
                temp3 = false;
                while (!temp3)
                {
                    reboot++;
                    if (reboot == 10)
                    {
                        temp3 = true;
                        temp = true;
                        break;
                    }
                    temp1 = rand.Next(4) + 1;
                    switch (temp1)
                    {
                        case 1:
                            temp4 = false;
                            if ((B - lenght + 1) > 0)
                            {
                                for (int i = B - lenght + 1; i < B; i++)
                                {
                                    if (deck2[A, i] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((B - lenght + 1) < 1 || temp4 == true)
                            {
                                break;
                            }
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A, B - i] = 2;
                                deck2[A - 1, B - i] = 1;
                                deck2[A + 1, B - i] = 1;
                            }
                            deck2[A, B - lenght] = 1;
                            deck2[A - 1, B - lenght] = 1;
                            deck2[A + 1, B - lenght] = 1;
                            deck2[A, B + 1] = 1;
                            deck2[A + 1, B + 1] = 1;
                            deck2[A - 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 2:
                            temp4 = false;
                            if ((A - lenght + 1) > 0)
                            {
                                for (int i = A - lenght + 1; i < A; i++)
                                {
                                    if (deck2[i, B] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((A - lenght + 1) < 1 || temp4 == true)
                            {
                                break;
                            }
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A - i, B] = 2;
                                deck2[A - i, B - 1] = 1;
                                deck2[A - i, B + 1] = 1;
                            }
                            deck2[A - lenght, B] = 1;
                            deck2[A - lenght, B - 1] = 1;
                            deck2[A - lenght, B + 1] = 1;
                            deck2[A + 1, B] = 1;
                            deck2[A + 1, B - 1] = 1;
                            deck2[A + 1, B + 1] = 1;
                            temp = true;
                            temp3 = true;
                            break;
                        case 3:
                            temp4 = false;
                            if ((B + lenght - 1) < 11)
                            {
                                for (int i = B; i < B + lenght; i++)
                                {
                                    if (deck2[A, i] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((B + lenght - 1) > 10 || temp4 == true)
                            {
                                break;
                            }
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A, B + i] = 2;
                                deck2[A - 1, B + i] = 1;
                                deck2[A + 1, B + i] = 1;
                            }
                            for (int i = -1; i < 2; i++)
                            {
                                deck2[A + i, B + lenght] = 1;
                                deck2[A + i, B - 1] = 1;
                            }
                            temp = true;
                            temp3 = true;
                            break;
                        case 4:
                            temp4 = false;
                            if ((A + lenght - 1) < 11)
                            {
                                for (int i = A; i < A + lenght - 1; i++)
                                {
                                    if (deck2[i, B] != 0)
                                        temp4 = true;
                                }
                            }
                            if ((A + lenght) > 11 || temp4 == true)
                            {
                                break;
                            }
                            for (int i = 0; i < lenght; i++)
                            {
                                deck2[A + i, B] = 2;
                                deck2[A + i, B - 1] = 1;
                                deck2[A + i, B + 1] = 1;
                            }
                            for (int i = -1; i < 2; i++)
                            {
                                deck2[A + lenght, B + i] = 1;
                                deck2[A - 1, B + i] = 1;
                            }
                            temp = true;
                            temp3 = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            return 0;
        }
        public override int Setdeck2()
        {
            Console.WriteLine("\nРасстановка кораблей роботом...\n\n");
            int ship1 = 4;
            int ship2 = 3;
            int ship3 = 2;
            int ship4 = 1;
            int reboot = 0;
            int temp1;
            while (ship1 != 0 || ship2 != 0 || ship3 != 0 || ship4 != 0)
            {
                temp1 = rand.Next(4) + 1;
                switch (temp1)
                {
                    case 1:
                        if (ship1 == 0)
                        {
                            break;
                        }
                        ship1--;
                        Setshipdeck2(1);
                        break;
                    case 2:
                        if (ship2 == 0)
                        {
                            break;
                        }
                        ship2--;
                        Setshipdeck2(2);
                        break;
                    case 3:
                        if (ship3 == 0)
                        {
                            break;
                        }
                        ship3--;
                        Setshipdeck2(3);
                        break;
                    case 4:
                        if (ship4 == 0)
                        {
                            break;
                        }
                        ship4--;
                        Setshipdeck2(4);
                        break;
                }
            }
            return 0;
        }
        /*public int check(int A, int B)
        {
            Console.WriteLine();
            Console.WriteLine("Выбранная позиция для удара " + A + (char)(B + symbolssum));
            int temp1 = 2; int temp2 = 2; int temp3 = 2; int temp4 = 2; int tempA = A;
            int tempB = B;
            if (status1 == 1 || status1 == 2 || status2 == 0)
            {
                if (!(A >= 1 && A <= 10 && B >= 1 && B <= 10))
                {
                    Console.WriteLine("\nНеверные координаты для удара");
                    return 0;
                }
                else if (deck2[A, B] == 3 || deck2[A, B] == 4 || deck2[A, B] == 5)
                {
                    Console.WriteLine("\nВ эту позицию нельзя ударить!");
                    return 0;
                }
                else if (deck2[A, B] == 0 || deck2[A, B] == 1)
                {
                    deck2[A, B] = 3;
                    Console.Clear();
                    Print2decks();
                    Console.Write("\nПромах!");
                    status1 = 0;
                    status2 = 1;
                    return 0;
                }
                else if (deck2[A, B] == 2)
                {
                    deck2[A, B] = 4;
                    status1 = 2;
                    status2 = 0;

                    bool still_alive = false;
                    if (deck2[A + 1, B] == 4 || deck2[A + 1, B] == 2)
                        temp4 = 0;
                    if (deck2[A - 1, B] == 4 || deck2[A - 1, B] == 2)
                        temp2 = 0;
                    if (deck2[A, B - 1] == 4 || deck2[A, B - 1] == 2)
                        temp1 = 0;
                    if (deck2[A, B + 1] == 4 || deck2[A, B + 1] == 2)
                        temp3 = 0;
                    if (temp1 == 0 && temp3 == 0)
                        if (deck2[A, B - 2] == 2 || deck2[A, B - 1] == 2 || deck2[A, B] == 2 || deck2[A, B + 1] == 2 || deck2[A, B + 2] == 2)
                            still_alive = true;
                    if (temp2 == 0 && temp4 == 0)
                        if (deck2[A - 2, B] == 2 || deck2[A - 1, B] == 2 || deck2[A, B] == 2 || deck2[A + 1, B] == 2 || deck2[A + 2, B] == 2)
                            still_alive = true;
                    if (temp1 == 0)
                    {
                        if (deck2[A, B - 2] == 2 || deck2[A, B - 2] == 4)
                            temp1 = 2;
                        if (temp1 == 2)
                            if (deck2[A, B - 3] == 2 || deck2[A, B - 2] == 2 || deck2[A, B - 1] == 2 || deck2[A, B] == 2)
                                still_alive = true;
                        if (temp1 == 0)
                            if (deck2[A, B - 1] == 2 || deck2[A, B] == 2)
                                still_alive = true;
                    }
                    if (temp3 == 0)
                    {
                        if (deck2[A, B + 2] == 2 || deck2[A, B + 2] == 4)
                            temp3 = 2;
                        if (temp3 == 2)
                            if (deck2[A, B + 3] == 2 || deck2[A, B + 2] == 2 || deck2[A, B + 1] == 2 || deck2[A, B] == 2)
                                still_alive = true;
                        if (temp3 == 0)
                            if (deck2[A, B] == 2 || deck2[A, B + 1] == 2)
                                still_alive = true;
                    }
                    if (temp2 == 0)
                    {
                        if (deck2[A - 2, B] == 2 || deck2[A - 2, B] == 4)
                            temp2 = 2;
                        if (temp2 == 2)
                            if (deck2[A - 3, B] == 2 || deck2[A - 2, B] == 2 || deck2[A, B] == 2 || deck2[A - 1, B] == 2)
                                still_alive = true;
                        if (temp2 == 0)
                            if (deck2[A - 1, B] == 2 || deck2[A, B] == 2)
                                still_alive = true;
                    }
                    if (temp4 == 0)
                    {
                        if (deck2[A + 2, B] == 2 || deck2[A + 2, B] == 4)
                            temp4 = 2;
                        if (temp4 == 2)
                            if (deck2[A + 3, B] == 2 || deck2[A + 2, B] == 2 || deck2[A, B] == 2 || deck2[A + 1, B] == 2)
                                still_alive = true;
                        if (temp4 == 0)
                            if (deck2[A + 1, B] == 2 || deck2[A, B] == 2)
                                still_alive = true;
                    }

                    if (still_alive)
                    {
                        Console.Clear();
                        Print2decks();
                        Console.Write("\nПопал!");
                    }
                    else
                    {
                        if (deck2[A + 1, B] == 4)
                            temp4 = 1;
                        if (deck2[A - 1, B] == 4)
                            temp2 = 1;
                        if (deck2[A, B - 1] == 4)
                            temp1 = 1;
                        if (deck2[A, B + 1] == 4)
                            temp3 = 1;
                        if (temp1 != 1 && temp2 != 1 && temp3 != 1 && temp4 != 1)
                        {
                            deck2[A - 1, B] = 5;
                            deck2[A + 1, B] = 5; deck2[A, B + 1] = 5; deck2[A, B - 1] = 5;
                            deck2[A - 1, B - 1] = 5; deck2[A + 1, B - 1] = 5;
                            deck2[A - 1, B + 1] = 5; deck2[A + 1, B + 1] = 5;
                            Kill();
                        }
                        if (temp1 == 1 && temp3 == 1)
                        {
                            if (deck2[A, B - 2] == 4)
                            {
                                deck2[A, B - 3] = 5; deck2[A, B + 2] = 5;
                                for (int i = B - 3; i < B + 3; i++)
                                {
                                    deck2[A - 1, i] = 5;
                                    deck2[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            else if (deck2[A, B + 2] == 4)
                            {
                                deck2[A, B + 3] = 5;
                                deck2[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 4; i++)
                                {
                                    deck2[A - 1, i] = 5;
                                    deck2[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            else
                            {
                                deck2[A, B + 2] = 5;
                                deck2[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 3; i++)
                                {
                                    deck2[A - 1, i] = 5;
                                    deck2[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                        }
                        if (temp2 == 1 && temp4 == 1)
                        {
                            if (deck2[A - 2, B] == 4)
                            {
                                deck2[A - 3, B] = 5;
                                deck2[A + 2, B] = 5;
                                for (int i = A - 3; i < A + 3; i++)
                                {
                                    deck2[i, B - 1] = 5;
                                    deck2[i, B + 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            else if (deck2[A + 2, B] == 4)
                            {
                                deck2[A + 3, B] = 5;
                                deck2[A - 2, B] = 5;
                                for (int i = A - 2; i < A + 4; i++)
                                {
                                    deck2[i, B - 1] = 5;
                                    deck2[i, B + 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            else
                            {
                                deck2[A + 2, B] = 5;
                                deck2[A - 2, B] = 5;
                                for (int i = B - 2; i < B + 3; i++)
                                {
                                    deck2[i, B + 1] = 5;
                                    deck2[i, B - 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                        }
                        if (temp1 == 1)
                        {
                            if (deck2[A, B - 2] == 4)
                            {
                                if (deck2[A, B - 3] == 4)
                                {
                                    deck2[A, B + 1] = 5;
                                    deck2[A, B - 4] = 5;
                                    for (int i = B - 4; i < B + 2; i++)
                                    {
                                        deck2[A - 1, i] = 5;
                                        deck2[A + 1, i] = 5;
                                    }
                                    Kill();
                                    return 0;
                                }
                                deck2[A, B + 1] = 5;
                                deck2[A, B - 3] = 5;
                                for (int i = B - 3; i < B + 2; i++)
                                {
                                    deck2[A - 1, i] = 5;
                                    deck2[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            deck2[A, B + 1] = 5;
                            deck2[A, B - 2] = 5;
                            for (int i = B - 2; i < B + 2; i++)
                            {
                                deck2[A - 1, i] = 5;
                                deck2[A + 1, i] = 5;
                            }
                            Kill();
                            return 0;
                        }
                        if (temp3 == 1)
                        {
                            if (deck2[A, B + 2] == 4)
                            {
                                if (deck2[A, B + 3] == 4)
                                {
                                    deck2[A, B - 1] = 5;
                                    deck2[A, B + 4] = 5;
                                    for (int i = B - 1; i < B + 5; i++)
                                    {
                                        deck2[A - 1, i] = 5;
                                        deck2[A + 1, i] = 5;
                                    }
                                    Kill();
                                    return 0;
                                }
                                deck2[A, B + 1] = 5;
                                deck2[A, B - 3] = 5;
                                for (int i = B - 1; i < B + 4; i++)
                                {
                                    deck2[A - 1, i] = 5;
                                    deck2[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            deck2[A, B + 1] = 5;
                            deck2[A, B - 2] = 5;
                            for (int i = B - 1; i < B + 3; i++)
                            {
                                deck2[A - 1, i] = 5;
                                deck2[A + 1, i] = 5;
                            }
                            Kill();
                            return 0;
                        }
                        if (temp2 == 1)
                        {
                            if (deck2[A - 2, B] == 4)
                            {
                                if (deck2[A - 3, B] == 4)
                                {
                                    deck2[A + 1, B] = 5;
                                    deck2[A - 4, B] = 5;
                                    for (int i = A - 4; i < A + 2; i++)
                                    {
                                        deck2[i, B - 1] = 5;
                                        deck2[i, B + 1] = 5;
                                    }
                                    Kill();
                                    return 0;
                                }
                                deck2[A + 1, B] = 5;
                                deck2[A - 3, B] = 5;
                                for (int i = A - 3; i < A + 2; i++)
                                {
                                    deck2[i, B + 1] = 5;
                                    deck2[i, B - 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            deck2[A + 1, B] = 5;
                            deck2[A - 2, B] = 5;
                            for (int i = A - 2; i < A + 2; i++)
                            {
                                deck2[i, B + 1] = 5;
                                deck2[i, B - 1] = 5;
                            }
                            Kill();
                            return 0;
                        }
                        if (temp4 == 1)
                        {
                            if (deck2[A + 2, B] == 4)
                            {
                                if (deck2[A + 3, B] == 4)
                                {
                                    deck2[A - 1, B] = 5;
                                    deck2[A + 4, B] = 5;
                                    for (int i = A - 1; i < A + 5; i++)
                                    {
                                        deck2[i, B - 1] = 5;
                                        deck2[i, B + 1] = 5;
                                    }
                                    Kill();
                                    return 0;
                                }
                                deck2[A - 1, B] = 5;
                                deck2[A + 3, B] = 5;
                                for (int i = A - 1; i < A + 4; i++)
                                {
                                    deck2[i, B + 1] = 5;
                                    deck2[i, B - 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            deck2[A + 2, B] = 5;
                            deck2[A - 1, B] = 5;
                            for (int i = A - 1; i < A + 3; i++)
                            {
                                deck2[i, B + 1] = 5;
                                deck2[i, B - 1] = 5;
                            }
                            Kill();
                            return 0;
                        }
                    }
                }
                return 0;
            }
            else if (status2 == 1 || status2 == 2 || status1 == 0)
            {
                if (!(A >= 1 && A <= 10 && B >= 1 && B <= 10))
                {
                    Console.WriteLine("\nНеверные координаты для удара");
                    return 0;
                }
                else if (deck1[A, B] == 3 || deck1[A, B] == 4 || deck1[A, B] == 5)
                {
                    Console.WriteLine("\nВ эту позицию нельзя ударить!");
                    return 0;
                }
                else if (deck1[A, B] == 0 || deck1[A, B] == 1)
                {
                    deck1[A, B] = 3;
                    Console.Clear();
                    Print2decks();
                    Console.Write("\nПромах!");
                    status2 = 0;
                    status1 = 1;
                    return 0;
                }
                else if (deck1[A, B] == 2)
                {
                    deck1[A, B] = 4;
                    status2 = 2;
                    status1 = 0;
                    botcordb = B;
                    botcorda = A;

                    bool still_alive = false;
                    if (deck1[A + 1, B] == 4 || deck1[A + 1, B] == 2)
                        temp4 = 0;
                    if (deck1[A - 1, B] == 4 || deck1[A - 1, B] == 2)
                        temp2 = 0;
                    if (deck1[A, B - 1] == 4 || deck1[A, B - 1] == 2)
                        temp1 = 0;
                    if (deck1[A, B + 1] == 4 || deck1[A, B + 1] == 2)
                        temp3 = 0;
                    if (temp1 == 0 && temp3 == 0)
                        if (deck1[A, B - 2] == 2 || deck1[A, B - 1] == 2 || deck1[A, B] == 2 || deck1[A, B + 1] == 2 || deck1[A, B + 2] == 2)
                            still_alive = true;
                    if (temp2 == 0 && temp4 == 0)
                        if (deck1[A - 2, B] == 2 || deck1[A - 1, B] == 2 || deck1[A, B] == 2 || deck1[A + 1, B] == 2 || deck1[A + 2, B] == 2)
                            still_alive = true;
                    if (temp1 == 0)
                    {
                        if (deck1[A, B - 2] == 2 || deck1[A, B - 2] == 4)
                            temp2 = 2;
                        if (temp2 == 2)
                            if (deck1[A, B - 3] == 2 || deck1[A, B - 2] == 2 || deck1[A, B - 1] == 2 || deck1[A, B] == 2)
                                still_alive = true;
                        if (temp2 == 0)
                            if (deck1[A, B - 1] == 2 || deck1[A, B] == 2)
                                still_alive = true;
                    }
                    if (temp3 == 0)
                    {
                        if (deck1[A, B + 2] == 2 || deck1[A, B + 2] == 4)
                            temp4 = 2;
                        if (temp4 == 2)
                            if (deck1[A, B + 3] == 2 || deck1[A, B + 2] == 2 || deck1[A, B + 1] == 2 || deck1[A, B] == 2)
                                still_alive = true;
                        if (temp4 == 0)
                            if (deck1[A, B] == 2 || deck1[A, B + 1] == 2)
                                still_alive = true;
                    }
                    if (temp2 == 0)
                    {
                        if (deck1[A - 2, B] == 2 || deck1[A - 2, B] == 4)
                            temp1 = 2;
                        if (temp1 == 2)
                            if (deck1[A - 3, B] == 2 || deck1[A - 2, B] == 2 || deck1[A, B] == 2 || deck1[A - 1, B] == 2)
                                still_alive = true;
                        if (temp1 == 0)
                            if (deck1[A - 1, B] == 2 || deck1[A, B] == 2)
                                still_alive = true;
                    }
                    if (temp4 == 0)
                    {
                        if (deck1[A + 2, B] == 2 || deck1[A + 2, B] == 4)
                            temp3 = 2;
                        if (temp3 == 2)
                            if (deck1[A + 3, B] == 2 || deck1[A + 2, B] == 2 || deck1[A, B] == 2 || deck1[A + 1, B] == 2)
                                still_alive = true;
                        if (temp3 == 0)
                            if (deck1[A + 1, B] == 2 || deck1[A, B] == 2)
                                still_alive = true;
                    }

                    if (still_alive)
                    {
                        Console.Clear();
                        Print2decks();
                        Console.Write("\nПопал!");
                    }
                    else
                    {
                        botcordb = 0;
                        botcorda = 0;
                        if (deck1[A + 1, B] == 4)
                            temp4 = 1;
                        if (deck1[A - 1, B] == 4)
                            temp2 = 1;
                        if (deck1[A, B - 1] == 4)
                            temp1 = 1;
                        if (deck1[A, B + 1] == 4)
                            temp3 = 1;
                        if (temp1 != 1 && temp2 != 1 && temp3 != 1 && temp4 != 1)
                        {
                            deck1[A - 1, B] = 5;
                            deck1[A + 1, B] = 5; deck1[A, B + 1] = 5; deck1[A, B - 1] = 5;
                            deck1[A - 1, B - 1] = 5; deck1[A + 1, B - 1] = 5;
                            deck1[A - 1, B + 1] = 5; deck1[A + 1, B + 1] = 5;
                            Kill();
                            return 0;
                        }
                        if (temp1 == 1 && temp3 == 1)
                        {
                            if (deck1[A, B - 2] == 4)
                            {
                                deck1[A, B - 3] = 5; deck1[A, B + 2] = 5;
                                for (int i = B - 3; i < B + 3; i++)
                                {
                                    deck1[A - 1, i] = 5;
                                    deck1[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            else if (deck1[A, B + 2] == 4)
                            {
                                deck1[A, B + 3] = 5;
                                deck1[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 4; i++)
                                {
                                    deck1[A - 1, i] = 5;
                                    deck1[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            else
                            {
                                deck1[A, B + 2] = 5;
                                deck1[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 3; i++)
                                {
                                    deck1[A - 1, i] = 5;
                                    deck1[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                        }
                        if (temp2 == 1 && temp4 == 1)
                        {
                            if (deck1[A - 2, B] == 4)
                            {
                                deck1[A - 3, B] = 5;
                                deck1[A + 2, B] = 5;
                                for (int i = A - 3; i < A + 3; i++)
                                {
                                    deck1[i, B - 1] = 5;
                                    deck1[i, B + 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            else if (deck1[A + 2, B] == 4)
                            {
                                deck1[A + 3, B] = 5;
                                deck1[A - 2, B] = 5;
                                for (int i = A - 2; i < A + 4; i++)
                                {
                                    deck1[i, B - 1] = 5;
                                    deck1[i, B + 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            else
                            {
                                deck1[A + 2, B] = 5;
                                deck1[A - 2, B] = 5;
                                for (int i = B - 2; i < B + 3; i++)
                                {
                                    deck1[i, B + 1] = 5;
                                    deck1[i, B - 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                        }
                        if (temp1 == 1)
                        {
                            if (deck1[A, B - 2] == 4)
                            {
                                if (deck1[A, B - 3] == 4)
                                {
                                    deck1[A, B + 1] = 5;
                                    deck1[A, B - 4] = 5;
                                    for (int i = B - 4; i < B + 2; i++)
                                    {
                                        deck1[A - 1, i] = 5;
                                        deck1[A + 1, i] = 5;
                                    }
                                    Kill();
                                    return 0;
                                }
                                deck1[A, B + 1] = 5;
                                deck1[A, B - 3] = 5;
                                for (int i = B - 3; i < B + 2; i++)
                                {
                                    deck1[A - 1, i] = 5;
                                    deck1[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            deck1[A, B + 1] = 5;
                            deck1[A, B - 2] = 5;
                            for (int i = B - 2; i < B + 2; i++)
                            {
                                deck1[A - 1, i] = 5;
                                deck1[A + 1, i] = 5;
                            }
                            Kill();
                            return 0;
                        }
                        if (temp3 == 1)
                        {
                            if (deck1[A, B + 2] == 4)
                            {
                                if (deck1[A, B + 3] == 4)
                                {
                                    deck1[A, B - 1] = 5;
                                    deck1[A, B + 4] = 5;
                                    for (int i = B - 1; i < B + 5; i++)
                                    {
                                        deck1[A - 1, i] = 5;
                                        deck1[A + 1, i] = 5;
                                    }
                                    Kill();
                                    return 0;
                                }
                                deck1[A, B + 1] = 5;
                                deck1[A, B - 3] = 5;
                                for (int i = B - 1; i < B + 4; i++)
                                {
                                    deck1[A - 1, i] = 5;
                                    deck1[A + 1, i] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            deck1[A, B + 1] = 5;
                            deck1[A, B - 2] = 5;
                            for (int i = B - 1; i < B + 3; i++)
                            {
                                deck1[A - 1, i] = 5;
                                deck1[A + 1, i] = 5;
                            }
                            Kill();
                            return 0;
                        }
                        if (temp2 == 1)
                        {
                            if (deck1[A - 2, B] == 4)
                            {
                                if (deck1[A - 3, B] == 4)
                                {
                                    deck1[A + 1, B] = 5;
                                    deck1[A - 4, B] = 5;
                                    for (int i = A - 4; i < A + 2; i++)
                                    {
                                        deck1[i, B - 1] = 5;
                                        deck1[i, B + 1] = 5;
                                    }
                                    Kill();
                                    return 0;
                                }
                                deck1[A + 1, B] = 5;
                                deck1[A - 3, B] = 5;
                                for (int i = A - 3; i < A + 2; i++)
                                {
                                    deck1[i, B + 1] = 5;
                                    deck1[i, B - 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            deck1[A + 1, B] = 5;
                            deck1[A - 2, B] = 5;
                            for (int i = A - 2; i < A + 2; i++)
                            {
                                deck1[i, B + 1] = 5;
                                deck1[i, B - 1] = 5;
                            }
                            Kill();
                            return 0;
                        }
                        if (temp4 == 1)
                        {
                            if (deck1[A + 2, B] == 4)
                            {
                                if (deck1[A + 3, B] == 4)
                                {
                                    deck1[A - 1, B] = 5;
                                    deck1[A + 4, B] = 5;
                                    for (int i = A - 1; i < A + 5; i++)
                                    {
                                        deck1[i, B - 1] = 5;
                                        deck1[i, B + 1] = 5;
                                    }
                                    Kill();
                                    return 0;
                                }
                                deck1[A - 1, B] = 5;
                                deck1[A + 3, B] = 5;
                                for (int i = A - 1; i < A + 4; i++)
                                {
                                    deck1[i, B + 1] = 5;
                                    deck1[i, B - 1] = 5;
                                }
                                Kill();
                                return 0;
                            }
                            deck1[A + 1, B] = 5;
                            deck1[A - 2, B] = 5;
                            for (int i = A - 1; i < A + 3; i++)
                            {
                                deck1[i, B + 1] = 5;
                                deck1[i, B - 1] = 5;
                            }
                            Kill();
                            return 0;
                        }
                    }
                }
                return 0;
            }
            else
            {
                Console.Write("Ошибка");
                return 0;
            }
            return 0;
        }
        public override void Step()
        {
            bool temp3 = false;
            int temp1 = 0;
            char temp2 = (char)0;
            int A = 0;
            int B = 0;
            if (status1 == 1 || status1 == 2 || status2 == 0)
            {
                status1 = 0;
                status2 = 1;
                /*Console.WriteLine("\n\nХод 1 игрока\n");
                temp3 = false;
                while (!temp3)
                {
                    Console.Write($"Выберите позицию для удара (цифру от 1 до 10 и заглавную английскую букву от {symbols[0]} до {symbols[9]} (A1, B2)(0 - показать свою доску)): ");
                    string input = Console.ReadLine();
                    ParseInput(input, out A, out B);
                    if (A >= 1 && A <= 10 && B >= 1 && B <= 10 && deck2[A, B] != 3 && deck2[A, B] != 4 && deck2[A, B] != 5)
                        temp3 = true;
                    else
                        Console.WriteLine("\nПрограмма не смогла определить позицию удара или в эту позицию нельзя ударить! Попробуйте еще раз\n");
                }
                Check(A, B);
            }
            else if (status2 == 1 || status2 == 2 || status1 == 0)
            {
                status2 = 1;
                status1 = 0;
                Console.WriteLine("\n\nХод робота\n");
                temp3 = false;
                while (status2 != 0)
                {
                    A = 0;
                    B = 0;
                    if (botcordb > 0 && botcorda > 0)
                    {
                        int temp = rand.Next(4);
                        switch (temp)
                        {
                            case 0:
                                if (botcordb - 1 >= 1)
                                {
                                    A = botcorda;
                                    B = botcordb - 1;
                                }
                                break;
                            case 1:
                                if (botcordb + 1 <= 10)
                                {
                                    A = botcorda;
                                    B = botcordb + 1;
                                }
                                break;
                            case 2:
                                if (botcorda - 1 >= 1)
                                {
                                    A = botcorda - 1;
                                    B = botcordb;
                                }
                                break;
                            case 3:
                                if (botcorda + 1 <= 10)
                                {
                                    A = botcorda + 1;
                                    B = botcordb;
                                }
                                break;
                        }
                        if (A >= 1 && A <= 10 && B >= 1 && B <= 10)
                        {
                            if (deck1[A, B] == 3 || deck1[A, B] == 4 || deck1[A, B] == 5)
                            {
                                A = 0;
                                B = 0;
                            }
                        }
                        if (A == 0 && B == 0)
                        {
                            if (botcordb - 1 >= 1 && botcordb + 1 <= 10 && deck1[botcorda, botcordb - 1] == 4 && deck1[botcorda, botcordb + 1] == 4)
                            {
                                temp = rand.Next(2);
                                switch (temp)
                                {
                                    case 0:
                                        A = botcorda;
                                        if (botcordb - 2 >= 1)
                                        {
                                            B = botcordb - 2;
                                            break;
                                        }
                                        else
                                        {
                                            temp = 1;
                                            continue;
                                        }
                                    case 1:
                                        A = botcorda;
                                        if (botcordb + 2 <= 10)
                                        {
                                            B = botcordb + 2;
                                            break;
                                        }
                                        else
                                        {
                                            temp = 0;
                                            continue;
                                        }
                                }
                            }
                            else if (botcorda - 1 >= 1 && botcorda + 1 <= 10 && deck1[botcorda - 1, botcordb] == 4 && deck1[botcorda + 1, botcordb] == 4)
                            {
                                temp = rand.Next(2);
                                switch (temp)
                                {
                                    case 0:
                                        B = botcordb;
                                        if (botcorda - 2 >= 1)
                                        {
                                            A = botcorda - 2;
                                            break;
                                        }
                                        else
                                        {
                                            temp = 1;
                                            continue;
                                        }
                                    case 1:
                                        B = botcordb;
                                        if (botcorda + 2 <= 10)
                                        {
                                            A = botcorda + 2;
                                            break;
                                        }
                                        else
                                        {
                                            temp = 0;
                                            continue;
                                        }
                                }
                            }
                            else if (botcordb - 1 >= 1 && deck1[botcorda, botcordb - 1] == 4)
                            {
                                if (botcordb - 3 >= 1)
                                {
                                    A = botcorda;
                                    temp = rand.Next(2);
                                    switch (temp)
                                    {
                                        case 0:
                                            if (botcordb - 2 >= 1)
                                            {
                                                B = botcordb - 2;
                                                break;
                                            }
                                            else
                                            {
                                                temp = 1;
                                                continue;
                                            }
                                        case 1:
                                            if (botcordb - 3 >= 1)
                                            {
                                                B = botcordb - 3;
                                                break;
                                            }
                                            else
                                            {
                                                temp = 0;
                                                continue;
                                            }
                                    }
                                }
                                else if (botcordb - 2 >= 1)
                                {
                                    A = botcorda;
                                    B = botcordb - 2;
                                }
                            }
                            else if (botcordb + 1 <= 10 && deck1[botcorda, botcordb + 1] == 4)
                            {
                                A = botcorda;
                                if (botcordb + 3 <= 10)
                                {
                                    temp = rand.Next(2);
                                    switch (temp)
                                    {
                                        case 0:
                                            if (botcordb + 2 <= 10)
                                            {
                                                B = botcordb + 2;
                                                break;
                                            }
                                            else
                                            {
                                                temp = 1;
                                                continue;
                                            }
                                        case 1:
                                            if (botcordb + 3 <= 10)
                                            {
                                                B = botcordb + 3;
                                                break;
                                            }
                                            else
                                            {
                                                temp = 0;
                                                continue;
                                            }
                                    }
                                }
                                else if (botcordb + 2 <= 10)
                                {
                                    B = botcordb + 2;
                                }
                            }
                            else if (botcorda - 1 >= 1 && deck1[botcorda - 1, botcordb] == 4)
                            {
                                if (botcorda - 3 >= 1)
                                {
                                    B = botcordb;
                                    temp = rand.Next(2);
                                    switch (temp)
                                    {
                                        case 0:
                                            if (botcorda - 2 >= 1)
                                            {
                                                A = botcorda - 2;
                                                break;
                                            }
                                            else
                                            {
                                                temp = 1;
                                                continue;
                                            }
                                        case 1:
                                            if (botcorda - 3 >= 1)
                                            {
                                                A = botcorda - 3;
                                                break;
                                            }
                                            else
                                            {
                                                temp = 0;
                                                continue;
                                            }
                                    }
                                }
                                else if (botcorda - 2 >= 1)
                                {
                                    A = botcorda - 2;
                                    B = botcordb;
                                }
                            }
                            else if (botcorda + 1 <= 10 && deck1[botcorda + 1, botcordb] == 4)
                            {
                                B = botcordb;
                                if (botcorda + 3 <= 10)
                                {
                                    temp = rand.Next(2);
                                    switch (temp)
                                    {
                                        case 0:
                                            if (botcorda + 2 <= 10)
                                            {
                                                A = botcorda + 2;
                                                break;
                                            }
                                            else
                                            {
                                                temp = 1;
                                                continue;
                                            }
                                        case 1:
                                            if (botcorda + 3 <= 10)
                                            {
                                                A = botcorda + 3;
                                                break;
                                            }
                                            else
                                            {
                                                temp = 0;
                                                continue;
                                            }
                                    }
                                }
                                else if (botcorda + 2 <= 10)
                                {
                                    A = botcorda + 2;
                                }
                            }
                        }
                    }
                    if (A < 1 || A > 10 || B < 1 || B > 10)
                    {
                        A = rand.Next(10) + 1;
                        B = rand.Next(10) + 1;
                    }
                    Check(A, B);
                }
            }
            else
            {
                Console.WriteLine("Ошибка, ход игрока.");
                status1 = 1;
                status2 = 0;
            }
        }
    }*/
        public int Step(int row, int col)
        {
            if (status1 == 1 || status1 == 2 || status2 == 0)
                return Check(row, col);
            else
            {

                int targetA = 0;
                int targetB = 0;

                if (botcorda > 0 && botcordb > 0)
                {
                    bool hasHorizontalNeighbor = (botcordb - 1 >= 1 && deck1[botcorda, botcordb - 1] == 4) || (botcordb + 1 <= 10 && deck1[botcorda, botcordb + 1] == 4);
                    bool hasVerticalNeighbor = (botcorda - 1 >= 1 && deck1[botcorda - 1, botcordb] == 4) || (botcorda + 1 <= 10 && deck1[botcorda + 1, botcordb] == 4);

                    if (hasHorizontalNeighbor)
                    {
                        List<int> horizontalTails = new List<int>();

                        int leftB = botcordb;
                        while (leftB >= 1 && deck1[botcorda, leftB] == 4) { leftB--; }
                        if (leftB >= 1 && deck1[botcorda, leftB] != 3 && deck1[botcorda, leftB] != 5)
                        {
                            horizontalTails.Add(leftB);
                        }

                        int rightB = botcordb;
                        while (rightB <= 10 && deck1[botcorda, rightB] == 4) { rightB++; }
                        if (rightB <= 10 && deck1[botcorda, rightB] != 3 && deck1[botcorda, rightB] != 5)
                        {
                            horizontalTails.Add(rightB);
                        }

                        if (horizontalTails.Count > 0)
                        {
                            targetA = botcorda;
                            targetB = horizontalTails[rand.Next(horizontalTails.Count)];
                        }
                    }
                    else if (hasVerticalNeighbor)
                    {
                        List<int> verticalTails = new List<int>();

                        int upA = botcorda;
                        while (upA >= 1 && deck1[upA, botcordb] == 4) { upA--; }
                        if (upA >= 1 && deck1[upA, botcordb] != 3 && deck1[upA, botcordb] != 5)
                        {
                            verticalTails.Add(upA);
                        }

                        int downA = botcorda;
                        while (downA <= 10 && deck1[downA, botcordb] == 4) { downA++; }
                        if (downA <= 10 && deck1[downA, botcordb] != 3 && deck1[downA, botcordb] != 5)
                        {
                            verticalTails.Add(downA);
                        }

                        if (verticalTails.Count > 0)
                        {
                            targetA = verticalTails[rand.Next(verticalTails.Count)];
                            targetB = botcordb;
                        }
                    }

                    if (targetA == 0 && targetB == 0)
                    {
                        List<KeyValuePair<int, int>> neighbors = new List<KeyValuePair<int, int>>();
                        if (botcorda - 1 >= 1 && deck1[botcorda - 1, botcordb] != 3 && deck1[botcorda - 1, botcordb] != 4 && deck1[botcorda - 1, botcordb] != 5)
                            neighbors.Add(new KeyValuePair<int, int>(botcorda - 1, botcordb));
                        if (botcorda + 1 <= 10 && deck1[botcorda + 1, botcordb] != 3 && deck1[botcorda + 1, botcordb] != 4 && deck1[botcorda + 1, botcordb] != 5)
                            neighbors.Add(new KeyValuePair<int, int>(botcorda + 1, botcordb));
                        if (botcordb - 1 >= 1 && deck1[botcorda, botcordb - 1] != 3 && deck1[botcorda, botcordb - 1] != 4 && deck1[botcorda, botcordb - 1] != 5)
                            neighbors.Add(new KeyValuePair<int, int>(botcorda, botcordb - 1));
                        if (botcordb + 1 <= 10 && deck1[botcorda, botcordb + 1] != 3 && deck1[botcorda, botcordb + 1] != 4 && deck1[botcorda, botcordb + 1] != 5)
                            neighbors.Add(new KeyValuePair<int, int>(botcorda, botcordb + 1));

                        if (neighbors.Count > 0)
                        {
                            var chosen = neighbors[rand.Next(neighbors.Count)];
                            targetA = chosen.Key;
                            targetB = chosen.Value;
                        }
                    }
                }

                if (targetA == 0 && targetB == 0)
                {
                    do
                    {
                        targetA = rand.Next(10) + 1;
                        targetB = rand.Next(10) + 1;
                    }
                    while (deck1[targetA, targetB] == 3 || deck1[targetA, targetB] == 4 || deck1[targetA, targetB] == 5);
                }
                Datas.lastPoint = new Point(targetA,targetB);
                return Check(targetA, targetB);
            }
        }
        public int Check(int A, int B)
        {
            int temp1 = 2; int temp2 = 2; int temp3 = 2; int temp4 = 2;
            int tempA = A; int tempB = B;
            bool still_alive = false;

            if (status1 == 1 || status1 == 2 || status2 == 0)
            {
                if (deck2[A, B] == 0 || deck2[A, B] == 1)
                {
                    deck2[A, B] = 3;
                    status1 = 0; status2 = 1;
                    return 0;
                }
                else if (deck2[A, B] == 2)
                {
                    deck2[A, B] = 4;
                    status1 = 2; status2 = 0;

                    if (deck2[A, B - 1] == 2 || deck2[A, B - 1] == 4) temp1 = 0;
                    if (deck2[A - 1, B] == 2 || deck2[A - 1, B] == 4) temp2 = 0;
                    if (deck2[A, B + 1] == 2 || deck2[A, B + 1] == 4) temp3 = 0;
                    if (deck2[A + 1, B] == 2 || deck2[A + 1, B] == 4) temp4 = 0;

                    if (temp1 == 0)
                    {
                        if (deck2[A, B - 2] == 2 || deck2[A, B - 2] == 4) temp1 = 2;
                        if (temp1 == 2)
                            if (deck2[A, B - 3] == 2 || deck2[A, B - 2] == 2 || deck2[A, B] == 2 || deck2[A, B - 1] == 2) still_alive = true;
                        if (temp1 == 0)
                            if (deck2[A, B - 1] == 2 || deck2[A, B] == 2) still_alive = true;
                    }
                    if (temp3 == 0)
                    {
                        if (deck2[A, B + 2] == 2 || deck2[A, B + 2] == 4) temp3 = 2;
                        if (temp3 == 2)
                            if (deck2[A, B + 3] == 2 || deck2[A, B + 2] == 2 || deck2[A, B] == 2 || deck2[A, B + 1] == 2) still_alive = true;
                        if (temp3 == 0)
                            if (deck2[A, B + 1] == 2 || deck2[A, B] == 2) still_alive = true;
                    }
                    if (temp2 == 0)
                    {
                        if (deck2[A - 2, B] == 2 || deck2[A - 2, B] == 4) temp2 = 2;
                        if (temp2 == 2)
                            if (deck2[A - 3, B] == 2 || deck2[A - 2, B] == 2 || deck2[A, B] == 2 || deck2[A - 1, B] == 2) still_alive = true;
                        if (temp2 == 0)
                            if (deck2[A - 1, B] == 2 || deck2[A, B] == 2) still_alive = true;
                    }
                    if (temp4 == 0)
                    {
                        if (deck2[A + 2, B] == 2 || deck2[A + 2, B] == 4) temp4 = 2;
                        if (temp4 == 2)
                            if (deck2[A + 3, B] == 2 || deck2[A + 2, B] == 2 || deck2[A, B] == 2 || deck2[A + 1, B] == 2) still_alive = true;
                        if (temp4 == 0)
                            if (deck2[A + 1, B] == 2 || deck2[A, B] == 2) still_alive = true;
                    }

                    if (still_alive)
                    {
                        return 1;
                    }
                    else
                    {
                        if (deck2[A + 1, B] == 4) temp4 = 1;
                        if (deck2[A - 1, B] == 4) temp2 = 1;
                        if (deck2[A, B - 1] == 4) temp1 = 1;
                        if (deck2[A, B + 1] == 4) temp3 = 1;

                        if (temp1 != 1 && temp2 != 1 && temp3 != 1 && temp4 != 1)
                        {
                            deck2[A - 1, B] = 5; deck2[A + 1, B] = 5; deck2[A, B + 1] = 5; deck2[A, B - 1] = 5;
                            deck2[A - 1, B - 1] = 5; deck2[A + 1, B - 1] = 5; deck2[A - 1, B + 1] = 5; deck2[A + 1, B + 1] = 5;
                            return 2;
                        }
                        if (temp1 == 1 && temp3 == 1)
                        {
                            if (deck2[A, B - 2] == 4)
                            {
                                deck2[A, B - 3] = 5; deck2[A, B + 2] = 5;
                                for (int i = B - 3; i < B + 3; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                            else if (deck2[A, B + 2] == 4)
                            {
                                deck2[A, B + 3] = 5; deck2[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 4; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                            else
                            {
                                deck2[A, B + 2] = 5; deck2[A, B - 2] = 5;
                                for (int i = B - 2; i < B + 3; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                        }
                        if (temp2 == 1 && temp4 == 1)
                        {
                            if (deck2[A - 2, B] == 4)
                            {
                                deck2[A - 3, B] = 5; deck2[A + 2, B] = 5;
                                for (int i = A - 3; i < A + 3; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                return 2;
                            }
                            else if (deck2[A + 2, B] == 4)
                            {
                                deck2[A + 3, B] = 5; deck2[A - 2, B] = 5;
                                for (int i = A - 2; i < A + 4; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                return 2;
                            }
                            else
                            {
                                deck2[A + 2, B] = 5; deck2[A - 2, B] = 5;
                                for (int i = A - 2; i < A + 3; i++) { deck2[i, B + 1] = 5; deck2[i, B - 1] = 5; }
                                return 2;
                            }
                        }
                        if (temp1 == 1)
                        {
                            if (deck2[A, B - 2] == 4)
                            {
                                if (deck2[A, B - 3] == 4)
                                {
                                    deck2[A, B + 1] = 5; deck2[A, B - 4] = 5;
                                    for (int i = B - 4; i < B + 2; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                    return 2;
                                }
                                deck2[A, B + 1] = 5; deck2[A, B - 3] = 5;
                                for (int i = B - 3; i < B + 2; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                            deck2[A, B + 1] = 5; deck2[A, B - 2] = 5;
                            for (int i = B - 2; i < B + 2; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                            return 2;
                        }
                        if (temp3 == 1)
                        {
                            if (deck2[A, B + 2] == 4)
                            {
                                if (deck2[A, B + 3] == 4)
                                {
                                    deck2[A, B - 1] = 5; deck2[A, B + 4] = 5;
                                    for (int i = B - 1; i < B + 5; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                    return 2;
                                }
                                deck2[A, B - 1] = 5; deck2[A, B + 3] = 5;
                                for (int i = B - 1; i < B + 4; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                                return 2;
                            }
                            deck2[A, B - 1] = 5; deck2[A, B + 2] = 5;
                            for (int i = B - 1; i < B + 3; i++) { deck2[A - 1, i] = 5; deck2[A + 1, i] = 5; }
                            return 2;
                        }
                        if (temp2 == 1)
                        {
                            if (deck2[A - 2, B] == 4)
                            {
                                if (deck2[A - 3, B] == 4)
                                {
                                    deck2[A + 1, B] = 5; deck2[A - 4, B] = 5;
                                    for (int i = A - 4; i < A + 2; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                    return 2;
                                }
                                deck2[A + 1, B] = 5; deck2[A - 3, B] = 5;
                                for (int i = A - 3; i < A + 2; i++) { deck2[i, B + 1] = 5; deck2[i, B - 1] = 5; }
                                return 2;
                            }
                            deck2[A + 1, B] = 5; deck2[A - 2, B] = 5;
                            for (int i = A - 2; i < A + 2; i++) { deck2[i, B + 1] = 5; deck2[i, B - 1] = 5; }
                            return 2;
                        }
                        if (temp4 == 1)
                        {
                            if (deck2[A + 2, B] == 4)
                            {
                                if (deck2[A + 3, B] == 4)
                                {
                                    deck2[A - 1, B] = 5; deck2[A + 4, B] = 5;
                                    for (int i = A - 1; i < A + 5; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                    return 2;
                                }
                                deck2[A - 1, B] = 5; deck2[A + 3, B] = 5;
                                for (int i = A - 1; i < A + 4; i++) { deck2[i, B - 1] = 5; deck2[i, B + 1] = 5; }
                                return 2;
                            }
                            deck2[A - 1, B] = 5; deck2[A + 2, B] = 5;
                            for (int i = A - 1; i < A + 3; i++) { deck2[i, B + 1] = 5; deck2[i, B - 1] = 5; }
                            return 2;
                        }
                    }
                }
                return 0;
            }
            else
            {
                if (deck1[A, B] == 0 || deck1[A, B] == 1)
                {
                    deck1[A, B] = 3;
                    status1 = 1;
                    status2 = 0;
                    return 0;
                }
                else if (deck1[A, B] == 2)
                {
                    deck1[A, B] = 4;

                    still_alive = false;
                    int checkB = B;
                    while (checkB >= 1 && (deck1[A, checkB] == 4 || deck1[A, checkB] == 2))
                    {
                        if (deck1[A, checkB] == 2) still_alive = true;
                        checkB--;
                    }
                    checkB = B;
                    while (checkB <= 10 && (deck1[A, checkB] == 4 || deck1[A, checkB] == 2))
                    {
                        if (deck1[A, checkB] == 2) still_alive = true;
                        checkB++;
                    }
                    int checkA = A;
                    while (checkA >= 1 && (deck1[checkA, B] == 4 || deck1[checkA, B] == 2))
                    {
                        if (deck1[checkA, B] == 2) still_alive = true;
                        checkA--;
                    }
                    checkA = A;
                    while (checkA <= 10 && (deck1[checkA, B] == 4 || deck1[checkA, B] == 2))
                    {
                        if (deck1[checkA, B] == 2) still_alive = true;
                        checkA++;
                    }
                    if (still_alive)
                    {
                        if (botcorda == 0 && botcordb == 0)
                        {
                            botcorda = A;
                            botcordb = B;
                        }
                        status1 = 0;
                        status2 = 1;
                        return 1; // ранил
                    }
                    else
                    {
                        int minA = A, maxA = A, minB = B, maxB = B;
                        while (minA >= 1 && deck1[minA, B] == 4) minA--;
                        while (maxA <= 10 && deck1[maxA, B] == 4) maxA++;
                        while (minB >= 1 && deck1[A, minB] == 4) minB--;
                        while (maxB <= 10 && deck1[A, maxB] == 4) maxB++;

                        for (int i = minA; i <= maxA; i++)
                        {
                            for (int j = minB; j <= maxB; j++)
                            {
                                if (i >= 1 && i <= 10 && j >= 1 && j <= 10)
                                {
                                    if (deck1[i, j] != 4)
                                        deck1[i, j] = 5;
                                }
                            }
                        }
                        botcorda = 0;
                        botcordb = 0;
                        status1 = 0;
                        status2 = 1;
                        return 2; // потопил
                    }
                }
                return 0;
            }
        }
    }
    public static class Datas
    {
        public static int choice = 999;
        public static int choice2 = 0;
        public static char choicechar = '-';
        public static string inputlog = " ";
        public static string inputpass = " ";
        public static string inputlogreg = " ";
        public static string inputpassreg = " ";
        public static string filePath = @"C:\Users\Student\P-41\C#\Экзамен\Газарян\Sea wars\profile.txt";
        public static Point lastPoint = new Point();
        public static Game play = new Game();
        public static Botgame botplay = new Botgame();
        public static Profiles profile = new Profiles();
    }
}
