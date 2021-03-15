using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace _2
{
    public partial class Form1 : Form
    {
        public Bank bank;
        public Form1()
        {
            InitializeComponent();
            bank = new Bank();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("ФИО должно быть указано.");
                return;
            }

            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Специальность должна быть указана.");
                return;
            }

            Client currentClient = new Client
            {
                Fio = textBox1.Text,
                TypeOfDeposit = comboBox1.Text,
                Born = dateTimePicker1.Value,
                Balance = trackBar1.Value,
                Prioritet = Decimal.ToInt32(numericUpDown1.Value),
            };
            if (radioButton1.Checked) { currentClient.InetBanking = true; }
            if (radioButton2.Checked) { currentClient.InetBanking = false; }

            if (checkBox1.Checked) { currentClient.Sex = checkBox1.Text; }
            if (checkBox2.Checked) { currentClient.Sex = checkBox2.Text; }
            if (checkBox1.Checked && checkBox2.Checked) { currentClient.Sex = "Транс"; }
            bank.Clients.Add(currentClient);
            listBox1.Items.Add(currentClient.Fio);
            listBox1.Items.Add(currentClient.Sex);
            listBox1.Items.Add(currentClient.TypeOfDeposit);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Bank));
            using (FileStream stream = new FileStream("Bank.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, bank);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Bank));
            using (FileStream stream = new FileStream("Bank.xml", FileMode.Open))
            {
                bank = serializer.Deserialize(stream) as Bank;
            }
            listBox1.Items.Add("\n---------- Начало считывания ----------\n");
            foreach (Client client in bank.Clients)
            {
                listBox1.Items.Add(client.Fio);
                listBox1.Items.Add(client.Sex);
                listBox1.Items.Add(client.TypeOfDeposit);
                listBox1.Items.Add(client.InetBanking);
                listBox1.Items.Add(client.Prioritet.ToString());
                listBox1.Items.Add(client.Balance.ToString());
                listBox1.Items.Add(client.Born);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Clear();
            trackBar1.Value = 0;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label8.Text = trackBar1.Value.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsDigit(e.KeyChar);
            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;
        }
    }
}
