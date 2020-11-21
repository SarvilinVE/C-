using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// Домашняя работа 5. Сарвилин Владимир

class Task5
{
    public void Main()
    {
        // Задание 1

        Console.WriteLine($"Программа проверки корректности логина(true - логин корректен, false - логин некорректен)");
        Console.WriteLine("Введите логин:");
        string userLogin = Console.ReadLine();
        Console.WriteLine($"Проверка без регулярных выражений: {CheckLogin(userLogin)}");
        Console.WriteLine($"Проверка с помощью регулярных выражений: {CheckLoginRegular(userLogin)}");
        Console.ReadKey();
        Console.Clear();

        // Задание 2 

        Console.WriteLine("Программа по работе с текстом");
        if (File.Exists("Files\\Text.txt"))
        {
            string text = File.ReadAllText("Files\\Text.txt", Encoding.GetEncoding(1251));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine("-----------------удаляет слова длиной больше заданного числа----------------");
            Console.WriteLine(Message.AnyWordsFromText(text, 4));
            Console.WriteLine("---------------без регулярки------------------");
            Console.WriteLine(Message.DeleteFewWords(text, 't'));
            Console.WriteLine("---------------с регулярным выражением------------------");
            Console.WriteLine(Message.DeleteFewWordsRegular(text, 't'));
            Console.WriteLine("---------------самое длинное слово------------------");
            Console.WriteLine(Message.BigWord(text));
            Console.WriteLine("---------------Текст из длинных слов------------------");
            Console.WriteLine(Message.TextFromBigWord(text));
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Файла не существует");
            Console.ReadKey();
        }
        Console.Clear();

        // Задание 3

        Console.WriteLine("Программа проверяющая являются ли две строки перестановками друг друга");
        Console.WriteLine("Введите первую строку:");
        string word1 = Console.ReadLine();
        Console.WriteLine("Введите вторую строку:");
        string word2 = Console.ReadLine();
        //3.а с использованием методов C#
        char[] s1 = word1.ToCharArray();
        char[] s2 = word2.ToCharArray();
        Array.Sort(s1);
        Array.Sort(s2);
        Console.WriteLine($"Методами C#: {String.Join("", s1).Equals(String.Join("", s2))}");

        Console.WriteLine($"Собственный метод: {CompareWords(word1, word2)}");
        Console.ReadKey();
        Console.Clear();

        // Задание 4

        Study.Students();
        Console.ReadKey();
    }

    #region
    //1. Создать программу, которая будет проверять корректность ввода логина. 
    //   Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:

