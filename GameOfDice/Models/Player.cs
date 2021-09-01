using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDice.Models
{
    public class Player
    {
        public string name { get; set; }
        public int score { get; set; }
        public int rank { get; set; }
        public int lastRollValue { get; set; }
        public bool skipRoll { get; set; }
        public Player()
        {
            lastRollValue = 0;
            score = 0;
            skipRoll = false;
            rank = -1;
        }
    }
}
