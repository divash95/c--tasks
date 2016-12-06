using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator.Formuls
{
    /// <summary>
    /// Константа
    /// </summary>
    public class Constant : Formula
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="v">Значение</param>
        public Constant(string v)
        {
            this.s = "'" + v + "'";
        }

        public Constant()
        {
            this.s = "";
        }

        /// <summary>
        /// Возвращает предыдущую формулу
        /// </summary>
        /// <returns></returns>
        public override Formula Prev()
        {
            return new Constant();
        }

        /// <summary>
        /// Вычисяет Константу
        /// </summary>
        /// <returns></returns>
        public override string Calculate()
        {
            if (s != "")
                return s.Substring(1, s.Length - 2);
            else
                return "";
        }
    }
}