    //а) без использования регулярных выражений;
    public bool CheckLogin(string login)
    {
        if (login.Length <= 10 && login.Length > 1)
        {
            char[] charLogin = login.ToLower().ToCharArray();
            if (!char.IsNumber(charLogin[0]))
            {
                string words = "abcdefghijklmnopqrstuvwxyz0123456789";
                for (int i = 0; i < charLogin.Length; i++)
                {
                    if (words.IndexOf(charLogin[i]) == -1) { return false; }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    // б) с использованием регулярных выражений.
    public bool CheckLoginRegular(string login)
    {
        string regMask = @"^[^0-9\W\s_][A-Za-z0-9]{1,9}$";
        Regex rg = new Regex(regMask);
        return rg.IsMatch(login);
    }
    #endregion
    #region
    //2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
    //а) Вывести только те слова сообщения, которые содержат не более n букв.
    //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    //в) Найти самое длинное слово сообщения.
    //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    //Продемонстрируйте работу программы на текстовом файле с вашей программой.

    class Message
    {
        //а) Вывести только те слова сообщения, которые содержат не более n букв.
        public static string AnyWordsFromText(string text, int lengthWord)
        {
            StringBuilder s = new StringBuilder(text);
            for (int i = 0; i < s.Length;)
            {
                if (char.IsPunctuation(s[i]))
                {
                    s.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }
            string[] str = s.ToString().Split(' ');
            string outText = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Length <= lengthWord) outText += str[i] + " ";
            }
            return outText;
        }
        //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        public static string DeleteFewWords(string text, char c)
        {
            StringBuilder s = new StringBuilder(text);

            for (int i = 0; i < s.Length;)
            {
                if (char.IsPunctuation(s[i]))
                {
                    s.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }
            string[] str = s.ToString().Split(' ');
            StringBuilder outText = new StringBuilder ();
            for (int i = 0; i < str.Length; i++)
            {
                if (!str[i].EndsWith(c.ToString())) outText.Append(str[i].PadRight(str[i].Length+1));
            }
            return outText.ToString();
        }
        //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.(С помощью регулярного выражения)
        public static string DeleteFewWordsRegular(string text, char c)
        { 
            string regMask = @"\b\S+" + c.ToString() + "\\b";
            Regex rg = new Regex(regMask);
            string sr = rg.Replace(text, "");

            return sr;
        }
        // в) Найти самое длинное слово сообщения.
        public static string BigWord(string text)
        {
            StringBuilder s = new StringBuilder(text);

            for (int i = 0; i < s.Length;)
            {
                if (char.IsPunctuation(s[i]))
                {
                    s.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }
            string[] str = s.ToString().Split(' ');
            string maxWord = str[0];
            for (int i = 1; i < str.Length; i++)
            {
                if (maxWord.Length <= str[i].Length) maxWord = str[i];
            }
            return maxWord;
        }
        //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        public static string TextFromBigWord(string text)
        {
            StringBuilder s = new StringBuilder(text);

            for (int i = 0; i < s.Length;)
            {
                if (char.IsPunctuation(s[i]))
                {
                    s.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }
            string[] str = s.ToString().Split(' ');
            StringBuilder outText = new StringBuilder();
            string maxWord = BigWord(s.ToString());
            for (int i = 1; i < str.Length; i++)
            {
                if (maxWord.Length == str[i].Length) outText.Append(str[i].PadRight(str[i].Length+1));
            }
            return outText.ToString();
        }
    }
    #endregion
    #region

    //3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
    //а) с использованием методов C#(смотри в методе Main() );
    //б) *разработав собственный алгоритм.
    public bool CompareWords(string s1, string s2)
    {
        StringBuilder sb1 = new StringBuilder(s1);
        StringBuilder sb2 = new StringBuilder(s2);
        if(s1.Length != s2.Length) { return false; }
        for(int i = 0; i < sb1.Length; i++)
        {
            for(int j = 0; j < sb2.Length;)
            {
                if(sb1[i] == sb2[j])
                {
                    sb2.Remove(j, 1);
                }
                else
                {
                    j++;
                }
            }
        }
        if (sb2.Length == 0) return true;
        return false;
    }
    #endregion

    //4. Задача ЕГЭ.
    class Study
    {
        public static void Students()
        {
            StreamReader sr = new StreamReader("Files\\Student.txt",Encoding.GetEncoding(1251));
            int countStudent = int.Parse(sr.ReadLine());
            string[] student = new string[countStudent];
            double[] avgMark = new double[countStudent];
            for (int i = 0; i < countStudent; i++)
            {
                string[] ss = sr.ReadLine().Split(' ');
                avgMark[i] = Math.Round(((double.Parse(ss[2]) + double.Parse(ss[3]) + double.Parse(ss[4])) / 3),2);
                student[i] = $"{ss[0]} {ss[1]} {avgMark[i]}";
                Console.WriteLine(student[i]);
            }
            sr.Close();

            double min = avgMark[0];
            int k = 3;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Студенты к отчислению:");
            while (k != 0)
            {
                for (int i = 0; i < avgMark.Length; i++) //поиск минимального среднего балла
                {
                    if (min > avgMark[i])
                    {
                        min = avgMark[i];
                    }
                }
                for (int j = 0; j < student.Length; j++) // Поиск всех студентов с одинаковым минимальным баллом
                {
                    string[] ss = student[j].Split(' ');
                    if (min == double.Parse(ss[2]))
                    {
                        Console.WriteLine($"{ss[0]} {ss[1]} ({avgMark[j]}),");
                        avgMark[j] = 6; // Делаем средний балл, найденного студента, выше возможного максимального значения
                    }
                }
                k--;
                min = 6;
            }
        }
    }
}