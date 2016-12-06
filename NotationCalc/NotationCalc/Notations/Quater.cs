using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationCalc.Notations
{
    public class Quater : Notation
    {
        public Quater()
        {
            bs = 4;
            alphabet = new Dictionary<char, int>();
            alphabet.Add('0', 0);
            alphabet.Add('1', 1);
            alphabet.Add('2', 2);
            alphabet.Add('3', 3);
            createArrsAdd();
            createArrsSub();
        }
    }
}
