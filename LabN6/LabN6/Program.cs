using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

Random random = new Random();
Stopwatch stopWatch = new Stopwatch();
int[] startArray = new int[10000];
int[] sortedArray = new int[10000];
int temp = 0;

SelectOperation();

void PrintArray(int[] printedArray)
{
    Console.WriteLine();
    foreach (int i in printedArray)
        Console.Write($"{i}  ");
    Console.WriteLine();
}

void FillArray() 
{
    for (int i = 0; i < startArray.Length; i++)
        startArray[i] = random.Next(1, 10000);
}

int[] QuickSort( int[] array, int minIndex, int maxIndex) 
{
    if (minIndex >= maxIndex) 
        return array;

    int pivotIndex = minIndex - 1;

    for (int i = minIndex; i <= maxIndex; i++) 
    {
        if (array[i] < array[maxIndex])
        {
            pivotIndex++;
            int temp = array[i];
            array[i] = array[pivotIndex];   
            array[pivotIndex] = temp;
        }
    }

    pivotIndex++;
    temp = array[pivotIndex];
    array[pivotIndex] = array[maxIndex];
    array[maxIndex] = temp;


    QuickSort( array, minIndex, pivotIndex - 1 );
    QuickSort( array, pivotIndex + 1, maxIndex );

 
    return array;
}

void ShowSorted() 
{
    Console.WriteLine("Исходный массив:");
    PrintArray(startArray);


    stopWatch.Start();
    sortedArray = QuickSort(startArray, 0, startArray.Length - 1);
    stopWatch.Stop();


    Console.WriteLine("Отсортированный массив:");
    PrintArray(sortedArray);

    TimeSpan ts = stopWatch.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds);
    Console.WriteLine("Время сортировки:");
    Console.WriteLine(elapsedTime);

}


void SelectOperation() 
{
    Console.WriteLine("Нажмите 1, чтобы заполнить массив случайными числами и отсортировтаь его");
    var keyInput = Console.ReadKey().Key;
    Console.WriteLine();
    switch (keyInput) {
        case ConsoleKey.D1:
            FillArray();
            ShowSorted();
            break;
        default:
            Environment.Exit(0);
            break;
    }
}
