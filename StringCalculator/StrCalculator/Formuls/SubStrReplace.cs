using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator.Formuls
{
    /// <summary>
    /// Замена одной подстроки на другую
    /// </summary>
    public class SubStrReplace: Operation
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="prevF">Предыдущая формула</param>
        /// <param name="arg1">Символ</param>
        public SubStrReplace(Formula prevF, Formula arg1, Formula arg2)
        {
            this.prevF = prevF;
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.s = "(" + prevF.s + ") @ (" + arg1.s + ", " + arg2.s + ")";
        }

        /// <summary>
        /// Подстрока, которую заменяем
        /// </summary>
        public Formula arg1;

        /// <summary>
        /// Подстрока, на которую заменяем
        /// </summary>
        public Formula arg2;

        public override string Calculate()
        {
            string x1 = arg1.Calculate();
            string x2 = arg2.Calculate();
            string x = prevF.Calculate();
            return x.Replace(x1, x2);
        }
    }
}
