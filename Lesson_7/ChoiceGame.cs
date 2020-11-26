using System;
using System.Windows.Forms;


//Окно для выбора игры

namespace Lesson_7
{
    public partial class ChoiceGame : Form
    {
        public ChoiceGame()
        {
            InitializeComponent();
        }

        private void BtnUdvoitel_Click(object sender, EventArgs e)
        {
            WF_Udvoitel wF_Udvoitel = new WF_Udvoitel();
            wF_Udvoitel.Show();
            Hide();
            wF_Udvoitel.Closed += (s, ev) => Show();
        }

        private void BtnGuess_Click(object sender, EventArgs e)
        {
            
            WF_Guess wF_Guess = new WF_Guess();
            wF_Guess.Show();
            Hide();
            wF_Guess.Closed += (s, ev) => Show();
        }
    }
}
