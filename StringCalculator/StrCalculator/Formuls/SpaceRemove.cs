using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator.Formuls
{
    /// <summary>
    /// Удалить первые и последние пробелы
    /// </summary>
    public class SpaceRemove : Operation
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pF">Предыдущая формула</param>
        public SpaceRemove(Formula pF)
        {
            prevF = pF;
            this.s = "^(" + prevF.s + ")";

        }

        public override string Calculate()
        {
            string x = prevF.Calculate();
            string res = x.Trim();
            return res;
        }
    }
}
