using System;
using System.Reflection;
using System.Windows.Forms;

//1. С помощью рефлексии выведите все свойства структуры DateTime

namespace WF_lesson8
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Type type = typeof(DateTime);
            foreach(var p in type.GetTypeInfo().DeclaredProperties)
            {
                listBox1.Items.Add(p.Name);
            }
        }
    }
}
