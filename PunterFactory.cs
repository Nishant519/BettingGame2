using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BettingGame
{
    public static class PunterFactory
    {
        public static Punter AddPunter(String name)
        {
            Punter punter = null;

            if (name == "Jessica")
                punter = new Jessica(50, false);
            else if (name == "John")
                return new John(50, false);
            else if (name == "David")
                return new David(50, false);
            return punter;
        }

       
    }
}
