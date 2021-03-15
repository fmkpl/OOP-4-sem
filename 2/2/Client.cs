using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    [Serializable]
    public class Client
    {
        public string Fio { get; set; }
        public DateTime Born {get;set;}
        public string Sex { get; set; }
        public int Balance { get; set; }
        public int Prioritet { get; set; }
        public string TypeOfDeposit { get; set; }
        public bool InetBanking { get; set; }
        public BankAccount bankAccount { get; set; }
        
    }
}
