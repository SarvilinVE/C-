using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

// Сарвилин Владимир

class Task_6
{
    public void Main()
    {
        //Задание 1

        //Console.WriteLine("Таблица функции MyFunc:");
        //Functions.Table(new Fun(Functions.MyFunc), -2, 2);
        //Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
        //Functions.Table(Functions.MyFunc, -2, 2);
        //Console.WriteLine("Таблица функции sin:");
        //Functions.Table(Math.Sin, -2, 2);
        //Console.WriteLine("Таблица функции x^2:");
        //Functions.Table(delegate (double x) { return x * x; }, 0, 3);
        //Console.WriteLine("Таблица функции a*x^2:");
        //Functions.NewTable(delegate (double x, double a) { return a * x * x; }, 0, 2, 3);
        //Console.WriteLine("Таблица функции a*sin(x):");
        //Functions.NewTable(Functions.NewMyFunc, -2, 2, 2);
        //Functions.NewTable(Math.Pow, -2, 2, 2);
        //Console.ReadKey();

        //Console.Clear();

        //Задание 4

        long kbyte = 1024;
        long mbyte = 1024 * kbyte;
        long gbyte = 1024 * mbyte;
        long size = mbyte;
        //Write FileStream
        //Write BinaryStream
        //Write StreamReader/StreamWriter
        //Write BufferedStream

        Console.WriteLine("FileStream. Milliseconds:{0}", FileStreamSample("D:\\temp\\bigdata0.bin", size));
        Console.WriteLine("BinaryStream. Milliseconds:{0}", BinaryStreamSample("D:\\temp\\bigdata1.bin", size));
        Console.WriteLine("StreamWriter. Milliseconds:{0}", StreamWriterSample("D:\\temp\\bigdata2.bin", size));
        Console.WriteLine("BufferedStream. Milliseconds:{0}", BufferedStreamSample("D:\\temp\\bigdata3.bin", size));

        Console.ReadKey();

        Console.WriteLine("LoadFileStream:");
        for (long i = 0; i < size/1024; i++)
        {
            Console.Write(LoadFileStreamSample("D:\\temp\\bigdata0.bin", size)[i]);
        }
        Console.WriteLine();

        Console.WriteLine("LoadBinaryStream:");
        for (long i = 0; i < size / 1024; i++)
        {
            Console.Write(LoadBinaryStreamSample("D:\\temp\\bigdata1.bin", size)[i]);
        }
        Console.WriteLine();

        Console.WriteLine("LoadStreamWriter:");
        Console.WriteLine(LoadStreamWriterSample("D:\\temp\\bigdata2.bin", size));
        
        Console.WriteLine();

        Console.WriteLine("LoadBufferedStream:");
        for (long i = 0; i < size; i++)
        {
            Console.Write(LoadBufferedStreamSample("D:\\temp\\bigdata0.bin", size)[i]);
        }
        Console.WriteLine();

        Console.ReadKey();
    }

    //Задание 1

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

    //Задание 4

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
        byte[] arrayByte = new byte[size/1024];
        for (long i =0; i< size/1024; i++)
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
        long n = size/1024;
        int[] arrayInt = new int[size/1024];
        for (long i = 0; i < n; i++)
            arrayInt[i] = bw.ReadByte();
        fs.Close();
        stopwatch.Stop();
        return arrayInt;
    }
    static string LoadStreamWriterSample(string filename, long size)
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