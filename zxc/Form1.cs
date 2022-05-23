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

namespace DesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void openFile_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog(); //экземпляр класса, выбрать файл
            openFileDialog1.Title = "Выберете файл";
            openFileDialog1.InitialDirectory = @"C:\"; // нач. папка
            openFileDialog1.Filter = "Text files(*.txt)|*.txt"; //фильтра имен файлов расширений
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) 
                return;
            string filename = openFileDialog1.FileName;            
            Source.Text = filename;
            openFileDialog1.Dispose();
        }
        private bool Err()
        {
            bool t = true;
            label3.Text = "";
            bErr.Text = "";
            if (textBox1.Text.ToString().Length != 8) { label3.Text = "Ключ должен быть 8-ми символьный!"; t = false; }
            if (Source.Text == "") { bErr.Text = "Выберете путь!"; t = false; }
            else
            {
                try
                {
                    string input = Source.Text.Replace(@"\", @"\\");
                    StreamReader writein = new StreamReader(input);                    
                    string a = writein.ReadToEnd();
                }
                catch
                {
                    bErr.Text = "Неверный путь!";
                    t = false;
                }
            }
            return t;
        }
        private string Proc(char i)
        {
            MessageBox.Show("Выберете путь, для сохранения сообщения");
            var diag = new FolderBrowserDialog();            
            string filename = "";
            string name;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                filename = diag.SelectedPath + @"\";
                filename = filename.Replace(@"\", @"\\");
                if (i == 'd')
                {
                    name = Path.GetFileName(Source.Text).Remove(Path.GetFileName(Source.Text).LastIndexOf('.'), 4) + "_De.txt";
                }
                else
                {
                    name = Path.GetFileName(Source.Text).Remove(Path.GetFileName(Source.Text).LastIndexOf('.'), 4) + "_En.txt";
                }
                filename += name;
            }
            else  return "-1"; 
            return filename;
        }
        private void Decryption_Click(object sender, EventArgs e)
        {            
            if(Err())
            {
                string filename = Proc('d');
                if (filename == "-1") return;
                string input = Source.Text.Replace(@"\", @"\\");
                StreamWriter write = new StreamWriter(filename);
                StreamReader writein = new StreamReader(input);
                string a = writein.ReadToEnd();
                Des des = new Des(a, textBox1.Text);
                a = des.Dencription();
                Clipboard.SetText(a); // копирование в буфер
                write.Write(a);
                write.Close(); //закрывает текущий объект и базовый поток. освобождает все ресурсы
                writein.Close();
                if(openOrClose.Checked) //открытие файла
                {
                    Process proc = Process.Start("notepad.exe", filename); //Запускает ресурс процесса и связывает его с компонентом Process 
                    proc.WaitForExit(); //команду ожидания завершения связанного процесса
                    proc.Close(); 
                }
            }
        }
        private void Encryption_Click(object sender, EventArgs e)
        {
            bool f = Err();
            if (f)
            {
                string filename = Proc('e');
                if (filename == "-1") return;
                string input = Source.Text.Replace(@"\", @"\\");
                StreamWriter write = new StreamWriter(filename);
                StreamReader writein = new StreamReader(input);
                string a = writein.ReadToEnd();
                Des des = new Des(a, textBox1.Text);
                a = des.Encription();
                Clipboard.SetText(a);
                write.Write(a);
                write.Close();
                writein.Close();
                if (openOrClose.Checked)
                {
                    Process proc = Process.Start("notepad.exe", filename);
                    proc.WaitForExit();
                    proc.Close();
                }                
            }
        }
        
    }
}
