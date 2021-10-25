using System;
using System.Windows.Forms;

//3.а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не создана база данных, обращение к несуществующему вопросу, 
//     открытие слишком большого файла и т.д.).
//  б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение.
//  в) Добавить в приложение меню «О программе» с информацией о программе (автор, версия, авторские права и др.).
//  г)*Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных (элемент SaveFileDialog).

namespace WF_lesson8
{
    public partial class TrueOrFalse : Form
    {
        // База данных с вопросами
        TrueFalse database;
        Info info = new Info();
        
        public TrueOrFalse()
        {
            InitializeComponent();
        }

        private void MiNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("1", true);
                database.Save();
                NudNumber.Minimum = 1;
                NudNumber.Maximum = 1;
                NudNumber.Value = 1;
            };

        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (database == null)
            {
                NudNumber.Value = 0;
                MessageBox.Show("Не загружена база данных", "Сообщение");
                return;
            }
            TboxQuestion.Text = database[(int)NudNumber.Value - 1].Text;
            CboxTrue.Checked = database[(int)NudNumber.Value - 1].TrueFalse;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count + 1).ToString(), true);
            NudNumber.Maximum = database.Count;
            NudNumber.Value = database.Count;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (NudNumber.Maximum == 1 || database == null) return;
            database.Remove((int)NudNumber.Value);
            NudNumber.Maximum--;
            if (NudNumber.Value > 1) NudNumber.Value = NudNumber.Value;

        }

        private void MiSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("База данных не создана");

        }

        private void MiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                if(database.Count > 1000)
                {
                    MessageBox.Show("Слишком большая база. Возможности добавления новых вопросов ограниченны");
                    BtnAdd.Enabled = false;
                }
                NudNumber.Minimum = 1;
                NudNumber.Maximum = database.Count;
                NudNumber.Value = 1;
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            database[(int)NudNumber.Value - 1].Text = TboxQuestion.Text;
            database[(int)NudNumber.Value - 1].TrueFalse = CboxTrue.Checked;
        }
        //Реализовано меню Save as...
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.Cancel) return;
            if (database != null) 
            {
                database.FileName = sfd.FileName + ".dat";
                database.Save(); 
            }
            else MessageBox.Show("База данных не создана");
        }

        private void MiInfo_Click(object sender, EventArgs e)
        {
            info.ShowDialog();
        }

        private void MiPlay_Click(object sender, EventArgs e)
        {
            WPlay play = new WPlay();
            play.ShowDialog();
        }
    }
}