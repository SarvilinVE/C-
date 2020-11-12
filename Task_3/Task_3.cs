using System;

//Сарвилин Владимир
class Task_3
    {
        public void Main() 
        {

        // б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
        // в) Добавить диалог с использованием switch демонстрирующий работу класса.

        int keyInput;
        Complex complex1 = new Complex(1, 1);
        Complex complex2 = new Complex(2, 2);
        do
        {
            Console.WriteLine("Выбирите действие, которое хотите произвести с комплексными числами 1+1i и 2+2i(для выхода нажмите 0)");
            Console.WriteLine("1.Сложение");
            Console.WriteLine("2.Произведение");
            Console.WriteLine("3.Вычитание");
            keyInput = Int32.Parse(Console.ReadLine());
            switch (keyInput)
            {
                case 1:
                    Console.WriteLine($"Сумма комплексных чисел: {complex1.Plus(complex2).ToString()}");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine($"Произведение комплексных чисел равно: {complex1.Multi(complex2).ToString()}");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine($"Разница комплексных чисел равна: {complex1.Minus(complex2).ToString()}");
                    Console.ReadKey();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Введено не верное значение. Попробуйте еще раз...");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
        } while (keyInput != 0);

        // а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
        // Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse.

        string s = "";
        Odd odd1 = new Odd();
        Console.WriteLine("Вводите целые числа через <Enter>.\nПрограмма подсчитает сумму положительных нечетных чисел.\nДля выхода нажмите <0>");
        keyInput = odd1.IntTryParse(Console.ReadLine());
        odd1.X = keyInput;

        while (keyInput != 0)
        {
            odd1.SumOdd(odd1.X);
            if (odd1.X != 0)
            {
                s = odd1.StringOdd(odd1.X);
            }
            keyInput = odd1.IntTryParse(Console.ReadLine());
            odd1.X = keyInput;
        }
        Console.WriteLine($"Сумма последовательности нечетных положительных чисел {s} равна {odd1.ToStringOdd()}");
        Console.ReadKey();
        Console.Clear();

        //*Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
        // Написать программу, демонстрирующую все разработанные элементы класса.
        //*Добавить свойства типа int для доступа к числителю и знаменателю;
        //*Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
        //**Добавить проверку, чтобы знаменатель не равнялся 0.Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
        //***Добавить упрощение дробей.

        Console.WriteLine("Рассмотрим работу с рациональными дробями");
        Fraction fraction1 = new Fraction();
        Console.WriteLine("введите числитель первой дроби:");
        fraction1.Numerator = fraction1.IntTryParse(Console.ReadLine());
        
        do
        {
            Console.WriteLine("Введите знаменатель дроби(он не должен быть равным 0):");
            try
            {
                fraction1.Denomenator = fraction1.IntTryParse(Console.ReadLine());
                int ex = fraction1.Numerator / fraction1.Denomenator;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Знаменатель не должен быть равным 0.");
            }
        } while (fraction1.Denomenator == 0);
        
        Fraction fraction2 = new Fraction();
        Console.WriteLine("введите числитель второй дроби:");
        fraction2.Numerator = fraction2.IntTryParse(Console.ReadLine());
        
        do
        {
            Console.WriteLine("Введите знаменатель дроби(он не должен быть равным 0):");
            try
            {
                fraction2.Denomenator = fraction2.IntTryParse(Console.ReadLine());
                int ex = fraction2.Numerator / fraction2.Denomenator;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Знаменатель не должен быть равным 0.");
            }
        } while (fraction2.Denomenator == 0);

        Console.Clear();

        Console.WriteLine("Результат введенных данных:");
        Console.WriteLine($"{"Числитель"}{"Знаменатель",10}{"Дробный вид",10}{"Десятичный вид",10}");
        Console.WriteLine(fraction1.ShowFraction());
        Console.WriteLine(fraction2.ShowFraction());

        Console.WriteLine("Сумма дробей:");
        Console.WriteLine(fraction1.Plus(fraction2).ShowFraction());
        Console.WriteLine("Вычитание дробей:");
        Console.WriteLine(fraction1.Minus(fraction2).ShowFraction());
        Console.WriteLine("Произведение дробей:");
        Console.WriteLine(fraction1.Multi(fraction2).ShowFraction());
        Console.WriteLine("Деление дробей:");
        Console.WriteLine(fraction1.Division(fraction2).ShowFraction());
        Console.ReadKey();
        }
    }

// класс комплексных чисел
class Complex
{
    double re;
    double im;

    public Complex()
    {
        im = 0;
        re = 0;
    }

    public Complex(double _im, double _re)
    {
        re = _re;
        im = _im;
    }
    public Complex Plus(Complex x2)
    {
        Complex x3 = new Complex();
        x3.re = re + x2.re;
        x3.im = im + x2.im;
        return x3;
    }
    public Complex Minus(Complex x2)
    {
        Complex x3 = new Complex();
        x3.re = re - x2.re;
        x3.im = im - x2.im;
        return x3;
    }

    public Complex Multi(Complex x2)
    {
        Complex x3 = new Complex()
        {
            re = re * x2.re - im * x2.im,
            im = im * x2.re + re * x2.im 
        };
        return x3;
    }
    public string ToString()
    {
        return $"{re}{(im < 0 ? "-" : "+")}{Math.Abs(im)}i";
    }
}

// класс для работы с нечетными положительными числами
class Odd
{
    int num;
    int sum;
    string strOdd ="";
   
    /// <summary>
    /// Получает на вход строку и определяет, является ли оно целым число Int. 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public int IntTryParse (string str)
    {
        bool flag = Int32.TryParse(str, out int i);
        while (!flag)
        {
            Console.WriteLine("Неверное значение. Попробуйте снова");
            flag = Int32.TryParse(Console.ReadLine(), out i);
        }
        return i;
    }
    public int X
    {
        get { return num; }
        set
        {
            if (value % 2 != 0 && value > 0)
            {
                num = value;
            }
            else
            {
                num = 0;
            }
        }
    }

    public int SumOdd(int i)
    {
        sum += i;
        return sum;
    }
    public string ToStringOdd()
    {
        return $"{sum}";
    }
    public string StringOdd(int i)
    {
        strOdd += i.ToString()+" ";
        return $"{strOdd}";
    }
}

// класс рациональных дробей
class Fraction
{
    int x;
    int y;
    readonly double decFract;
    public Fraction()
    {
        x = 0;
        y = 1;
    }
    public Fraction(int _x, int _y)
    {
        x = _x;
        y = _y;
        if (x == 0 && y == 0)
        {
            decFract = 0;
        }
        else
        {
            decFract = (double)_x / _y;
        }
    }

    /// <summary>
    /// Знаменатель
    /// </summary>
    public int Denomenator 
    {
        get { return y; }
        set { y = value; }
    }

    /// <summary>
    /// Числитель
    /// </summary>
    public int Numerator
    {
        get { return x; }
        set { x = value; }
    }
    double DecimalFraction  // свойство получения десятичной дроби
    {
        get
        {
            Fraction dec = new Fraction(x, y);
            return dec.decFract;
        }
    }
    
        public Fraction Plus(Fraction fraction1)
    {
        Fraction fraction2 = new Fraction();
        if (y != fraction1.y)
        {
            fraction2.x = fraction1.x * y + x * fraction1.y;
            fraction2.y = y * fraction1.y;
            return fraction2.SimpleFraction(fraction2);
        }
        else
        {
            fraction2.x = fraction1.x + x;
            fraction2.y = y;
            return fraction2.SimpleFraction(fraction2);
        }
    }
    public Fraction Minus(Fraction fraction1)
    {
        Fraction fraction2 = new Fraction();
        if (y != fraction1.y)
        {
            fraction2.x = x * fraction1.y - fraction1.x * y;
            fraction2.y = y * fraction1.y;
            return fraction2.SimpleFraction(fraction2);
        }
        else
        {
            fraction2.x = x - fraction1.x;
            fraction2.y = y;
            return fraction2.SimpleFraction(fraction2);
        }
    }
    public Fraction Multi(Fraction fraction1)
    {
        Fraction fraction2 = new Fraction();
        fraction2.x = x * fraction1.x;
        fraction2.y = y * fraction1.y;
        return fraction2.SimpleFraction(fraction2);
    }
    public Fraction Division(Fraction fraction1)
    {
        Fraction fraction2 = new Fraction();
        if (fraction1.x == 0)
        {
            fraction2.x = 0;
            fraction2.y = 0;
        }
        else
        {
            fraction2.x = x * fraction1.y;
            fraction2.y = y * fraction1.x;
        }
        return fraction2.SimpleFraction(fraction2);
    }
    Fraction SimpleFraction(Fraction fraction)// упрощение дроби
    {
        if (fraction.x == 0) return fraction;
        if (fraction.y == 0) return fraction;
        int d = 2;
        int nod = 1;
        int num1 = Math.Abs(fraction.x);
        int num2 = Math.Abs(fraction.y);

        while(num1 != 1 || num2 != 1)
        {
            if(num1 % d == 0 && num2 % d == 0)
            {
                num1 /= d;
                num2 /= d;
                nod *= d;
            }
            else if (num1 % d == 0)
            {
                num1 /= d;
            }
            else if(num2 % d == 0)
            {
                num2 /= d;
            }
            else
            {
                d++;
            }
        }
        fraction.x /= nod;
        fraction.y /= nod;
        return fraction;
    }
    public int IntTryParse(string str)
    {
        bool flag = Int32.TryParse(str, out int i);
        while (!flag)
        {
            Console.WriteLine("Неверное значение. Попробуйте снова");
            flag = Int32.TryParse(Console.ReadLine(), out i);
        }
        return i;
    }
    public string ShowFraction()
    {
        Fraction dec = new Fraction(x, y);
        if (x == 0)
        {
            return $"{x,5}{y,10}{0,10}{dec.DecimalFraction,10:0.00}";
        }
        else
        {
            return $"{x,5}{y,10}{x,10}/{y}{dec.DecimalFraction,10:0.00}";
        }
    }
}