using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

// Сарвилин Владимир

class Task_6
{
    public void Main()
    {
        //Задание 1

        // делегат с одним параметром
        Console.WriteLine("Таблица функции MyFunc:");
        Functions.Table(new Fun(Functions.MyFunc), -2, 2);
        Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
        Functions.Table(Functions.MyFunc, -2, 2);
        Console.WriteLine("Таблица функции sin:");
        Functions.Table(Math.Sin, -2, 2);
        Console.WriteLine("Таблица функции x^2:");
        Functions.Table(delegate (double x) { return x * x; }, 0, 3);
        // делегат с двумя параметрами
        Console.WriteLine("Таблица функции a*x^2:");
        NewFun fx = delegate (double x, double c) { return c * x * x; };
        Functions.NewTable(fx, 0, 2, 3);
        Console.WriteLine("Таблица функции a*sin(x):");
        Functions.NewTable(Functions.NewMyFunc, -2, 2, 2);
        Console.WriteLine("Таблица функции x^a:");
        Functions.NewTable(Math.Pow, -2, 2, 2);
        Console.ReadKey();

        Console.Clear();

        // Задание 2

        Console.WriteLine("Из следующего набора функций, выбирете одну, указав ее номер:");
        Console.WriteLine("1. Sqrt(x)\n2. x^2 + 50x +10\n3. e^x\n4. Sin(x)\n5. Log10(x)");
        int keyInput = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите на каком отрезке [A,B] хотите построить функцию:");
        Console.WriteLine("Введите А:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите B:");
        double b = double.Parse(Console.ReadLine());

        Minimum.SaveFunc("data.bin", a, b, keyInput);

        Console.WriteLine("Введите на каком отрезке [A,B] хотите найти миниуму выбранной функции:");
        Console.WriteLine("Введите А:");
        double minA = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите B:");
        double minB = double.Parse(Console.ReadLine());

        if (minA > minB)
        {
            double c = minB;
            minB = minA;
            minA = c;
        }

        Minimum.Load("data.bin", minA, minB, out double min);
        Console.WriteLine($"Минимум функции равен {min}");
        Console.ReadKey();

        Console.Clear();

        // Задание 3

        int bakalavr = 0;
        int magistr = 0;
        List<Student> list = new List<Student>();                             // Создаем список студентов
        DateTime dt = DateTime.Now;
        StreamReader sr = new StreamReader("Students.csv", Encoding.GetEncoding(1251));
        while (!sr.EndOfStream)
        {
            try
            {
                string[] s = sr.ReadLine().Split(';');
                // Добавляем в список новый экземпляр класса Student
                list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                // Одновременно подсчитываем количество бакалавров и магистров
                if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                // Выход из Main
                if (Console.ReadKey().Key == ConsoleKey.Escape) return;
            }
        }
        sr.Close();
        list.Sort(new Comparison<Student>(MyDelegat));
        Console.WriteLine("Всего студентов:" + list.Count);
        Console.WriteLine("Магистров:{0}", magistr);
        Console.WriteLine("Бакалавров:{0}", bakalavr);
        foreach (var v in list) Console.WriteLine(v.firstName);
        //считаем сколько на каждом курсе студентов от 18 до 20 лет
        for (int i = 1; i < 7; i++)
        {
            Console.WriteLine($"На {i} курсе {list.FindAll(x => x.age >= 18 && x.age <= 20).FindAll(match: y => y.course == i).Count} студент(ов) от 18 до 20 лет");
        }
        //Сортируем по возрасту
        list.Sort(new Comparison<Student>(MyDelegatAge));
        foreach (var v in list) Console.WriteLine($"{v.firstName,10} {v.lastName,25} {v.course,10} {v.age,10}");
        //Сортируем по курсу и возрасту
        list.Sort(new Comparison<Student>(MyDelegatCourse));
        foreach (var v in list) Console.WriteLine($"{v.firstName,10} {v.lastName,15} {v.course,10} {v.age,10}");
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadKey();

        //Задание 4

        long kbyte = 1024;
        long mbyte = 1024 * kbyte;
        long gbyte = 1024 * mbyte;
        long size = mbyte;

        Console.WriteLine("FileStream. Milliseconds:{0}", FileStreamSample("..\\bigdata0.bin", size));
        Console.WriteLine("BinaryStream. Milliseconds:{0}", BinaryStreamSample("..\\bigdata1.bin", size));
        Console.WriteLine("StreamWriter. Milliseconds:{0}", StreamWriterSample("..\\bigdata2.bin", size));
        Console.WriteLine("BufferedStream. Milliseconds:{0}", BufferedStreamSample("..\\bigdata3.bin", size));

        Console.ReadKey();

        Console.WriteLine("LoadFileStream:");
        for (long i = 0; i < size / 1024; i++)
        {
            Console.Write(LoadFileStreamSample("..\\bigdata0.bin", size)[i]);
        }
        Console.WriteLine();

        Console.WriteLine("LoadBinaryStream:");
        for (long i = 0; i < size / 1024; i++)
        {
            Console.Write(LoadBinaryStreamSample("..\\bigdata1.bin", size)[i]);
        }
        Console.WriteLine();

        Console.WriteLine("LoadStreamWriter:");
        Console.WriteLine(LoadStreamWriterSample("..\\bigdata2.bin"));

        Console.WriteLine();

        Console.WriteLine("LoadBufferedStream:");
        for (long i = 0; i < size/1024; i++)
        {
            Console.Write(LoadBufferedStreamSample("..\\bigdata3.bin", size)[i]);
        }
        Console.WriteLine();

        Console.ReadKey();
    }

