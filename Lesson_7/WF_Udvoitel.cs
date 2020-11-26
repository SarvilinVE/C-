using System;
using System.Collections.Generic;
using System.Windows.Forms;

//а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
//б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. 
//   Игрок должен получить это число за минимальное количество ходов.
//в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте обобщенный класс Stack.
//Вся логика игры должна быть реализована в классе с удвоителем.
//Сарвилин Владимир

namespace Lesson_7
{
    public partial class WF_Udvoitel : Form
    {
        Stack<string> _stackUndo = new Stack<string>();//Для отмены последнего действия
        public WF_Udvoitel()
        {
            InitializeComponent();
            //Делаем активным только меню "Играть"
            TsmPlay.Enabled = true;
            TsmUndo.Enabled = false;
            btnCommand1.Enabled = false;
            btnCommand2.Enabled = false;
            btnReset.Enabled = false;
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            _stackUndo.Push(lblNumber.Text);
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            lblCountClick.Text = (int.Parse(lblCountClick.Text) + 1).ToString();
            TsmUndo.Enabled = true;
            GameOver();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            _stackUndo.Push(lblNumber.Text);
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            lblCountClick.Text = (int.Parse(lblCountClick.Text) + 1).ToString();
            TsmUndo.Enabled = true;
            GameOver();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "1";
            lblCountClick.Text = "0"; 
            lblNumForWin.Text = "0";
            lblMinCountStep.Text = "0";
            _stackUndo.Clear();
            TsmPlay.Enabled = true;
            TsmUndo.Enabled = false;
            btnCommand1.Enabled = false;
            btnCommand2.Enabled = false;
            btnReset.Enabled = false;
        }

        private void TsmPlay_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "1";
            lblCountClick.Text = "0";
            lblNumForWin.Text = "0";
            lblMinCountStep.Text = "0";
            _stackUndo.Clear();

            lblNumForWin.Text = (new Random().Next(20,101)).ToString();
            MessageBox.Show($"Вам необходимо набрать {lblNumForWin.Text} за минимальное количество ходов","Задание",0,MessageBoxIcon.Question);
            MinCountStep();
            TsmPlay.Enabled = false;
            btnCommand1.Enabled = true;
            btnCommand2.Enabled = true;
            btnReset.Enabled = true;
        }

        private void TsmUndo_Click(object sender, EventArgs e)
        {
            lblNumber.Text = _stackUndo.Pop();
            lblCountClick.Text = (int.Parse(lblCountClick.Text)-1).ToString();
            TsmUndo.Enabled = _stackUndo.Count != 0;
        }
        // расчет минимального количества ходов
        public void MinCountStep()
        {
            int num = int.Parse(lblNumForWin.Text);
            int countStep = 0;
            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                    countStep++;
                }
                else
                {
                    num -= 1;
                    countStep++;
                }
                
            }
            lblMinCountStep.Text = countStep.ToString();
        }
        //Проверка окончания игры
        public void GameOver()
        {

            if (int.Parse(lblNumber.Text) == int.Parse(lblNumForWin.Text))
            {
                if (int.Parse(lblCountClick.Text) <= int.Parse(lblMinCountStep.Text))
                {
                    MessageBox.Show("Поздравляем! Вы выйграли!","Выйграл",0,MessageBoxIcon.Exclamation);
                    lblNumber.Text = "1";
                    lblCountClick.Text = "0";
                    lblNumForWin.Text = "0";
                    lblMinCountStep.Text = "0";
                    _stackUndo.Clear();
                    TsmPlay.Enabled = true;
                    TsmUndo.Enabled = false;
                    btnCommand1.Enabled = false;
                    btnCommand2.Enabled = false;
                    btnReset.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"Вы достигли нужного числа {lblNumForWin.Text}, но число ходов {lblCountClick.Text} больше минимального {lblMinCountStep.Text}","Проиграл",0,MessageBoxIcon.Error);
                    lblNumber.Text = "1";
                    lblCountClick.Text = "0";
                    lblNumForWin.Text = "0";
                    lblMinCountStep.Text = "0";
                    _stackUndo.Clear();
                    TsmPlay.Enabled = true;
                    TsmUndo.Enabled = false;
                    btnCommand1.Enabled = false;
                    btnCommand2.Enabled = false;
                    btnReset.Enabled = false;
                }
            }
        }  
    }
}
