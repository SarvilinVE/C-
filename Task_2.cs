using System;

class Task_2
    {
    // 1.Написать метод, возвращающий минимальное из трёх чисел.
    //Сарвилин Владимир

    #region

    public FormatIO format = new FormatIO();
    public void MinNumber()
    {
        format.TextTask("1.Написать метод, возвращающий минимальное из трёх чисел.");
        int a = format.GetTryInt("Введите 1-е число:");
        int b = format.GetTryInt("Введите 2-е число:");
        int c = format.GetTryInt("Введите 3-е число:");

        int min = a <= b ? a : b;
        min = min <= c ? min : c;

        //Можно в одну строчку: min = a<=b ? a : b<=c ? b : c

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Наименьшее число из {a}, {b}, {c} будет {min}");
        Console.ResetColor();
        Console.ReadKey();
    }

#endregion

    //2.Написать метод подсчета количества цифр числа.

    #region
    public void CountNumbers()
    {
        format.TextTask("2.Написать метод подсчета количества цифр числа.");
        int a = format.GetTryInt("Введите число:");
        int i = 1;
        int k = a / 10;
        while (k != 0)
        {
            i++;
            k /= 10;
        }
        Console.WriteLine($"В числе {a} количество цифр равно {i}");
        Console.ReadKey();
    }

#endregion

    //3.С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.

    #region
    public void CountOddNumbers()
    {
        format.TextTask("3.Подсчитать сумму всех нечетных положительных чисел.");
        int a = format.GetTryInt("Введите число:");
        int sum = 0;
        while (a != 0)
        {
            if (a % 2 != 0 && a > 0)
            {
                sum += a;
            }

            a = format.GetTryInt("Введите следующее число (для выхода введите 0):");
        }
        Console.WriteLine($"Сумма нечетных положительных чисел равна {sum}");
        Console.ReadKey();
    }

#endregion

    //4.Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
    //  Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
    //  С помощью цикла do while ограничить ввод пароля тремя попытками.

    #region

    public void Access()
    {
        format.TextTask("Для доступа к программам введите логин и пароль");
        int i = 3;
        do
        {
            string login = format.GetString("Введите логин:");
            string pass = format.GetString("Введите пароль:");

            if (Verification(login,pass)) break;

            i--;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Неверный логин или пароль. Попробуйте еще раз, у Вас осталось {i} попытка(и)");
            Console.ResetColor();

        } while (i != 0);

        Console.Clear();

        string access = $"{(i == 0 ? "ДОСТУП ЗАКРЫТ" : "ДОСТУП ПОЛУЧЕН")}";
        Console.SetCursorPosition(Console.WindowWidth / 2 - access.Length / 2, Console.WindowHeight / 2);
        Console.WriteLine(access);
        Console.ReadKey();
        
        if (i == 0) Environment.Exit(0); //В случае не правильного ввода логина и пароля за 3 попытки выходит из консоли.
    }
    static bool Verification(string login, string password)
    {
        string logpass = login + password;
        switch (logpass)
        {
            case "rootGeekBrains":
                return true;
            default:
                return false;
        }
    }

    #endregion

    //5.а)Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
    //  б)*Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

    #region

    
    public void IMT()
    {
        format.TextTask("4.Программа расчета ИМТ \"Худой\\Толстый\"");
        float h = format.GetTryFloat("Введите Ваш рост(м):");
        float m = format.GetTryFloat("Введите Ваш вес(кг):");

        float imt = (m / (h * h));
        WtNorma(imt, h, m);

        Console.ReadKey();
    }
    static void WtNorma(float imt1, float h1, float m1)
    {
        float mMin, mMax, mNormaMin, mNormaMax;
        if (imt1 < 18.5f)
        {
            mNormaMin = 18.5f * h1 * h1;
            mNormaMax = 25f * h1 * h1;
            mMin = mNormaMin - m1;
            mMax = mNormaMax - m1;
            Console.WriteLine($"Ваш ИМТ равен {imt1:0.00}. Вам необходимо набрать от {mMin:0.00} до {mMax:0.00} кг");
        }
        else if (imt1 > 25f)
        {
            mNormaMin = 25f * h1 * h1;
            mNormaMax = 18.5f * h1 * h1;
            mMin = m1 - mNormaMin;
            mMax = m1 - mNormaMax;
            Console.WriteLine($"Ваш ИМТ равен {imt1:0.00}. Вам необходимо скинуть от {mMin:0.00} до {mMax:0.00} кг");
        }
        else
        {
            Console.WriteLine($"Ваш ИМТ равен {imt1:0.00}.Это находится в пределах нормы");
        }
    }

    #endregion

    //6.*Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
    //  «Хорошим» называется число, которое делится на сумму своих цифр. 
    //  Реализовать подсчёт времени выполнения программы, используя структуру DateTime.

    #region

    public void GoodNumbers()
    {
        format.TextTask("5.Программа подсчета количества \"хороших\" чисел") ;
        int begin = format.GetTryInt("Введите число с которого начинать подсчет:");
        int end = format.GetTryInt("Введите число, до которого ведется подсчет:");
        int count = 0;
        int i;

        DateTime start = DateTime.Now;
        for (i = begin; i <= end; i++)
        {
            if (i % SumNumber(i) == 0) count++;
        }
        DateTime finish = DateTime.Now;
        Console.WriteLine("--------с помощью цикла while---------------");
        Console.WriteLine($"Количество \"хороших\" чисел в диапазоне от 1 до {i - 1} равно {count}. Подсчитано за {finish.Second - start.Second} сек.");

        //Тоже самое, только с помощью рекурсии.

        count = 0;
        start = DateTime.Now;
        for (i = begin; i <= end; i++)
        {
            if (i % Recursion(i) == 0) count++;
        }
        finish = DateTime.Now;
        Console.WriteLine("--------с помощью рекурсии---------------");
        Console.WriteLine($"Количество \"хороших\" чисел в диапазоне от 1 до {i - 1} равно {count}. Подсчитано за {finish.Second - start.Second} сек.");

        //С помощью рекурсии подсчет быстрее до 1 000 000, затем рекурсия проигрывает
        Console.ReadKey();
    }
    static int Recursion(int r)
    {
        if (r == 0) return 0;
        return Recursion(r / 10) + r % 10;
    }
    static int SumNumber(int num)
    {
        if (num <= 10) return num;
        int k = num;
        int sum = 0;
        while (k != 0)
        {
            sum += k % 10;
            k /= 10;
        }
        return sum;
    }
    #endregion

    //7.a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
    //  б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.

    #region
    public void NumbersAB()
    {
        format.TextTask("6.Программа реализует вывод на экран чисел от a до b [a < b].");
        int a = format.GetTryInt("Введите число a");
        int b = format.GetTryInt("Введите число b");
        while (b <= a)
        {
            Console.Clear();
            Console.WriteLine($"a = {a}, b = {b} и поэтому b <= a, а это не верно. Попробуйте еще раз");
            a = format.GetTryInt("Введите число a");
            b = format.GetTryInt("Введите число b");
        };

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Последовательность от a до b:");
        AscendingOrder(a, b);
        Console.WriteLine($"Сумма чисел последовательности от {a} до {b} равна {SumNumbers(a, b)}");
        Console.ReadKey();
    }
    static void AscendingOrder(int i, int y)
    {
        if (i > y) return;

        Console.WriteLine($"{i}");
        AscendingOrder(i + 1, y);
    }

    static int SumNumbers(int i, int y)
    {
        if (i == y) return i;
        return SumNumbers(i, y - 1) + y;
    }
    #endregion
}


