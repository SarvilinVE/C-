using System;
using System.Windows.Forms;

//Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. 
//Компьютер говорит, больше или меньше загаданное число введенного.  
//a) Для ввода данных от человека используется элемент TextBox;
//б) **Реализовать отдельную форму c TextBox для ввода числа.
//Сарвилин Владимир

namespace Lesson_7
{
    public partial class WF_Guess : Form
    {
        private WF_PlayerAnswer WF_PlayerAnswer = new WF_PlayerAnswer();
        int _count;
        int _number;
        public WF_Guess()
        {
            InitializeComponent();
        }

        private void WF_Guess_Load(object sender, EventArgs e)
        {
            LblRules.Text = "Игра Угадайка. Программа загадывает число от 1 до 100.\nВам надо угадать это число.\nПри каждой попытке угадать число, программа будет сообщать \nбольше это число или меньше загаданного";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBegin_Click(object sender, EventArgs e)
        {
            if (BtnBegin.Text == "Вперед"|| BtnBegin.Text == "Еще раз?") 
            {
                _count = 0;
                Random rnd = new Random();
                _number = rnd.Next(1, 101);
                BtnCancel.Hide();
                BtnBegin.Text = "Продолжить";
                BtnBegin.Width = 300;
                LblMessage.Text = "Ваш ход!";
            }
            
            WF_PlayerAnswer.ShowDialog();
            while (!GameOver())
            {
                if (WF_PlayerAnswer.StopGame == true)
                {
                    Close();
                    break;
                }
                else
                {
                    WF_PlayerAnswer.ShowDialog();
                }
            }
            BtnCancel.Show();
            BtnBegin.Text = "Еще раз?";
            BtnBegin.Width = 110;
        }
        private bool GameOver()
        {
            if (int.Parse(WF_PlayerAnswer.PlayaerAnswer) == _number)
            {
                _count++;
                LblMessage.Text = $"Поздравляем Вы выйграли!\n Вы угадали число {_number} за {_count} хода(ов)";
                return true;
            }
            else if(int.Parse(WF_PlayerAnswer.PlayaerAnswer) >= _number)
            {
                LblMessage.Text = $"Число {int.Parse(WF_PlayerAnswer.PlayaerAnswer)} больше загаданного";
                _count++;
                return false;
            }
            else
            {
                LblMessage.Text = $"Число {int.Parse(WF_PlayerAnswer.PlayaerAnswer)} меньше загаданного";
                _count++;
                return false;
            }
        }
    }
}
