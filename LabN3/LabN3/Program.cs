using System.Diagnostics;
using System.Linq.Expressions;

numoperations();
void numoperations()
{
    Console.WriteLine("Введите число больше 0");
    bool validation = int.TryParse(Console.ReadLine(), out int number);
    if (validation == true && number > 0)
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
                Console.WriteLine();
                Console.WriteLine(Factorio(number));
                break;
            case ConsoleKey.D2:
                Console.WriteLine();
                Console.WriteLine(Fibonachi(number));
                break;
            default:
                operselection();
                break;
        }
        int Factorio(int number)
        {
            int resFact = 1;
            for (int i = 1; i <= number; i++)
            {
                resFact *= i;
            }
            return resFact;
        }
        int Fibonachi(int number)
        {
            if (number == 1 || number == 2) return number - 1;
            return Fibonachi(number - 1) + Fibonachi(number - 2);
        }
    }
}
