using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

//  ***Сарвилин Владимир***
class Task4
{
    public void Main()
    {
        // Задание № 1,2

        Console.WriteLine("Программа, демонстрирующая работу с одномерным массивом");
        Console.WriteLine("1. Формируем одномерный массив размерностью 20.\nЗаполняем его значениями [-10000:10000]:");
        MyArray arr1 = new MyArray();
        arr1.ShowArray("Массив случайных чисел:");
        Console.WriteLine($"Кол-во пар делящихся на 3 в массиве равно {arr1.DivOnNumb()}");
        Console.WriteLine($"Кол-во максимальных значений массива равно {arr1.MaxCount}");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("2. Формируем одномерный массив, заполнив его значениями из файла.\nПуть к файлу \\Properties\\MyArray.txt");
        arr1 = new MyArray("..\\..\\Properties\\MyArray.txt");
        arr1.ShowArray("Массив из файла:");
        Console.WriteLine($"Кол-во максимальных значений массива равно {arr1.MaxCount}");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("3. Формируем массив заданного размера,\nзаполняя его значениями начиная с определенного с заданным шагом");
        Console.WriteLine("Введите размер массива:");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите значение первого элемента массива:");
        int first = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите значение шага:");
        int step = int.Parse(Console.ReadLine());
        MyArray arr2 = new MyArray(size,first,step);
        arr2.ShowArray("Массив с шагом:");
        Console.WriteLine($"Сумма элементов массива равна {arr2.Sum}");
        MyArray arr3 = arr2.Inverse();
        arr3.ShowArray("Изменение знака");
        arr2.Multi(2);
        arr2.ShowArray("Умножение на число");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("4. Выводит массив, в котором отображается элемент и количество его вхождений в заданный массив:");
        arr1.ShowArray("Массив:");
        arr1.DictionaryArray();

        Console.ReadKey();
        Console.Clear();

        // Задание № 3

        Account account = new Account();
        Console.WriteLine("Проверка логина и пароля");
        Console.WriteLine("Введите логин:");
        bool login = account.Login(Console.ReadLine());
        Console.WriteLine("Введите пароль:");
        bool pass = account.Password(Console.ReadLine());
        Console.Clear();
        Console.WriteLine($"{(login && pass ? "Доступ получен" : "В доступе отказано")}");
        Console.ReadKey();
        Console.Clear();

        // Задание № 4

        Console.WriteLine("Программа демонстрирует работу с двумерным массивом");
        Console.WriteLine("1.Формируем двумерный массив на основе данных из файла MyArray.txt и заданной размерности.\nВ случае не хватки значений из файла оставшимся элементам присваивается 0:");
        Matrix2D matrixFile = new Matrix2D(4, 5, "Properties\\MyArray.txt");
        matrixFile.ShowMatrix();
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("2.Формируем массив случайной размерности [[1,10],[1,10]].\nЗаполняется случайными числами [0,100]");
        Random rnd = new Random();
        int col = rnd.Next(1, 11);
        int row = rnd.Next(1, 11);
        Matrix2D matrix = new Matrix2D(col, row, 0, 101);
        matrix.ShowMatrix();
        
        int n = rnd.Next(0, 100);

        Console.WriteLine($"Сумма элиментов: {matrix.Sum()}");
        Console.WriteLine($"Сумма элиментов больше {n}: {matrix.SumToNum(n)}");
        Console.WriteLine($"Максимальный элемент массива: {matrix.Max}");
        matrix.MaxNum(out int x, out int y);
        Console.WriteLine($"Номер максимального элемента массива: ({x},{y})");
        Console.WriteLine($"Минимальный элемент массива: {matrix.Min}");
        Console.WriteLine("3.Выгружаем данный массив в файл");
        matrix.UploadMatrix("Properties\\OutputMatrix.txt");
        Console.ReadKey();
        Process.Start("Properties\\OutputMatrix.txt");
        Console.ReadKey();
    }

    //1.  Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
    //    Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. 
    //    В данной задаче под парой подразумевается два подряд идущих элемента массива.Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
    //2.  а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом.
    //    Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi, умножающий каждый элемент массива
    //    на определенное число, свойство MaxCount, возвращающее количество максимальных элементов.В Main продемонстрировать работу класса.
    //    б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

