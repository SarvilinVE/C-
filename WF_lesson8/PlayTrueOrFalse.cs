using System;
using System.Windows.Forms;

//4. Используя полученные знания и класс TrueFalse, разработать игру «Верю — не верю».

namespace WF_lesson8
{
    
    
    public partial class WPlay : Form
    {
        TrueFalse database;
        
        int _count = 5; //счетчик вопросов
        int _countAnswer = 0;//счетчик правильных ответов
        int _numQuestion;// номер вопроса, который будет выводиться игроку
        public WPlay()
        {
            InitializeComponent();
        }

        private void WPlay_Load(object sender, EventArgs e)
        {
            LblMessage.Text = "Правили игры";
            ChkFalse.Visible = false;
            ChkTrue.Visible = false;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            

            if (BtnPlay.Text == "Начать")
            {
                ChkFalse.Visible = true;
                ChkTrue.Visible = true;
                BtnPlay.Text = "Следующий вопрос";

                //загрузка базы вопросов из файла созданного в TrueOrFalse
                
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.Cancel) return;
                database = new TrueFalse(ofd.FileName);
                database.Load();
                _numQuestion = rnd.Next(0, database.Count);
                LblMessage.Text = $"{6 - _count} вопрос из 5. Всего вопросов {database.Count} \n {database[_numQuestion].Text}";
            }
            else
            {
                // обрабока ответов

                if ((!ChkFalse.Checked && !ChkTrue.Checked) || (ChkFalse.Checked && ChkTrue.Checked))
                {
                    MessageBox.Show("Не выбран ответ");
                    return;
                }

                if (_count != 0 || database.Count >= 0)
                {
                    if(database[_numQuestion].TrueFalse == (ChkTrue.Checked && !ChkFalse.Checked))
                    {
                        _countAnswer++;
                        ChkTrue.Checked = false;
                        ChkFalse.Checked = false;
                    }
                    else
                    {
                        ChkTrue.Checked = false;
                        ChkFalse.Checked = false;
                    }
                    _count--;
                    if (database.Count - 1 > 0)
                    {
                        database.Remove(_numQuestion);
                        _numQuestion = rnd.Next(0, database.Count);
                        LblMessage.Text = $"{6 - _count} вопрос из 5. Всего вопросов {database.Count} \n {database[_numQuestion].Text}";
                    }
                    else
                    {
                        LblMessage.Text = $"Правильно отвечено на {_countAnswer} из 5";
                        BtnPlay.Text = "Начать";
                        _countAnswer = 0;
                        _count = 5;
                        ChkFalse.Visible = false;
                        ChkTrue.Visible = false;
                    }
                }
                else
                {
                    LblMessage.Text = $"Правильно отвечено на {_countAnswer} из 5";
                    BtnPlay.Text = "Начать";
                    _countAnswer = 0;
                    _count = 5;
                    ChkFalse.Visible = false;
                    ChkTrue.Visible = false;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
