using System;
using System.IO;
using System.Text;


// Домашняя работа 5. Сарвилин Владимир

// 5. **Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет. Например: «Шариковую ручку изобрели в древнем Египте», «Да». 
//    Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. 
//    Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ. 
//    Список вопросов ищите во вложении или воспользуйтесь интернетом.
class TrueOrFalse
    {
        public void Main()
        {
            string pathFile = "Files\\Task.txt";
            if (!File.Exists(pathFile))
            {
                Console.WriteLine("Файла не существует! Приложение будет закрыто");
                Environment.Exit(0);
            }

            Random rnd = new Random();
            Game player = new Game(pathFile);
            int countQuest = 0;
            int correctAnsewr = 0;
            string answer;

            Console.WriteLine("Это игра Правда или Ложь. Отвечайте на вопросы да/нет и узнайте на сколько вы эрудированны!");
            Console.ReadKey();
            Console.Clear();

            while (countQuest != 5)
            {
                player.Question(rnd.Next(0, player.CountQuestion + 1));
                do
                {
                    answer = Console.ReadLine();
                } while (!player.ExeptionAnswer(ref answer));
                player.Answer(answer, ref correctAnsewr, countQuest);
                countQuest++;
            }
            Console.Clear();
            player.ShowResult(correctAnsewr);
            Console.ReadKey();
        }
        class Game
        {
            string[,] _quest; // массив вопросов и ответов
            int _questionNum; // номер вопроса
            int _countQuestion;// число вопросов
            string[] _question;// массив вопрос ответ
            string[,] _correctAnswer = new string[2, 5]; //массив правильных/неправильных ответов

            /// <summary>
            /// Конструктор класса Game. Заполняет массив вопросов и ответов из файла расположенного по пути pathFile
            /// </summary>
            /// <param name="pathFile"></param>
            public Game(string pathFile)
            {
                _question = File.ReadAllLines(pathFile, Encoding.GetEncoding(1251));
                _quest = new string[2, _question.Length];
                for (int i = 0; i < _question.Length; i++)
                {
                    string s = _question[i].ToString();
                    int charNum = s.IndexOf(';');
                    _quest[0, i] = s.Substring(0, charNum);
                    _quest[1, i] = s.Substring(charNum + 1);
                }
            }
            public int CountQuestion
            {
                get
                {
                    _countQuestion = _quest.GetLength(1);
                    return _countQuestion;
                }
                set
                {
                    _countQuestion = value;
                }
            }
            /// <summary>
            /// Метод выполняет проверку правильного ввода ответа
            /// </summary>
            /// <param name="playerAnswer"></param>
            /// <returns></returns>
            public bool ExeptionAnswer(ref string playerAnswer)
            {
                switch (playerAnswer.ToLower())
                {
                    case "yes":
                        {
                            playerAnswer = "да";
                            return true;
                        }
                    case "y":
                        {
                            playerAnswer = "да";
                            return true;
                        }
                    case "да":
                        {
                            return true;
                        }
                    case "no":
                        {
                            playerAnswer = "нет";
                            return true;
                        }
                    case "n":
                        {
                            playerAnswer = "нет";
                            return true;
                        }
                    case "нет":
                        {
                            return true;
                        }
                    default:
                        {
                            Console.WriteLine("Не верный формат ответа(Ответы должны выглядеть так да/нет/yes/y/no/n). Введите ответ еще раз");
                            return false;
                        }
                }
            }

            /// <summary>
            /// Метод класса Game.Выводит вопрос из массива вопросов и ответов, соответствующий questNum
            /// </summary>
            /// <param name="questNum"></param>
            public void Question(int questNum)
            {
                _questionNum = questNum;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{_quest[0, questNum]}?");
                Console.ResetColor();
            }
            /// <summary>
            /// Метод, обрабатывающий ответы игрока
            /// </summary>
            /// <param name="playerAnswer"></param>
            /// <param name="correctAnswer"></param>
            /// <param name="ansewrNum"></param>
            public void Answer(string playerAnswer, ref int correctAnswer, int ansewrNum)
            {
                if (playerAnswer.ToLower() == _quest[1, _questionNum].ToLower())
                {
                    correctAnswer++;
                    _correctAnswer[0, ansewrNum] = _quest[1, _questionNum];
                    _correctAnswer[1, ansewrNum] = "1";
                }
                else
                {
                    _correctAnswer[0, ansewrNum] = _quest[1, _questionNum];
                    _correctAnswer[1, ansewrNum] = "0";
                }
                int k = 0;
                string[] questionTemp = _question;

                // Уменьшаем массив вопрос ответ на один

                Array.Resize(ref _question, questionTemp.Length - 1);

                // Заполняем его, убрав вопрос, на который только что отвечали 

                for (int i = 0; i < questionTemp.Length; i++)
                {
                    if (i != _questionNum)
                    {
                        _question[k] = questionTemp[i];
                        k++;
                    }
                }

                // заново заполняем массив вопросов и ответов

                _quest = new string[2, _question.Length];
                for (int i = 0; i < _question.Length; i++)
                {
                    string s = _question[i].ToString();
                    int charNum = s.IndexOf(';');
                    _quest[0, i] = s.Substring(0, charNum);
                    _quest[1, i] = s.Substring(charNum + 1);
                }
                _countQuestion = _quest.GetLength(1);
            }
            /// <summary>
            /// Метод вывода результата игры.
            /// </summary>
            /// <param name="result"></param>
            public void ShowResult(int result)
            {
                for (int i = 0; i < _correctAnswer.GetLength(1); i++)
                {
                    if (_correctAnswer[1, i] == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{i + 1}.{_correctAnswer[0, i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine($"{i + 1}.{_correctAnswer[0, i]}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("------------------------------------------------");
                switch (result)
                {
                    case 1:
                        {
                            Console.WriteLine($"Правильных ответов {result}. Результат мягко говоря не очень");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Правильных ответов {result}. Надо больше чиать");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"Правильных ответов {result}. Не плохо, но можно еще лучше");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine($"Правильных ответов {result}. Уже хорошо, но есть куда расти");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine($"Правильных ответов {result}. Отлично, потрясающий результат!!!");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Правильных ответов {result}. Вы вообще вопросы читали?");
                            break;
                        }
                }
                Console.ReadKey();
            }
        }
    }
