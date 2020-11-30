using System;
using System.Windows.Forms;

//2.Создайте простую форму на котором свяжите свойство Text элемента TextBox со свойством Value элемента NumericUpDown
//Сарвилин Владимир

namespace WF_lesson8
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
            TextBox.Text = NumericUpDown.Value.ToString();
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            TextBox.Text = NumericUpDown.Value.ToString();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if(!decimal.TryParse(TextBox.Text,out decimal result))
            {
                throw new ArgumentException($"{TextBox.Text} не является числом");
            }
            if(result > NumericUpDown.Maximum || result < NumericUpDown.Minimum)
            {
                throw new ArgumentException($"Число должно быть в диапозоне от {NumericUpDown.Minimum} до {NumericUpDown.Maximum}");
            }
            NumericUpDown.Value = result;
        }
    }
}
