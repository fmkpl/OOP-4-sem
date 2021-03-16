using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2
{
    class RangeAtribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                double r = Double.Parse(value.ToString());
                if (r >= 0 && r <= 10)
                    return true;
                else
                    ErrorMessage = "Средний бал должен быть между 0 и 10";
            }
            return false;
        }
    }
}
