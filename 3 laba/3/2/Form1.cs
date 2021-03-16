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
using System.ComponentModel.DataAnnotations;

namespace _2
{
    public partial class Form1 : Form
    {
        public Bank bank;
        private List<string> memb = new List<string>() { };
        public Form1()
        {
            InitializeComponent();
            bank = new Bank();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0)
                {
                    //MessageBox.Show("ФИО должно быть указано.");
                    return;
                }

                if (comboBox1.Text.Length == 0)
                {
                    //MessageBox.Show("Тип депозита должен быть указан.");
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

                var results = new List<ValidationResult>();
                var context = new ValidationContext(currentClient);
                if (!Validator.TryValidateObject(currentClient, context, results, true))
                {
                    string errorString = "";
                    foreach (var error in results)
                        errorString += error + "\n";
                    MessageBox.Show(errorString);
                }


                bank.Clients.Add(currentClient);
                listBox1.Items.Add(currentClient.Fio);

                toolStripStatusLabel1.Text = $"Элементов {listBox1.Items.Count}";
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"{ex.GetType()}");
            }
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
                listBox1.Items.Add("ФИО: " + client.Fio);
                listBox1.Items.Add("Пол: " + client.Sex);
                listBox1.Items.Add("Тип депозита: " + client.TypeOfDeposit);
                listBox1.Items.Add("Интернет-банкинг: " + client.InetBanking);
                listBox1.Items.Add("Приоритет: " + client.Prioritet.ToString());
                listBox1.Items.Add("Баланс: " + client.Balance.ToString());
                listBox1.Items.Add("Дата рождения: " + client.Born);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Копыл Ефим Игоревич 2-4");
        }

        private void типДепозитаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(Bank));
            using (FileStream stream = new FileStream("Bank.xml", FileMode.Open))
                bank = serializer.Deserialize(stream) as Bank;

            IEnumerable<Client> ordered = bank.Clients.OrderBy(p => p.Fio);
            foreach (Client client in ordered)
                listBox1.Items.Add(client.Fio);
        }

        private void датаРожденияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(Bank));
            using (FileStream stream = new FileStream("Bank.xml", FileMode.Open))
                bank = serializer.Deserialize(stream) as Bank;

            IEnumerable<Client> ordered = bank.Clients.OrderBy(p => p.Born);
            foreach (Client client in ordered)
                listBox1.Items.Add(client.Fio);

            toolStripStatusLabel1.Text = $"Элементов {listBox1.Items.Count}";
        }

        private void поискToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Search search = new Search();
            search.ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int del = listBox1.Items.Count - 1;
                memb.Add((string)listBox1.Items[del]);
                listBox1.Items.RemoveAt(del);
            }
            catch (Exception ex) { MessageBox.Show("Лист пуст."); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add(memb[memb.Count - 1]);
                memb.RemoveAt(memb.Count - 1);
            }
            catch (Exception ex) { MessageBox.Show("Больше вы не добавляли."); }
        }
    }
}
