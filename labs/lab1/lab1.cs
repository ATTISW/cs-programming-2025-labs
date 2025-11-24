int number = 10;
float price = 12.5f;
string text = "Hello";
bool isActive = true;

string name = "Иван";
int age = 20;

Console.WriteLine(name);
Console.WriteLine(age);

int a1 = 342;
double a2 = 56.2;
string a3 = "43";

double sum = a1 + a2 + double.Parse(a3);
Console.WriteLine(sum);

int a = 3;
int b = 8;

int result = (a + 4 * b) * (a - 3 * b) + a * a;
Console.WriteLine(result);

Console.Write("Введите сторону A: ");
double A = double.Parse(Console.ReadLine());

Console.Write("Введите сторону B: ");
double B = double.Parse(Console.ReadLine());

double area = A * B;
double perimeter = 2 * (A + B);

Console.WriteLine("Площадь: " + area);
Console.WriteLine("Периметр: " + perimeter);


Console.WriteLine("*   *   *");
Console.WriteLine(" * * * *");
Console.WriteLine("  *   *");

int x = 10;
int y = 4;

Console.WriteLine(x + y);
Console.WriteLine(x - y);
Console.WriteLine(x * y);
Console.WriteLine(x / y);
Console.WriteLine(x % y);
Console.WriteLine(++x);
Console.WriteLine(--y);

Console.WriteLine(x > y);
Console.WriteLine(x < y);
Console.WriteLine(x >= y);
Console.WriteLine(x <= y);
Console.WriteLine(x == y);
Console.WriteLine(x != y);

string myName = "Иван";
int myAge = 20;

Console.WriteLine($"Меня зовут {myName}, мне {myAge} лет.");

string p1 = "Съешь еще";
string p2 = "этих мягких";
string p3 = "французских булок,";
string p4 = "да выпей";
string p5 = "чаю";

string sentence = p1 + " " + p2 + " " + p3 + " " + p4 + " " + p5;
Console.WriteLine(sentence);

string phrase = "Нет! Да!";
string result10 = phrase + phrase + phrase + phrase;
Console.WriteLine(result10);

Console.Write("Введите 3 числа через запятую: ");
string[] nums = Console.ReadLine().Split(',');

int n1 = int.Parse(nums[0]);
int n2 = int.Parse(nums[1]);
int n3 = int.Parse(nums[2]);

int result11 = (n1 + n3) / n2;

Console.WriteLine($"Результат вычисления: {result11}");

Console.Write("Введите слово (минимум 10 символов): ");
string word = Console.ReadLine();

Console.WriteLine(word.Substring(0, 4));              // первые 4
Console.WriteLine(word.Substring(word.Length - 2));  // последние 2
Console.WriteLine(word.Substring(3, 5));             // с 4 по 8
Console.WriteLine(new string(word.Reverse().ToArray())); // переворот
