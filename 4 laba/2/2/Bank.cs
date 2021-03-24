using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    [Serializable]
    public class Bank : AbstractBank
    {
        public List<Client> Clients { get; set; }
        public BankAccount bankAccount { get; set; }
        public Bank()
        {
            bankAccount = new BankAccount();
            Clients = new List<Client>();
        }

        public override AbstractClientA CreateClientA()
        {
            return new Client();
        }
        public override AbstractClientB CreateClientB()
        {
            return new ClientB1();
        }
    }
}