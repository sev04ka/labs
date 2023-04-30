using System.Linq.Expressions;

Random random = new Random();
int[] array = new int[10];
int summ = 0;
int summ2 = 0;
int productOfNUms = 1;

SelectOperation();

void FillArray() 
{
    Console.WriteLine("Массив заполнен случайными числами.");
    for (int i = 0; i < array.Length; i++)
        array[i] = random.Next(1, 10);
    SelectOperation();
}

void PrintArray() 
{
    Console.WriteLine("Ваш массив:");
    foreach (int i in array) 
        Console.Write($"{i}  ");
    Console.WriteLine();
    SelectOperation();
}

void AvgAryphmetic() 
{
    foreach (int i in array)
        summ += i;
    Console.WriteLine($"Среднее арифметическое: \n {Convert.ToDouble(summ) / array.Length}");
    SelectOperation();
}

void AvgGeometric()
{
    foreach (int i in array) 
        productOfNUms *= i;
    Console.WriteLine($"Среднее геометрическое: \n {Math.Pow(Convert.ToDouble(productOfNUms), 1.0 / Convert.ToDouble(array.Length))}");
    SelectOperation();
}

void AvgSquare()
{
    foreach (int i in array)
        summ2 += i * i;
    Console.WriteLine($"Среднее квадратичное: \n {Math.Pow(Convert.ToDouble(summ2) / array.Length, 1.0 / 2.0)}");
    SelectOperation();
}

void SelectOperation() 
{
    Console.WriteLine("Чтобы посмотерть массив, нажмите 1 \n Чтобы заполнить массив случайными числами, нажмите 2 \n Чтобы получить среднее арифметические элементов массива, нажмите 3 \n Чтобы получить среднее геометрическое элементов массива, нажмите 4 \n Чтобы получить среднее квадратичное элементов массива, нажмите 5 \n Чтобы выйти нажмите любую клавишу");
    var keyInput = Console.ReadKey().Key;
    Console.WriteLine();
    switch (keyInput) 
    {
        case ConsoleKey.D1:
            PrintArray();
            break;
        case ConsoleKey.D2:
            FillArray();
            break;
        case ConsoleKey.D3:
            AvgAryphmetic();
            break;
        case ConsoleKey.D4:
            AvgGeometric();
            break;
        case ConsoleKey.D5:
            AvgSquare();
            break;
        default:
            Environment.Exit(0);
            break;
    }
}