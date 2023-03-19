using System.Diagnostics;
using System.Linq.Expressions;

void numoperations()
{
    Console.WriteLine("Введите число больше 0");
    string numinput = Console.ReadLine();
    bool validation = int.TryParse(numinput, out int number);
    if (validation = true && number > 0)
    {
        operselection();
    }
    else
    {
        Console.WriteLine("Некорректный ввод");
        numoperations();
    }
    void operselection()
    {
        Console.WriteLine("Нажмите 1 для получения факториала введённого числа");
        Console.WriteLine("Нажмите 2 для получения числа из ряда Фибоначчи с введённым порядковым номером");
        var keycheck = Console.ReadKey().Key;      
        switch (keycheck)
        {
            case ConsoleKey.D1:
                Factorio(number);
                break;
            case ConsoleKey.D2:
                Console.WriteLine();
                Console.WriteLine(Fibonachi(number));
                break;
        }
        void Factorio(int number)
        {
            int resFact = 1;
            for (int i = 1; i <= number; i++)
            {
                resFact *= i;
            }
            Console.WriteLine();
            Console.WriteLine(resFact);
        }
        int Fibonachi(int number)
        {
            if (number == 1 || number == 2 ) return number - 1;
            return Fibonachi(number - 1) + Fibonachi(number - 2);
        }
    }
}
Console.WriteLine("Нажмите enter для начала или esc для закрытия приложения");
var exitstart = Console.ReadKey().Key;
switch (exitstart)
{
    case ConsoleKey.Enter:
        numoperations();
        break;
    case ConsoleKey.Escape:
        Environment.Exit(0);
        break;
}