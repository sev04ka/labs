using System.Numerics;

int columns = 0;
int rows = 0;

SelectSize();

void SelectSize() {

    Console.WriteLine("Введите число колонок матриц");
    if (int.TryParse(Console.ReadLine(), out int columnsInput))
        columns = columnsInput;
    else  
        SelectSize();

    Console.WriteLine("Введите число строк матриц");
    if (int.TryParse(Console.ReadLine(), out int rowsInput))
        rows = rowsInput;
    else
        SelectSize(); 
}

int[,] matrix1 = new int[columns, rows];
int[,] matrix2 = new int[columns, rows];
int[,] matrixResult = new int[columns, rows];
MatrixInput();
void MatrixInput() {
    

    Console.WriteLine("Введите значения элементов матрицы 1");
    
    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            if (int.TryParse(Console.ReadLine(), out int matrixNum))
                matrix1[i, j] = matrixNum;
            else
                MatrixInput();
        }
    }

    Console.WriteLine("Введите значения элементов матрицы 2");

    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            if (int.TryParse(Console.ReadLine(), out int matrixNum))
                matrix2[i, j] = matrixNum;
            else
                MatrixInput();
        }
    }

    Console.WriteLine("Матрица 1");
    Console.WriteLine();

    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            Console.Write($"{matrix1[i, j]}  ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine("Матрица 2");
    Console.WriteLine();

    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            Console.Write($"{matrix2[i, j]}  ");
        }
        Console.WriteLine();
    }
    SelectOperation();
}

void SelectOperation() {
    Console.WriteLine("Чтобы сложить матрицы, нажмите 1 \n Чтобы вычесть вторую матрицу из первой, нажмите 2");
    var keyInput = Console.ReadKey().Key;
    int multiplier = 0;
    switch (keyInput) {
        case ConsoleKey.D1:
            multiplier = 1;
            break;
        case ConsoleKey.D2:
            multiplier = -1;
            break;
        default:
            SelectOperation();
            break;
    }
    Console.WriteLine();
    MatrixOperation(multiplier);

}

void MatrixOperation(int multipier) { 
    for (int i = 0;i < columns;i++)
    {
        for (int j = 0; j < rows; j++) {
            matrixResult[i, j] = matrix1[i, j] + multipier * matrix2[i, j];      
        }
    }

    Console.WriteLine("Результат операции");
    Console.WriteLine();

    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            Console.Write($"{matrixResult[i, j]}  ");
        }
        Console.WriteLine();
    }
}