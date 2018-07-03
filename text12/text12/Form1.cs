using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace text12
{
    public partial class Form1 : Form
    {
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


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
