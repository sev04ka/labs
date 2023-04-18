

using Microsoft.VisualBasic;
using System;

bool hasTorch = false;
bool hasKey = false;
bool[] roomsPassed = {false, false}; 

void StartQuest() {
    Console.WriteLine("Нажмите любую кнопку для начала квеста");
    Console.WriteLine("Нажмите Escape для выхода");
    for (int i = 0; i < roomsPassed.Length; i++)
    {
        roomsPassed[i] = false;
    }
    hasTorch = false;
    hasKey = false;
    var keyInput = Console.ReadKey().Key;
    switch (keyInput)
    {
        case ConsoleKey.Escape:
            Environment.Exit(0);
            break;  
        default:
            StartText();
            StartRoom();
            break;
    }

}


StartQuest();

void StartText() {
    Console.WriteLine();
    Console.WriteLine("Вы очнулись в комнате с тусклым освещением, вероятно вы под землей.");
    Console.WriteLine("Вы осмотрелись и видите 2 прохода");
}
void StartRoom() 
{
    Console.WriteLine("Нажмите 1, чтобы войти в первую комнату");
    Console.WriteLine("Нажмите 2, чтобы войти во вторую комнату");
    var roomInput1 = Console.ReadKey().Key;
    switch (roomInput1)
    {
        case ConsoleKey.D1:
            Console.WriteLine("");
            FirstRoom(ref hasTorch, ref roomsPassed);
            break;
        case ConsoleKey.D2:
            Console.WriteLine("");
            SecondRoom();
            break;
        default:
            Console.WriteLine("");
            StartRoom();
            break;
    }
}


void FirstRoom(ref bool hasTorch, ref bool[] rooms) 
{
    if (roomsPassed[0] == false)
    {
        if (hasTorch == false)
        {
            Console.WriteLine("Здесь слишком тенмо, нужно вернуться назад");
            StartRoom();
        }
        else {
            Console.WriteLine("В комнате, освещённой светом факела, вы видите странную записку, в которой написано: `Чтобы прыгнуть и хлопнуть в ладоши нажмите: N`");
            Console.WriteLine("Вы вернулись в стартовую комнату");
            roomsPassed[0] = true;
            StartRoom();
        }
    }
    else {
        Console.WriteLine("В этой комнате больше нечего делать");
        StartRoom();
    }
}

void SecondRoom()
{
    Console.WriteLine("В этой комнате еще одна развилка");
    Console.WriteLine("Нажмите 1, чтобы войти в третью комнату");
    Console.WriteLine("Нажмите 2, чтобы войти в четвёртую комнату");
    Console.WriteLine("Нажмите 3, чтобы вернуться в стартовую комнату");
    var roomInput2 = Console.ReadKey().Key;
    switch (roomInput2)
    {
        case ConsoleKey.D1:
            Console.WriteLine("");
            ThirdRoom();
            break;
        case ConsoleKey.D2:
            Console.WriteLine("");
            FourthRoom();
            break;
        case ConsoleKey.D3:
            StartRoom();
            break;
        default:
            Console.WriteLine("");
            SecondRoom();
            break;
    }
}

void ThirdRoom()
{
    Console.WriteLine("В этой комнате вы видите висящий на стене факел и подъём наверх с дверью в конце");
    Console.WriteLine("Нажмите A, чтобы попробовать открыть дверь");
    Console.WriteLine("Нажмите S, чтобы взять факел");
    Console.WriteLine("Нажмите D, чтобы вернуться во вторую комнату");

    WhatToDo1();
    void WhatToDo1() {
        var yourDecission1 = Console.ReadKey().Key;
        switch (yourDecission1)
        {
            case ConsoleKey.A:
                Console.WriteLine();
                if (hasKey)
                {
                    Console.WriteLine("Дверь открылась!");
                    FinishRoom();
                }
                else {
                    Console.WriteLine("К сожалению дверь закрыта");
                    WhatToDo1();
                }
                break;
            case ConsoleKey.S:
                Console.WriteLine();
                Console.WriteLine("Теперь у вас есть факел!");
                TakeTorch(ref hasTorch);
                break;
            case ConsoleKey.D:
                Console.WriteLine();
                Console.WriteLine("Вы вернулись во вторую комнату");
                SecondRoom();
                break;

        }

    }
    void TakeTorch(ref bool hasTorch) { 
        hasTorch = true;
        WhatToDo1();
    }

    
}

void FourthRoom()
{
    if (roomsPassed[1] == false)
    {
        Console.WriteLine("Эта комната является тупиком, а в её углу стоит странное гуманоидное существо");
        Console.WriteLine("Оно тяжело дышит и выглядит опасно, на его шее висит верёвка с каким-то ключом");
        Console.WriteLine("Нажмите Z, чтобы осмотреть существо");
        Console.WriteLine("Нажмите X, чтобы попробовать отобрать ключ");
        Console.WriteLine("Нажмите C, чтобы вернуться во вторую комнату");
        Console.WriteLine("Возможно есть что-то еще...");
        WhatToDo2();
        void WhatToDo2()
        {
            var yourDecission2 = Console.ReadKey().Key;
            switch (yourDecission2)
            {
                case ConsoleKey.Z:
                    Console.WriteLine();
                    Console.WriteLine("Существо никак не реагирует на меня, возможно получится забрать ключ?");
                    WhatToDo2();
                    break;
                case ConsoleKey.X:
                    Console.WriteLine();
                    Console.WriteLine("Существо резко дёрнулось дало вам леща и сломало колени");
                    Death();
                    break;
                case ConsoleKey.C:
                    Console.WriteLine();
                    Console.WriteLine("Вы вернулись во вторую комнату");
                    SecondRoom();
                    break;
                case ConsoleKey.N:
                    Console.WriteLine();
                    Console.WriteLine("Вы прыгнули и хлопнули в ладоши, а существо положило ключ на пол");
                    TakeKey(ref hasKey, ref roomsPassed);
                    break;
                default:
                    WhatToDo2();
                    break;
            }
        }
        void TakeKey(ref bool hasKey, ref bool[] rooms)
        {
            Console.WriteLine("Вы подобрали ключ и благополучно покинули комнату");
            hasKey = true;
            roomsPassed[1] = true;
            SecondRoom();
        }
    }
    else {
        Console.WriteLine("Здесь больше нечего делать");
        SecondRoom();
    }
}

void FinishRoom()
{
    Console.WriteLine("Вы успешно выбрались, поздравляю!");
    StartQuest();
}

void Death() 
{
    Console.WriteLine("Вы мертвы");
    StartQuest();
}