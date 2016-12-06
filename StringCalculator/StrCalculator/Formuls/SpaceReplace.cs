using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator.Formuls
{
    /// <summary>
    /// Заменить пробелы на символ
    /// </summary>
    public class SpaceReplace : Operation
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="prevF">Предыдущая формула</param>
        /// <param name="arg1">Символ</param>
        public SpaceReplace(Formula prevF, Formula arg1)
        {
            this.prevF = prevF;
            this.arg1 = arg1;
            this.s = "(" + prevF.s + ") # " + arg1.s;
        }

        /// <summary>
        /// символ, на который заменяем пробел
        /// </summary>
        public Formula arg1;


        public override string Calculate()
        {
            string x1 = arg1.Calculate();
            if (x1.Length != 1)
                throw new ArgumentException("Попытка заменить пробел не на символ");
            string x = prevF.Calculate();
            return x.Replace(" ", x1);
        }
    }
}
