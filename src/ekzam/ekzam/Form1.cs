using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekzam
{
    public partial class Form1 : Form
    {
        string File;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Html files(*.html)|*.html|All files(*.*)|*.*";

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу разработал:\n Студент группы ПКуспк-320\n Даниличев Илья Андреевич\n Вариант 4.", "О программе");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.AllowWebBrowserDrop = false;
            openFileDialog1.ShowDialog();
            string[] repSplit = openFileDialog1.FileName.Split('\\');
            File = repSplit[repSplit.Length - 1];
            webBrowser1.Navigate(openFileDialog1.FileName);

            if (File == "chast1.html" || File == "chast2.html")
            {
                WindowState = FormWindowState.Maximized;
                toolStripStatusLabel1.Text = $"Открыто решение";
            }
            else
            {
                WindowState = FormWindowState.Normal;
                MessageBox.Show("Для данного файла не предусмотрено решение.\n Откройте файл chast1.html или chast2.html", "Ошибка");
                toolStripStatusLabel1.Text = $"Открыт не верный файл";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 formRez = new Form2();
                double x = Convert.ToDouble(textBox1.Text), y = Convert.ToDouble(textBox2.Text);
                if (File == "chast1.html")
                {
                    if (y <= 4 && y >= -4 && x >= -5 && x <= 5 && ((x >= 1 && y <= -2 * x + 6) || (y <= 0 && y <= (-x - 35) / 10) || (x <= 1 && y <= (7 * x + 17) / 6)))
                    {
                        if (y < 4 && y > -4 && x > -5 && x < 5 && ((x >= 1 && y < -2 * x + 6) || (y <= 0 && y < (-x - 35) / 10) || (x <= 1 && y < (7 * x + 17) / 6)))
                        {
                            formRez.Show();
                            formRez.result("Точка находится внутри фигуры");
                            toolStripStatusLabel1.Text = $"Точка находится внутри фигуры";
                        }
                        else
                        {
                            formRez.Show();
                            formRez.result("Точка находится на границе фигуры");
                            toolStripStatusLabel1.Text = $"Точка находится на границе фигуры";
                        }
                    }
                    else
                    {
                        formRez.Show();
                        formRez.result("Точка находится вне фигуры");
                        toolStripStatusLabel1.Text = $"Точка находится вне фигуры";

                    }
                }

                else if (File == "chast2.html")
                {
                    if (y<=-x && x*x +y*y>=2*2&& x>=-2 && y>=0)
                    {
                        if (y < -x && x * x + y * y > 2 * 2 && x > -2 && y > 0)
                        {
                            formRez.Show();
                            formRez.result("Точка находится внутри фигуры");
                            toolStripStatusLabel1.Text = $"Точка находится внутри фигуры";
                        }
                        else
                        {
                            formRez.Show();
                            formRez.result("Точка находится на границе фигуры");
                            toolStripStatusLabel1.Text = $"Точка находится на границе фигуры";

                        }
                    }
                    else
                    {
                        formRez.Show();
                        formRez.result("Точка находится вне фигуры");
                        toolStripStatusLabel1.Text = $"Точка находится вне фигуры";
                    }
                }
                else
                {
                    MessageBox.Show("Для данного файла не предусмотрено решение.\n Откройте файл chast1.html или chast2.html", "Ошибка");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show($"Похоже вы ввели не число.", "Ошибка");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"Форма загружена";
        }
    }
}
