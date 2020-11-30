using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Windows.Forms;

//5.**Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
//Сарвилин Владимир

namespace WF_lesson8
{
    public partial class Convertor : Form
    {
        
        List<Students> _student = new List<Students>();
        string _namefile;

        private void Save(string filename, List<Students> students)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Students>));
            Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            xml.Serialize(fStream, students);
            fStream.Close();
            
        }
        private void LoadXML(string filename,ref List<Students> student)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Students>));
            var fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            if(student.Count != 0)
            {
                student.Clear();
            }
            student = (List<Students>)xml.Deserialize(fStream);
        }
        public Convertor()
        {
            InitializeComponent();
            
            SfdSaveFile.Filter = "Файлы XML|*.xml";
            SfdSaveFile.DefaultExt = "xml";
            MiSave.Enabled = false;
            MiSaveAs.Enabled = false;
            LblText.Text = "";
        }
        // Обработка сохранения без выбора файла
        private void Save_Click(object sender, EventArgs e)
        {
            string newNameFile = _namefile.Replace(".csv", ".xml");
            Save(newNameFile, _student);
            MiOpenCSV.Enabled = true;
            MiOpenXML.Enabled = true;
            MiSave.Enabled = false;
            MiSaveAs.Enabled = false;
        }
        // обработка сохранения с выбором
        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (SfdSaveFile.ShowDialog() == DialogResult.Cancel) return;
            string saveFileName = SfdSaveFile.FileName;
            Save(saveFileName, _student);
            MiOpenCSV.Enabled = true;
            MiOpenXML.Enabled = true;
            MiSave.Enabled = false;
            MiSaveAs.Enabled = false;
        }
        // Открытие файла csv
        private void OpenCSV_Click(object sender, EventArgs e)
        {
            OutData.Items.Clear();
            OfdOpenFile.DefaultExt = "csv";
            OfdOpenFile.Filter = "Файлы с раширением csv|*.csv";
            if (OfdOpenFile.ShowDialog() == DialogResult.Cancel) return;
            _namefile = OfdOpenFile.FileName;
            var fStream = new StreamReader(_namefile, Encoding.GetEncoding(1251));
            while (!fStream.EndOfStream)
            {
                string text = fStream.ReadLine();
                string[] s = text.Split(';');
                _student.Add(new Students(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8], s[9], s[10]));
                OutData.Items.Add(text);
            }
            fStream.Close();
            LblText.Text = $"Загружен файл: {_namefile.Split('\\')[_namefile.Split('\\').Length - 1]}";
            MiOpenCSV.Enabled = false;
            MiOpenXML.Enabled = true;
            MiSave.Enabled = true;
            MiSaveAs.Enabled = true;
        }
        // открытие файла xml
        private void OpenXML_Click(object sender, EventArgs e)
        {
            OfdOpenFile.DefaultExt = "xml";
            OfdOpenFile.Filter = "Файлы с раширением xml|*.xml";
            if (OfdOpenFile.ShowDialog() == DialogResult.Cancel) return;
            _namefile = OfdOpenFile.FileName;
            OutData.Items.Clear();
            var fStream = new StreamReader(_namefile);
            while (!fStream.EndOfStream)
            {
                OutData.Items.Add(fStream.ReadLine());
            }
            fStream.Close();
            LblText.Text = $"Загружен файл: {_namefile.Split('\\')[_namefile.Split('\\').Length - 1]}";
            MiOpenCSV.Enabled = true;
            MiOpenXML.Enabled = false;
            MiSave.Enabled = false;
            MiSaveAs.Enabled = false;
        }
        //Выход из приложения
        private void MiExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Загрузка файла xml и его десерилизация с выводом текста в ListBox
        private void MiLoadXML_Click(object sender, EventArgs e)
        {
            OfdOpenFile.Filter = "Файлы XML|*.xml";
            if (OfdOpenFile.ShowDialog() == DialogResult.Cancel) return;
            _namefile = OfdOpenFile.FileName;
            LblText.Text = $"Загружен файл: {_namefile.Split('\\')[_namefile.Split('\\').Length - 1]}";
            OutData.Items.Clear();
            LoadXML(_namefile, ref _student);
            foreach(var s in _student)
            {
                OutData.Items.Add($"{s.lastName} {s.firstName} из города {s.adress.city} учится на {s.course} курсе");
            }
        }
    }
}
