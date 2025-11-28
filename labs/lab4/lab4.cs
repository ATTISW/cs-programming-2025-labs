using System;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание (1–10) или 0 для выхода:");
            Console.WriteLine("1 – Кондиционер");
            Console.WriteLine("2 – Времена года");
            Console.WriteLine("3 – Возраст собаки");
            Console.WriteLine("4 – Делится ли число на 6");
            Console.WriteLine("5 – Проверка пароля");
            Console.WriteLine("6 – Високосный год");
            Console.WriteLine("7 – Минимум из трёх чисел");
            Console.WriteLine("8 – Скидка в магазине");
            Console.WriteLine("9 – Время суток");
            Console.WriteLine("10 – Простое число");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": Task1(); break;
                case "2": Task2(); break;
                case "3": Task3(); break;
                case "4": Task4(); break;
                case "5": Task5(); break;
                case "6": Task6(); break;
                case "7": Task7(); break;
                case "8": Task8(); break;
                case "9": Task9(); break;
                case "10": Task10(); break;
                case "0": return;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

    // ЗАДАНИЕ 1 
    static void Task1()
    {
        Console.Write("Введите температуру: ");
        int temp = int.Parse(Console.ReadLine());

        if (temp >= 20)
            Console.WriteLine("Кондиционер выключен");
        else
            Console.WriteLine("Кондиционер включен");
    }

    // ЗАДАНИЕ 2 
    static void Task2()
    {
        Console.Write("Введите номер месяца: ");
        int month = int.Parse(Console.ReadLine());

        if (month < 1 || month > 12)
        {
            Console.WriteLine("Ошибка: месяца с таким номером нет");
            return;
        }

        if (month == 12 || month == 1 || month == 2)
            Console.WriteLine("Зима");
        else if (month <= 5)
            Console.WriteLine("Весна");
        else if (month <= 8)
            Console.WriteLine("Лето");
        else
            Console.WriteLine("Осень");
    }

    //  ЗАДАНИЕ 3 
    static void Task3()
    {
        Console.Write("Введите возраст собаки (в годах): ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int years))
        {
            Console.WriteLine("Ошибка: введено не число");
            return;
        }

        if (years < 1)
        {
            Console.WriteLine("Ошибка: возраст должен быть не меньше 1");
            return;
        }

        if (years > 22)
        {
            Console.WriteLine("Ошибка: возраст должен быть не больше 22");
            return;
        }

        double humanAge;

        if (years == 1)
            humanAge = 10.5;
        else if (years == 2)
            humanAge = 21;
        else
            humanAge = 21 + (years - 2) * 4;

        Console.WriteLine($"Возраст собаки в человеческих годах: {humanAge}");
    }

    // ЗАДАНИЕ 4 
    static void Task4()
    {
        Console.Write("Введите число: ");
        string num = Console.ReadLine();

        bool lastDigitEven = (num[num.Length - 1] - '0') % 2 == 0;

        int sum = 0;
        foreach (char c in num)
            sum += c - '0';

        if (lastDigitEven && sum % 3 == 0)
            Console.WriteLine("Число делится на 6");
        else
            Console.WriteLine("Число не делится на 6");
    }

    //  ЗАДАНИЕ 5 
    static void Task5()
    {
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();

        bool hasUpper = password.Any(char.IsUpper);
        bool hasLower = password.Any(char.IsLower);
        bool hasDigit = password.Any(char.IsDigit);
        bool hasSpecial = password.Any(ch => "!@#$%^&*()_+-={}[];:'\"|\\/<>,.?".Contains(ch));

        if (password.Length >= 8 && hasUpper && hasLower && hasDigit && hasSpecial)
        {
            Console.WriteLine("Пароль надежный");
            return;
        }

        Console.Write("Пароль ненадежный: отсутствуют ");

        string missing = "";

        if (!hasUpper) missing += "заглавные буквы, ";
        if (!hasLower) missing += "строчные буквы, ";
        if (!hasDigit) missing += "числа, ";
        if (!hasSpecial) missing += "специальные символы, ";
        if (password.Length < 8) missing += "достаточная длина, ";

        Console.WriteLine(missing.Trim().TrimEnd(','));
    }

    // ЗАДАНИЕ 6 
    static void Task6()
    {
        Console.Write("Введите год: ");
        int year = int.Parse(Console.ReadLine());

        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            Console.WriteLine($"{year} - високосный год");
        else
            Console.WriteLine($"{year} - не високосный год");
    }

    //  ЗАДАНИЕ 7 
    static void Task7()
    {
        Console.Write("Введите три числа: ");
        string[] parts = Console.ReadLine().Split();

        int a = int.Parse(parts[0]);
        int b = int.Parse(parts[1]);
        int c = int.Parse(parts[2]);

        int min = a;

        if (b < min) min = b;
        if (c < min) min = c;

        Console.WriteLine($"Наименьшее число: {min}");
    }

    //  ЗАДАНИЕ 8
    static void Task8()
    {
        Console.Write("Введите сумму покупки: ");
        double sum = double.Parse(Console.ReadLine());

        int discount = 0;

        if (sum >= 1000 && sum < 5000) discount = 5;
        else if (sum >= 5000 && sum < 10000) discount = 10;
        else if (sum >= 10000) discount = 15;

        double finalPrice = sum - sum * discount / 100.0;

        Console.WriteLine($"Ваша скидка: {discount}%");
        Console.WriteLine($"К оплате: {finalPrice}");
    }

    //  ЗАДАНИЕ 9 
    static void Task9()
    {
        Console.Write("Введите час (0–23): ");
        int hour = int.Parse(Console.ReadLine());

        if (hour < 0 || hour > 23)
        {
            Console.WriteLine("Ошибка: такого часа не бывает!");
            return;
        }

        if (hour <= 5) Console.WriteLine("Сейчас ночь");
        else if (hour <= 11) Console.WriteLine("Сейчас утро");
        else if (hour <= 17) Console.WriteLine("Сейчас день");
        else Console.WriteLine("Сейчас вечер");
    }

    //  ЗАДАНИЕ 10 
    static void Task10()
    {
        Console.Write("Введите число: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int n))
        {
            Console.WriteLine("Ошибка: введено не число");
            return;
        }

        if (n <= 1)
        {
            Console.WriteLine("Число должно быть больше 1");
            return;
        }

        bool isPrime = true;

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime) Console.WriteLine($"{n} - простое число");
        else Console.WriteLine($"{n} - составное число");
    }
}
