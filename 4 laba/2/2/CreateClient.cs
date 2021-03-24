using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class CreateClient
    {
        private AbstractClientA abstractClientA;
        private AbstractClientB abstractClientB;

        public CreateClient(AbstractBank abstractBank) 
        {
            abstractClientA = abstractBank.CreateClientA();
            abstractClientB = abstractBank.CreateClientB();
        }

        public CreateClient() { }
    }
}
