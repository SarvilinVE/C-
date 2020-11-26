using System;
using System.Windows.Forms;

//Окно для ввода чисел игроком

namespace Lesson_7
{
    public partial class WF_PlayerAnswer : Form
    {
        public WF_PlayerAnswer()
        {
            InitializeComponent();
        }

        public void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(textBox1.Text, out int result))
                {
                    PlayaerAnswer = textBox1.Text;
                    Close();
                }
                else
                {
                    throw new Exception("Введено не число");
                }
            }
        }
        public string PlayaerAnswer
        {
            get { return textBox1.Text; }
            set 
            {
                textBox1.Text = value;
            }
        }
        public bool StopGame { get; set; } = false;

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            StopGame = true;
            Close();
        }
    }
}
