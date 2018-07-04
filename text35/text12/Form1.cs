using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace text35
{
    
    public partial class Form1 : Form
    {
        FileStream file;

        public Form1()
        {
            InitializeComponent();
        }


        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                readf(openFileDialog1.FileName);
            }
        }

        public void readf(String s)
        {
            richTextBox1.Clear();
            file = new FileStream(s, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(file); // создаем «потоковый читатель» и связываем его с файловым потоком
            richTextBox1.AppendText(reader.ReadToEnd()); //считываем все данные с потока и выводим на экран
            file.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> mas = new List<string>();
            foreach (string i in richTextBox1.Lines)
                mas.Add(i);
            string pattern = "([а-яa-z0-9].?)+";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            for (int i = 0; i < mas.Count-1; i++)
            {
                Match m = r.Match(mas[i]);
                if (m.Success)
                {
                    string buf = "";
                    string s = "";
                    
                    foreach (Match match in r.Matches(mas[i])){
                        s += match.Value;
                    }
                    if (s.Length % 2 != 0) buf += " ";
                    for (int j = 0; j < (50 - m.Value.Length) / 2; j++) buf += " ";
                    mas[i] = buf+s;
                }
            }
            richTextBox1.Clear();
            for (int i = 0; i < mas.Count - 1; i++)
            {
                richTextBox1.AppendText(mas[i]+"\n");
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, null);
                List<string> mas = new List<string>();
                foreach (string i in richTextBox1.Lines)
                    File.AppendAllText(saveFileDialog1.FileName, i+"\n");
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file != null)
            {
                File.WriteAllText(file.Name, null);
                List<string> mas = new List<string>();
                foreach (string i in richTextBox1.Lines)
                    File.AppendAllText(file.Name, i + "\n");
            }
            else MessageBox.Show("Сначала откройте файл");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
