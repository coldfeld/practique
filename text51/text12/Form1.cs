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
            string pattern = "[0-9]+(\\.[0-9]+)?";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            StreamWriter f1 = new StreamWriter("column1.txt", false, System.Text.Encoding.Default);
            StreamWriter f2 = new StreamWriter("column2.txt", false, System.Text.Encoding.Default);
            StreamWriter f3 = new StreamWriter("column3.txt", false, System.Text.Encoding.Default);
            foreach (string s in mas)
            {
                Match m = r.Match(s);
                if (m.Success)
                {
                    int j = 0;
                    foreach (Match match in r.Matches(s)){
                        switch (j)
                        {
                            case 0:
                                f1.WriteLine(match.Value);
                                break;
                            case 1:
                                f2.WriteLine(match.Value);
                                break;
                            case 2:
                                f3.WriteLine(match.Value);
                                break;
                        }
                        j++;
                    }
                }
            }
            f1.Close();
            f2.Close();
            f3.Close();
            richTextBox1.Clear();
            foreach (string s in mas)
            {
                richTextBox1.AppendText(s+"\n");
            }
            richTextBox1.AppendText("Sucsess!");
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
