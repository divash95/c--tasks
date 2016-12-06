using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationCalc.Notations
{
    public class Hex : Notation
    {

        public Hex()
        {
            bs = 16;
            alphabet = new Dictionary<char, int>();
            for (int i = 0; i < 10; i++)
            {
                alphabet.Add((char)(i + 48), i);
            }
            alphabet.Add('A', 10);
            alphabet.Add('B', 11);
            alphabet.Add('C', 12);
            alphabet.Add('D', 13);
            alphabet.Add('E', 14);
            alphabet.Add('F', 15);
            createArrsAdd();
            createArrsSub();
        }
    }
}
