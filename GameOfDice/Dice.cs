using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDice
{
    class Dice
    {
        public int value;
        public void rollDice()
        {
            Random rnd = new Random();
            this.value = rnd.Next(1, 6);
        }
    }
}
