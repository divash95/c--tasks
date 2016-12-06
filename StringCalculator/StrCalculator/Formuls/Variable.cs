using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator.Formuls
{
    /// <summary>
    /// Переменная
    /// </summary>
    public class Variable : Formula
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="n">Имя переменной</param>
        /// <param name="vs">Словарь, в котором хранятся переменые</param>
        public Variable(string n, Dictionary<string, string> vs)
        {
            this.vars = vs;
            this.s = n;
        }

        /// <summary>
        /// Словарь, в котором хранятся переменные
        /// </summary>
        public Dictionary<string, string> vars;

        /// <summary>
        /// Предыдущая формула
        /// </summary>
        /// <returns></returns>
        public override Formula Prev()
        {
            return new Constant();
        }


        public override string Calculate()
        {
            if (!vars.ContainsKey(s))
                throw new NullReferenceException("Попытка вычислить несуществующую переменную");
            else
                return vars[s];
        }

    }
}