    class MyArray
    {
        int[] arr;
        public MyArray()
        {
            arr = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 10001) - rnd.Next(0, 10001);
            }
        }
        public MyArray(int n)
        {
            arr = new int[n];
        }
        public MyArray(string filename)
        {
            if (File.Exists(filename))
            {
                string[] str = File.ReadAllLines(filename);
                arr = new int[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    try
                    {
                        arr[i] = int.Parse(str[i]);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Ошибка загрузки файла");
            }
        }
        /// <summary>
        /// Конструктор класса MyArray, заполняющий одномерный массив размерностью size значениями элементов
        /// начиная с first с шагом step
        /// </summary>
        /// <param name="size">Размерность массива</param>
        /// <param name="first">Значение начального элемента</param>
        /// <param name="step">Шаг</param>
        public MyArray(int size, int first, int step)
        {
            arr = new int[size];
            arr[0] = first;
            for (int i = 1; i < size; i++)
            {
                arr[i] = arr[i - 1] + step;
            }
        }
        public int this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
        public int Count
        {
            get
            {
                int count = arr.Length;
                return count;
            }
        }
        public int DivOnNumb()
        {
            int count = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] % 3 == 0 || arr[i] % 3 == 0) { count++; }
            }
            return count;
        }
        public int Sum
        {
            get
            {
                int sum = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    sum += arr[i];
                }
                return sum;
            }
        }
        /// <summary>
        /// Метод, меняющий знак у элементов одномерного массива
        /// </summary>
        /// <returns>MyArray[] -Array</returns>
        public MyArray Inverse()
        {
            MyArray array = new MyArray(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                array[i] = -arr[i];
            }
            return array;
        }
        /// <summary>
        /// Метод, возвращающий массив умноженый на число n
        /// </summary>
        /// <param name="n"></param>
        /// <returns>int[] Array</returns>
        public int[] Multi(int n)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= n;
            }
            return arr;
        }
        /// <summary>
        /// Свойство класса MyArray, передающее количество вхождений
        /// максимального элемента массива
        /// </summary>
        public int MaxCount
        {
            get
            {
                int max = arr[0];
                int maxCount = 0;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (max < arr[i]) max = arr[i];
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (max == arr[i]) maxCount++;
                }
                return maxCount;
            }
        }
        /// <summary>
        /// Выводит на консоль двумерный массив, в котором Key - это элемент массива, а Value - количество вхождений элемента в массив
        /// </summary>
        public void DictionaryArray()
            {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dictionary.ContainsKey(arr[i]))
                {
                    dictionary[arr[i]] += 1;
                }
                else
                {
                    dictionary.Add(arr[i], 1);
                }
            }
            foreach (KeyValuePair<int, int> kvp in dictionary)
            {
                Console.WriteLine($"Key = {kvp.Key} Value = {kvp.Value}");
            }
        }
        /// <summary>
        /// Выводит на консоль массив с сообщением
        /// </summary>
        /// <param name="Message">Сообщение типа string</param>
        public void ShowArray(string Message)
        {
            Console.WriteLine(Message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[");
            foreach(int i in arr) { Console.Write($"{i,6}"); }
            Console.Write("]\n");
            Console.ResetColor();
        }
    }

    //3.  Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.
    //    Создайте структуру Account, содержащую Login и Password.

    struct Account
    {
        public bool Login(string login)
        {
            string fileAcc = "Properties\\Account.txt";
            if (File.Exists(fileAcc))
            {
                string[] s = File.ReadAllLines(fileAcc);
                string loginTrue = s[0];
                if (login == loginTrue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Файла не существует");
                return false;
            }
        }
        public bool Password(string pass)
        {
            string fileAcc = "Properties\\Account.txt";
            if (File.Exists(fileAcc))
            {
                string[] s = File.ReadAllLines(fileAcc);
                string passTrue = s[1];
                if (pass == passTrue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Файла не существует");
                return false;
            }
        }
    }

    //4. *а) Реализовать класс для работы с двумерным массивом.Реализовать конструктор, заполняющий массив случайными числами.Создать методы, которые возвращают сумму всех элементов массива,
    //    сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, 
    //    метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)
    //   *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    //    Дополнительные задачи
    //    в) Обработать возможные исключительные ситуации при работе с файлами.

    class Matrix2D
    {
        int[,] arr;
        public Matrix2D()
        {
            arr = new int[4, 4];
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = rnd.Next(0, 101);
                }

            }
        }
        public Matrix2D(int countCol,int countRow, int start, int finish)
        {
            arr = new int[countCol, countRow];
            Random rnd = new Random();
            for(int i = 0; i < countCol; i++)
            {
                for (int j = 0; j < countRow; j++)
                {
                    arr[i, j] = rnd.Next(start, finish);
                }
            }
        }
        public Matrix2D(int countCol,int countRow,string filePath)
        {
            arr = new int[countCol, countRow];
            StreamReader file = new StreamReader(filePath);
            string s;
            for(int i= 0; i < countCol; i++)
            {
                for(int j = 0; j < countRow; j++)
                {
                    if (!file.EndOfStream)
                    {
                        s = file.ReadLine();
                        try
                        {
                            arr[i, j] = int.Parse(s);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        arr[i, j] = 0;
                    }
                }
            }
            file.Close();
        }
        public int Sum ()
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];
                }
            }
            return sum;
        }
        public int SumToNum (int n)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > n) sum += arr[i, j];
                }
            }
            return sum;
        }
        public int Max
        {
            get
            {
                int max = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (max < arr[i, j]) max = arr[i, j];
                    }
                }
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (min > arr[i, j]) min = arr[i, j];
                    }
                }
                return min;
            }
        }
        public void MaxNum(out int maxI, out int maxJ)
        {
            int max = arr[0, 0];
            maxI = 0; maxJ = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (max < arr[i, j])
                    {
                        maxI = i + 1;
                        maxJ = j + 1;
                        max = arr[i, j];
                    }
                }
            }
        }
        public void UploadMatrix(string filePath)
        {
            if (File.Exists(filePath))
            {
                StreamWriter text = new StreamWriter(filePath);
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    string s = "";
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        s += $"{arr[i, j],5}";
                    }
                    text.WriteLine(s);
                }
                text.Close();
            }
            else
            {
                Console.WriteLine("Файла не существует");
            }
           
        }
        public void ShowMatrix()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i,j],5}");
                }
                Console.WriteLine("\n");            
            }
            Console.ResetColor();
        }
    }
}
