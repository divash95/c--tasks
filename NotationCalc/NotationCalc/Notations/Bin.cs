using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationCalc.Notations
{
    public class Bin : Notation
    {
        public Bin()
        {
            bs = 2;
            alphabet = new Dictionary<char, int>();
            alphabet.Add('0', 0);
            alphabet.Add('1', 1);
            createArrsAdd();
            createArrsSub();
        }
    }
}
