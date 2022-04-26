using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace zxc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            Source.Text = filename;
            
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString().Length != 8)
            {
                string err = "Ключ должен быть 8-ми символьный!";
                label3.Text = err;
            }
            else
            {
                label3.Text = "";
                MessageBox.Show("Выберете файл, в который будет сохранено расшифрованное сообщение.");
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                filename = filename.Replace(@"\", @"\\");
                string input = Source.Text.Replace(@"\", @"\\");
                StreamWriter write = new StreamWriter(filename);
                StreamReader writein = new StreamReader(input);
                string a = writein.ReadToEnd();
                Des des = new Des(a, textBox1.Text);
                a = des.Dencription();
                write.WriteLine(a);
                write.Close();
                writein.Close();
                Process proc = Process.Start("notepad.exe", filename);
                proc.WaitForExit();
                proc.Close();
            }
        }

        private void Encryption_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString().Length != 8)
            {
                string err = "Ключ должен быть 8-ми символьный!";
                label3.Text = err;
            }
            else
            {
                label3.Text = "";
                MessageBox.Show("Выберете файл, в который будет сохранено зашифрованное сообщение.");
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                filename = filename.Replace(@"\", @"\\");
                string input = Source.Text.Replace(@"\", @"\\");               
                StreamWriter write = new StreamWriter(filename);
                StreamReader writein = new StreamReader(input);
                string a = writein.ReadToEnd();
                Des des = new Des(a, textBox1.Text);
                a = des.Encription();
                write.WriteLine(a);
                write.Close();
                writein.Close();
                Process proc = Process.Start("notepad.exe", filename);
                proc.WaitForExit();
                proc.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
