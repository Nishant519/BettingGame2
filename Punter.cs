using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BettingGame
{
    public abstract class Punter
    {
        public abstract string Name { get; set; }
        public abstract int Cash { get; set; }
        public abstract int Bet { get; set; }
        public abstract bool OutOfMoney { get; set; }

        public abstract GreyHound greyhound { get; set; }
    }
}
