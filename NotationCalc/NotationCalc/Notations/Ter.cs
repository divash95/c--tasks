using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationCalc.Notations
{
    public class Ter : Notation
    {
        public Ter()
        {
            bs = 3;
            alphabet = new Dictionary<char, int>();
            alphabet.Add('0', 0);
            alphabet.Add('1', 1);
            alphabet.Add('2', 2);
            createArrsAdd();
            createArrsSub();
        }
    }
}
