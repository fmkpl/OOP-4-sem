using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    public abstract class AbstractBank
    {
        public abstract AbstractClientA CreateClientA();
        public abstract AbstractClientB CreateClientB();
    }

    class ConcreteBank2 : AbstractBank
    {
        public override AbstractClientA CreateClientA()
        {
            return new ClientA2();
        }

        public override AbstractClientB CreateClientB()
        {
            return new ClientB2();
        }
    }

    public abstract class AbstractClientA { }
    public abstract class AbstractClientB { }


    class ClientA1 : AbstractClientA { }
    class ClientA2 : AbstractClientA { }
    class ClientB1 : AbstractClientB { }
    class ClientB2 : AbstractClientB { }
}
