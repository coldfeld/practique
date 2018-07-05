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

namespace text51
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
            StreamWriter f1 = new StreamWriter("simbols.txt", false, System.Text.Encoding.Default);
            List<char> charset = new List<char>();
            foreach (string s in mas)
            {
                foreach(char c in s)
                {
                    if(!charset.Contains(c)){
                        charset.Add(c);
                    }
                }
            }
            charset.Sort();
            charset.Reverse();
            richTextBox1.Clear();
            
            foreach (string i in mas)
            {
                richTextBox1.AppendText(i+"\n");
            }
            richTextBox1.AppendText("Result:\n");
            foreach(char c in charset)
            {
                richTextBox1.AppendText(c.ToString());
                f1.Write(c);
            }
            f1.Close();
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
