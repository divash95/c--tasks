using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationCalc.Notations
{
    public class Dec : Notation
    {
        public Dec()
        {
            bs = 10;
            alphabet = new Dictionary<char, int>();
            for (int i = 0; i < 10; i++)
            {
                alphabet.Add((char)(i + 48), i);
            }
            createArrsAdd();
            createArrsSub();
        }
    }
}
