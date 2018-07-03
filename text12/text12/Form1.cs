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

namespace text12
{
    
    public partial class Form1 : Form
    {
        FileStream file;

        public Form1()
        {
            InitializeComponent();
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "Введите замену для пустых строк...";
                textBox1.ForeColor = Color.DarkGray;
            }
            textBox1.Select(); // to Set Focus
            textBox1.Select(0, 0);
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
            for (int i = 0; i < mas.Count; i++)
            {
                if (mas[i] == "") mas[i] = textBox1.Text;
            }
            richTextBox1.Clear();
            if (mas.Count > 1) mas.RemoveAt(mas.Count - 1);
            for (int i = 0; i < mas.Count; i++)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
