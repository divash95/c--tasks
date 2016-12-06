using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator.Formuls
{
    /// <summary>
    /// Абстрактная формула
    /// </summary>
    public abstract class Formula
    {
        /// <summary>
        /// Строковое представление Всей формулы  формулы
        /// </summary>
        public string s;

        /// <summary>
        /// Предыдущая формула
        /// </summary>
        /// <returns></returns>
        public abstract Formula Prev();

        /// <summary>
        /// Посчитать значение формулы
        /// </summary>
        /// <returns></returns>
        public abstract string Calculate();
    }
}
