using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace _2
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {  
            groupBox1.Visible = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex r1 = new Regex(textBox1.Text);
            Bank bank = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Bank));
            using (FileStream stream = new FileStream("Bank.xml", FileMode.Open))
            {
                bank = serializer.Deserialize(stream) as Bank;
            }
            listBox1.Items.Clear();
            List<Client> searchResult = new List<Client>();
            foreach (Client client in bank.Clients)
            {
                if (r1.IsMatch(client.Fio))
                {
                    if (checkBox1.Checked)
                    {
                        if (comboBox1.Text.Length > 0 && comboBox1.Text != client.TypeOfDeposit)
                            continue;
                        if (numericUpDown1.Value != client.Prioritet)
                            continue;
                        if (Decimal.ToDouble(numericUpDown2.Value) > client.Balance)
                            continue;
                    }
                    //listBox1.Items.Add(client.Fio);
                    searchResult.Add(client);
                }
            }
            IEnumerable<Client> ordered = null;
            if (domainUpDown1.Text == "По приоритету")
                ordered = searchResult.OrderBy(p => p.Prioritet);
            else
                ordered = searchResult.OrderBy(p => p.Fio);

            foreach (Client item in ordered)
                listBox1.Items.Add(item.Sex);
                

        }
    }
}
