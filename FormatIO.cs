
using System;

class FormatIO
{
    public int GetTryInt(string str)
    {
        Console.WriteLine(str);
        Console.SetCursorPosition(str.Length + 1, Console.CursorTop - 1);
        bool err = Int32.TryParse(Console.ReadLine(), out int num);
        while(!err)
        {
            Console.WriteLine($"Введено не число Int32. Попробуй еще раз");
            Console.WriteLine(str);
            Console.SetCursorPosition(str.Length + 1, Console.CursorTop - 1);
            err = Int32.TryParse(Console.ReadLine(), out num);
        }
        return num;
    }
    public float GetTryFloat(string str)
    {
        Console.WriteLine(str);
        Console.SetCursorPosition(str.Length + 1, Console.CursorTop - 1);
        string strNorm = Console.ReadLine();
        strNorm = strNorm.Replace('.', ',');
        bool err = float.TryParse(strNorm, out float num);
        while (!err)
        {
            Console.WriteLine($"Введено не число Int32. Попробуй еще раз");
            Console.WriteLine(str);
            Console.SetCursorPosition(str.Length + 1, Console.CursorTop - 1);
            strNorm = Console.ReadLine();
            strNorm = strNorm.Replace('.', ',');
            err = float.TryParse(strNorm, out num);
        }
        return num;
    }
    public string GetString(string str)
    {
        Console.WriteLine(str);
        Console.SetCursorPosition(str.Length + 1, Console.CursorTop - 1);
        return Console.ReadLine();
    }
    public void TextTask(string str)
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - str.Length / 2, Console.WindowHeight / 2);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(str.ToUpper());
        Console.ReadKey();
        Console.ResetColor();
        Console.Clear();
    }
}

