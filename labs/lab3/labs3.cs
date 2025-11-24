using System;

class Program
{
    static void Main()
    {
        
        
        
        Console.WriteLine("Задание 1");
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();
        Console.Write("Введите возраст: ");
        int age = int.Parse(Console.ReadLine());

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Меня зовут {name} и мне {age} лет");
        }

        Console.WriteLine("\n---------------------------\n");

        


        Console.WriteLine("Задание 2");
        int num;
        do
        {
            Console.Write("Введите число от 1 до 9: ");
            num = int.Parse(Console.ReadLine());
        } while (num < 1 || num > 9);

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{num} x {i} = {num * i}");
        }

        Console.WriteLine("\n---------------------------\n");

        


        Console.WriteLine("Задание 3");
        for (int i = 0; i <= 100; i += 3)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n---------------------------\n");

        


        Console.WriteLine("Задание 4");
        Console.Write("Введите число для факториала: ");
        int factNum = int.Parse(Console.ReadLine());
        long factorial = 1;
        for (int i = 1; i <= factNum; i++)
        {
            factorial *= i;
        }
        Console.WriteLine($"Факториал {factNum}! = {factorial}");

        Console.WriteLine("\n---------------------------\n");

       


        Console.WriteLine("Задание 5");
        int count = 20;
        while (count >= 0)
        {
            Console.Write(count + " ");
            count--;
        }
        Console.WriteLine("\n---------------------------\n");

        


        Console.WriteLine("Задание 6");
        Console.Write("Введите число для последовательности Фибоначчи: ");
        int fibLimit = int.Parse(Console.ReadLine());
        int a = 0, b = 1;
        Console.Write(a + " " + b + " ");
        while (true)
        {
            int next = a + b;
            if (next > fibLimit) break;
            Console.Write(next + " ");
            a = b;
            b = next;
        }
        Console.WriteLine("\n---------------------------\n");

        


        Console.WriteLine("Задание 7");
        Console.Write("Введите строку: ");
        string inputStr = Console.ReadLine();
        string newStr = "";
        for (int i = 0; i < inputStr.Length; i++)
        {
            newStr += inputStr[i] + (i + 1).ToString();
        }
        Console.WriteLine("Результат: " + newStr);

        Console.WriteLine("\n---------------------------\n");

        


        Console.WriteLine("Задание 8");
        while (true)
        {
            Console.Write("Введите два числа через пробел: ");
            string[] parts = Console.ReadLine().Split();
            if (parts.Length != 2)
            {
                Console.WriteLine("Ошибка: нужно ввести ровно два числа");
                continue;
            }
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            Console.WriteLine($"Сумма равна: {x + y}");
        }
    }
}
