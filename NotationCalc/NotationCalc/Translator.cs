using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotationCalc.Notations;

namespace NotationCalc
{
    public class Translator
    {
        public Translator()
        {
            aNot = new Dec();
            bNot = new Dec();
        }

        /// <summary>
        /// Система счисления A
        /// </summary>
        public Notation aNot;

        /// <summary>
        /// Система счисления B
        /// </summary>
        public Notation bNot;

        /// <summary>
        /// Перевести число в систему B
        /// </summary>
        /// <param name="a">Число в системе A</param>
        /// <returns></returns>
        public string AtoB(string a)
        {
            string ad = aNot.ToDec(a);
            return bNot.FromDec(ad);
        }

        /// <summary>
        /// Перевести число в систему A
        /// </summary>
        /// <param name="b">Число в системе B</param>
        /// <returns></returns>
        public string BtoA(string b)
        {
            string bd = bNot.ToDec(b);
            return aNot.FromDec(bd);

        }
    }
}