    //Задание 1

    //Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
    //Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

    public delegate double Fun(double x);
    public delegate double NewFun(double a, double x);
    class Functions

    {
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine($"| {x,8:0.000} | {F(x),8:0.000} |");
                x++;
            }
            Console.WriteLine("---------------------");
        }
        public static void NewTable(NewFun F, double x, double a, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine($"| {x,8:0.000} | {F(x, a),8:0.000} |");
                x++;
            }
            Console.WriteLine("---------------------");
        }
        public static double MyFunc(double x)
        {
            return x * x * x;
        }
        public static double NewMyFunc(double x, double a)
        {
            Fun fun = new Fun(Math.Sin);
            return a * fun(x);

        }
    }


    //Задание 2

    //Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
    //а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке 
    //находить минимум.Использовать массив(или список) делегатов, в котором хранятся различные функции.
    //б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум через параметр (с использованием модификатора out). 
    class Minimum
    {

        public delegate double FuncX(double x);


        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static void SaveFunc(string fileName, double a, double b, int i)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            FuncX[] del_ = new FuncX[]
            {
                Math.Sqrt, F, Math.Exp, Math.Sin, Math.Log10
            };
            while (x <= b)
            {
                Console.WriteLine($"{del_[i - 1](x)}");
                bw.Write(del_[i - 1](x));
                x++;
            }
            bw.Close();
            fs.Close();
        }
        public static void Load(string fileName, double minA, double minB, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d >= minA && d <= minB)
                {
                    if (d < min) min = d;
                }
            }
            bw.Close();
            fs.Close();
        }
    }

    // Задание 3

    //Переделать программу Пример использования коллекций для решения следующих задач:
    //а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    //б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
    //в) отсортировать список по возрасту студента;
    //г) *отсортировать список по курсу и возрасту студента;

    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.age = age;
            this.course = course;
            this.group = group;
            this.city = city;
        }
    }

    static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
    {

        return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки

    }
    static int MyDelegatAge(Student st1, Student st2)
    {

        return String.Compare(st1.age.ToString(), st2.age.ToString());

    }
    static int MyDelegatCourse(Student st1, Student st2)         
    {
        return String.Compare(st1.course.ToString() + st1.age.ToString(), st2.course.ToString() + st2.age.ToString());          

    }
    //Задание 4

    //**Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. 
    //Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), строку для StreamReader и массив int для BinaryReader.

    static long FileStreamSample(string filename, long size)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
        //FileStream fs = new FileStream("D:\\temp\\bigdata.bin", FileMode.CreateNew, FileAccess.Write);
        for (int i = 0; i < size; i++)
            fs.WriteByte(0);
        fs.Close();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long BinaryStreamSample(string filename, long size)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        for (int i = 0; i < size; i++)
            bw.Write((byte)0);
        fs.Close();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long StreamWriterSample(string filename, long size)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        for (int i = 0; i < size; i++)
            sw.Write("Hello");
        fs.Close();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    static long BufferedStreamSample(string filename, long size)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
        int countPart = 4;//количество частей
        int bufsize = (int)(size / countPart);
        byte[] buffer = new byte[size];
        BufferedStream bs = new BufferedStream(fs, bufsize);
        //bs.Write(buffer, 0, (int)size);//Error!
        for (int i = 0; i < countPart; i++)
            bs.Write(buffer, 0, (int)bufsize);
        fs.Close();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
    static byte[] LoadFileStreamSample(string filename, long size)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        byte[] arrayByte = new byte[size / 1024];
        for (long i = 0; i < size / 1024; i++)
        {
            arrayByte[i] = (byte)fs.ReadByte();
        }
        fs.Close();
        stopwatch.Stop();
        return arrayByte;
    }
    static int[] LoadBinaryStreamSample(string filename, long size)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        BinaryReader bw = new BinaryReader(fs);
        long n = size / 1024;
        int[] arrayInt = new int[size / 1024];
        for (long i = 0; i < n; i++)
            arrayInt[i] = bw.ReadByte();
        fs.Close();
        stopwatch.Stop();
        return arrayInt;
    }
    static string LoadStreamWriterSample(string filename)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        string s = sr.ReadLine();
        //for (int i = 1; i < 10; i++)
        //    s += sr.Read();
        fs.Close();
        stopwatch.Stop();
        return s;
    }

    static byte[] LoadBufferedStreamSample(string filename, long size)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        int countPart = 4;//количество частей
        int bufsize = (int)(size / countPart);
        byte[] buffer = new byte[size];
        byte[] arrayByte = new byte[buffer.Length];
        BufferedStream bs = new BufferedStream(fs, bufsize);
        //bs.Write(buffer, 0, (int)size);//Error!
        for (int i = 0; i < countPart; i++)
            bs.Read(arrayByte, 0, (int)bufsize);
        fs.Close();
        stopwatch.Stop();
        return arrayByte;
    }
}
