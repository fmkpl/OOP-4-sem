using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] rusEurArray = new string[] { "38", "39", "40", "41", "42", "43", "44", "45", "46", "47" };
            string[] usaArray = new string[] { "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
            string[] engArray = new string[] { "5", "6", "7", "8", "9", "10", "11", "12", "13", "14" };
            string[] jpnArray = new string[] { "24", "25", "26", "27", "28", "29", "30", "31", "32", "33" };

            try
            {
                int tr = 0;
                tr = System.Convert.ToInt32(textBox1.Text);
                if (tr < 0)
                {
                    throw new Exception("неверный ввод.");
                }
                if (textBox1.Text.ToString() == "")
                {
                    throw new Exception("неверный ввод.");
                }

                if (radioButton1.Checked)
                {
                    for (int i = 0; i < rusEurArray.Length; i++)
                    {
                        if (textBox1.Text.ToString() == rusEurArray[i])
                        {
                            label1.Text = $"= США: {usaArray[i]}\n   Англия: {engArray[i]}\n   Япония: {jpnArray[i]}\n";
                        }
                    }
                }

                if (radioButton2.Checked)
                {
                    for (int i = 0; i < usaArray.Length; i++)
                    {
                        if (textBox1.Text.ToString() == usaArray[i])
                        {
                            label1.Text = $"= Россия/Европа: {rusEurArray[i]}\n   Англия: {engArray[i]}\n   Япония: {jpnArray[i]}\n";
                        }
                    }
                }

                if (radioButton3.Checked)
                {
                    for (int i = 0; i < engArray.Length; i++)
                    {
                        if (textBox1.Text.ToString() == engArray[i])
                        {
                            label1.Text = $"= Россия/Европа: {rusEurArray[i]}\n   США: {usaArray[i]}\n   Япония: {jpnArray[i]}\n";
                        }
                    }
                }

                if (radioButton4.Checked)
                {
                    for (int i = 0; i < jpnArray.Length; i++)
                    {
                        if (textBox1.Text.ToString() == jpnArray[i])
                        {
                            label1.Text = $"= Россия/Европа: {rusEurArray[i]}\n   США: {usaArray[i]}\n   Англия: {engArray[i]}\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Конвертер", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                MessageBox.Show("Исключение обработано.", "Конвертер", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "=";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }
    }
}
