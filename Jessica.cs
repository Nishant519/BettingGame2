using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BettingGame
{
    class Jessica : Punter
    {
        public override int Cash { get; set; }
        public override int Bet { get; set; }
        public override string Name { get; set; }
        public override bool OutOfMoney { get; set; }
        public override GreyHound greyhound { get; set; }
        public Jessica(int cash, bool outOfMoney)
        {
            Name = "Jessica";
            Cash = cash;
            OutOfMoney = outOfMoney;
        }
    }
}
