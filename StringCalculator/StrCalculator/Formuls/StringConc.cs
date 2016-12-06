using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator.Formuls
{
    /// <summary>
    /// Слияние строк
    /// </summary>
    public class StringConc : Operation
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="prevF">Формула, к которой применяется операция</param>
        /// <param name="arg1">Константа или переменная</param>
        public StringConc(Formula prevF, Formula arg1)
        {
            this.prevF = prevF;
            this.arg1 = arg1;
            this.s = "(" + prevF.s + ") && " + arg1.s;
        }

        /// <summary>
        /// Строка, с которой сливаем
        /// </summary>
        public Formula arg1;

        public override string Calculate()
        {
            string x1 = arg1.Calculate();
            string x = prevF.Calculate();
            return x + x1;
        }
    }
}
