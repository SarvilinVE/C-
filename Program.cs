using System;

namespace Lessons_2
{
    class Program
    {
        static void Main()
        {
            Task_2 work = new Task_2(); //класс где выполнены все задания
            FormatIO format = new FormatIO(); // класс для форматированного ввода данных.
            
            work.Access(); 
            
            Console.Clear();
            Console.WriteLine("Выберите программу, указав ее номер (любая другая цифра закрывает программу):");
            Console.WriteLine("1.Программа, выбирающая минимальное из трёх чисел.");
            Console.WriteLine("2.Программа по подсчету количества цифр числа.");
            Console.WriteLine("3.Программа по подсчету суммы нечетных положительных чисел.");
            Console.WriteLine("4.Программа расчета ИМТ \"Худой\\Толстый\"");
            Console.WriteLine("5.Программа подсчета количества \"хороших\" чисел"); 
            Console.WriteLine("6.Программа реализует вывод на экран чисел от a до b [a < b].");
            int count = 0;
            int answer = format.GetTryInt("Ваш выбор :");
            while (count != 7)
            {
               
                switch (answer)
                {
                    case 1:
                        work.MinNumber();
                        count++;
                        break;
                    case 2:
                        work.CountNumbers();
                        count++;
                        break;
                    case 3:
                        work.CountOddNumbers();
                        count++;
                        break;
                    case 4:
                        work.IMT();
                        count++;
                        break;
                    case 5:
                        work.GoodNumbers();
                        count++;
                        break;
                    case 6:
                        work.NumbersAB();
                        count++;
                        break;
                    default:
                        format.TextTask("конец");
                        Environment.Exit(0);
                        break;
                }
                Console.Clear();

                Console.WriteLine("Выберите программу, указав ее номер (любая другая цифра закрывает программу):");
                Console.WriteLine("1.Программа, выбирающая минимальное из трёх чисел.");
                Console.WriteLine("2.Программа по подсчету количества цифр числа.");
                Console.WriteLine("3.Программа по подсчету суммы нечетных положительных чисел.");
                Console.WriteLine("4.Программа расчета ИМТ \"Худой\\Толстый\"");
                Console.WriteLine("5.Программа подсчета количества \"хороших\" чисел");
                Console.WriteLine("6.Программа реализует вывод на экран чисел от a до b [a < b].");

                answer = format.GetTryInt("Ваш выбор :");
            }

            format.TextTask("конец");
            Environment.Exit(0);

        }
    }
}
