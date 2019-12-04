using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BettingGame
{
    class David : Punter
    {
        public override int Cash { get; set; }
        public override int Bet { get; set; }
        public override string Name { get; set; }
        public override bool OutOfMoney { get; set; }
        public override GreyHound greyhound { get; set; }
        public David(int cash, bool outOfMoney)
        {
            Name = "David";
            Cash = cash;
            OutOfMoney = outOfMoney;
        }
    }
}
