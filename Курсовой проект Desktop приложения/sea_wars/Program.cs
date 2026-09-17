namespace sea_wars
{
    
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        static int Menu(string[] args)
        {
            int choice = 999; int choice2 = 0;
            char choicechar = '-';
            string inputlog = " "; string inputpass = " "; string inputlogreg = " "; string inputpassreg = " ";
            string filePath = @"C:\Users\Student\P-41\C#\Экзамен\Газарян\Sea wars\profile.txt";
            Game play = new Game();
            Botgame botplay = new Botgame();
            Profiles profile = new Profiles();
            Console.WriteLine("Добро пожаловать в игру Морской Бой!");
            Console.Write("Вы зарегистрированы?(1 - да, 2 - нет): ");
            profile.ReadFromFile(filePath);
            while (!int.TryParse(Console.ReadLine(), out choice2) || choice2 < 1 || choice2 > 2)
            {
                Console.WriteLine("Некорректный ввод, попробуйте еще раз: ");
            }
            Console.Clear();
            switch (choice2)
            {
                case 1:
                    while (!profile.AuthorizeUser1(inputlog, inputpass))
                    {
                        Console.Write("Введите логин (от 8 до 24 символов): ");
                        while (string.IsNullOrWhiteSpace(inputlog = Console.ReadLine()) || inputlog.Length < 8 || inputlog.Length > 24 || inputlog.Contains(" "))
                            Console.WriteLine("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                        Console.Write("Введите пароль (от 8 до 24 символов): ");
                        while (string.IsNullOrWhiteSpace(inputpass = Console.ReadLine()) || inputpass.Length < 8 || inputpass.Length > 24 || inputpass.Contains(" "))
                            Console.WriteLine("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                    }
                    break;
                case 2:
                    Console.Write("Введите логин (от 8 до 24 символов): ");
                    while (string.IsNullOrWhiteSpace(inputlogreg = Console.ReadLine()) || inputlogreg.Length < 8 || inputlogreg.Length > 24 || inputlogreg.Contains(" "))
                        Console.Write("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                    Console.Write("Введите пароль (от 8 до 24 символов): ");
                    while (string.IsNullOrWhiteSpace(inputpassreg = Console.ReadLine()) || inputpassreg.Length < 8 || inputpassreg.Length > 24 || inputpassreg.Contains(" "))
                        Console.Write("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                    profile.RegisterUser(inputlogreg, inputpassreg, filePath);
                    Console.Clear();
                    Console.WriteLine("Вы успешно зарегистрировались! Войдите в аккунт");
                    while (!profile.AuthorizeUser1(inputlog, inputpass))
                    {
                        Console.Write("Введите логин (от 8 до 24 символов): ");
                        while (string.IsNullOrWhiteSpace(inputlog = Console.ReadLine()) || inputlog.Length < 8 || inputlog.Length > 24 || inputlog.Contains(" "))
                            Console.WriteLine("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                        Console.Write("Введите пароль (от 8 до 24 символов): ");
                        while (string.IsNullOrWhiteSpace(inputpass = Console.ReadLine()) || inputpass.Length < 8 || inputpass.Length > 24 || inputpass.Contains(" "))
                            Console.WriteLine("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                    }
                    break;
                default:
                    break;
            }
            Console.Clear();
            profile.tryautorize1 = 4;
            while (choice != 0)
            {
                Console.WriteLine($"Здравствуйте, {profile.login1}!");
                Console.Write("Выберите режим игры:\n1 - Игра вдвоем (30 рейтинга)\n2 - Игра против робота (10 рейтинга)\n3 - Просмотреть профиль\n4 - Посмотреть топ-10 игроков\n5 - Посмотреть статистику игрока\n0 - Выход\nВыбор: ");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                    Console.Write("Некорректный ввод, попробуйте еще раз: ");

                switch (choice)
                {
                    case 0:
                        profile.SaveToFile(filePath);
                        return 0;
                    case 1:
                        inputlog = " "; inputpass = " "; inputlogreg = " "; inputpassreg = " ";
                        Console.Clear();
                        Console.Write("Игрок 2, вы зарегистрированы? (1 - да, 2 - нет): ");
                        while (!int.TryParse(Console.ReadLine(), out choice2) || choice2 < 0 || choice2 > 2)
                        {
                            Console.WriteLine("Некорректный ввод, попробуйте еще раз: ");
                        }
                        Console.Clear();
                        switch (choice2)
                        {
                            case 1:
                                while (!profile.AuthorizeUser2(inputlog, inputpass))
                                {
                                    if (profile.tryautorize2 == 0)
                                    {
                                        break;
                                    }
                                    Console.Write("Введите логин (от 8 до 24 символов): ");
                                    while (string.IsNullOrWhiteSpace(inputlog = Console.ReadLine()) || inputlog.Length < 8 || inputlog.Length > 24 || inputlog.Contains(" "))
                                        Console.WriteLine("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                                    Console.Write("Введите пароль (от 8 до 24 символов): ");
                                    while (string.IsNullOrWhiteSpace(inputpass = Console.ReadLine()) || inputpass.Length < 8 || inputpass.Length > 24 || inputpass.Contains(" "))
                                        Console.WriteLine("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                                }
                                break;
                            case 2:
                                Console.Write("Введите логин (от 8 до 24 символов): ");
                                while (string.IsNullOrWhiteSpace(inputlogreg = Console.ReadLine()) || inputlogreg.Length < 8 || inputlogreg.Length > 24 || inputlogreg.Contains(" "))
                                    Console.Write("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                                Console.Write("Введите пароль (от 8 до 24 символов): ");
                                while (string.IsNullOrWhiteSpace(inputpassreg = Console.ReadLine()) || inputpassreg.Length < 8 || inputpassreg.Length > 24 || inputpassreg.Contains(" "))
                                    Console.Write("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                                profile.RegisterUser(inputlogreg, inputpassreg, filePath);
                                Console.Clear();
                                Console.WriteLine("Вы успешно зарегистрировались! Войдите в аккунт");
                                while (!profile.AuthorizeUser2(inputlog, inputpass))
                                {
                                    if (profile.tryautorize2 == 0)
                                    {
                                        break;
                                    }
                                    Console.Write("Введите логин (от 8 до 24 символов): ");
                                    while (string.IsNullOrWhiteSpace(inputlog = Console.ReadLine()) || inputlog.Length < 8 || inputlog.Length > 24 || inputlog.Contains(" "))
                                        Console.WriteLine("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                                    Console.Write("Введите пароль (от 8 до 24 символов): ");
                                    while (string.IsNullOrWhiteSpace(inputpass = Console.ReadLine()) || inputpass.Length < 8 || inputpass.Length > 24 || inputpass.Contains(" "))
                                        Console.WriteLine("Ошибка! Введите строку от 8 до 24 символов без пробелов: ");
                                }
                                break;
                            default:
                                break;
                        }
                        Console.ReadLine();
                        profile.Showprofile2();
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Режим игры вдвоем. Приятной игры! Если вы покинете игру принудительно обоим участникам засчитается техническое поражение!\n");
                        play.profiles = profile;
                        play.Cleardecks();
                        Console.WriteLine($"\n{profile.login1}: Желаете сделать автоматическую расстановку кораблей? ('+'):");
                        string input1 = Console.ReadLine();
                        if (input1.Length > 0 && input1[0] == '+')
                            play.Setdeck1auto();
                        else
                            play.Setdeck1();
                        Console.WriteLine($"\n{profile.login2}: Желаете сделать автоматическую расстановку кораблей? ('+'):");
                        string input2 = Console.ReadLine();
                        if (input2.Length > 0 && input2[0] == '+')
                            play.Setdeck2auto();
                        else
                            play.Setdeck2();
                        play.Print2decks();
                        profile.rating1 -= 30;
                        profile.rating2 -= 30;

                        for (int i = 0; i < 9; i++)
                        {
                            profile.wins1[i] = profile.wins1[i + 1];
                            profile.winsperson1[i] = profile.winsperson1[i + 1];
                            profile.wins2[i] = profile.wins1[i + 1];
                            profile.winsperson2[i] = profile.winsperson1[i + 1];
                        }
                        profile.wins1[9] = false;
                        profile.winsperson1[9] = profile.login2;
                        profile.wins2[9] = false;
                        profile.winsperson2[9] = profile.login1;
                        profile.UpdateMainArraysFromActivePlayers();
                        profile.SaveToFile(filePath);
                        while (play.Checkwin() == 0)
                        {
                            play.Step();
                        }
                        if (botplay.Checkwin() == 1)
                        {
                            Console.WriteLine($"\n\nИгра окончена! \nПо итогам игры победу одержал {profile.login2}\nЖелаете сыграть еще раз?");
                            profile.rating2 += 60;
                            profile.wins2[9] = true;
                            profile.winsperson2[9] = profile.login1;
                            profile.UpdateMainArraysFromActivePlayers();
                            profile.SaveToFile(filePath);
                        }
                        else
                        {
                            Console.WriteLine($"\n\nИгра окончена! \nПо итогам игры победу одержал {profile.login1}\nЖелаете сыграть еще раз?");
                            profile.rating1 += 60;
                            profile.wins1[9] = true;
                            profile.winsperson1[9] = profile.login2;
                            profile.UpdateMainArraysFromActivePlayers();
                            profile.SaveToFile(filePath);
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Режим игры с роботом. Приятной игры!\n");
                        botplay.Cleardecks();

                        Console.WriteLine("\nЖелаете сделать автоматическую расстановку кораблей? ('+'):");
                        string inputBot = Console.ReadLine();
                        if (inputBot.Length > 0 && inputBot[0] == '+')
                            botplay.Setdeck1auto();
                        else
                            botplay.Setdeck1();

                        botplay.Setdeck2();
                        botplay.Print2decks();
                        profile.rating1 -= 10;

                        for (int i = 0; i < 9; i++)
                        {
                            profile.wins1[i] = profile.wins1[i + 1];
                            profile.winsperson1[i] = profile.winsperson1[i + 1];
                        }
                        profile.wins1[9] = false;
                        profile.winsperson1[9] = "Робот";
                        profile.UpdateMainArraysFromActivePlayers();
                        profile.SaveToFile(filePath);
                        while (botplay.Checkwin() == 0)
                        {
                            botplay.Step();
                        }
                        if (botplay.Checkwin() == 1)
                        {
                            Console.WriteLine($"\n\nИгра окончена! \nПо итогам игры победу одержал {profile.login1}\nЖелаете сыграть еще раз?");
                            profile.rating1 += 20;
                            profile.wins1[9] = true;
                            profile.UpdateMainArraysFromActivePlayers();
                            profile.SaveToFile(filePath);
                        }
                        else
                        {
                            Console.WriteLine($"\n\nИгра окончена! \nПо итогам игры победу одержал робот\nЖелаете сыграть еще раз?");
                        }
                        break;
                    case 3:
                        profile.Showprofile1();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        profile.ShowTop10();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        profile.ShowUserProfile();
                        break;
                }
            }
            return 0;
        }
    }
}