using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2
{
    [Serializable]
    public class Client
    {
        [Required (ErrorMessage = "Поле должно быть установлено.")]
        public string Fio { get; set; }
        public DateTime Born {get;set;}
        public string Sex { get; set; }
        [Range (10, 49, ErrorMessage = "Баланс минимум от 10 и максимум до 49")]
        public int Balance { get; set; }
        public int Prioritet { get; set; }
        [Required (ErrorMessage = "Некорректный тип депозита")]
        public string TypeOfDeposit { get; set; }
        public bool InetBanking { get; set; }
        public BankAccount bankAccount { get; set; }
        
    }
}
