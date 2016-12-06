using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator.Formuls
{
    /// <summary>
    /// Удаление подстроки
    /// </summary>
    public class SubStrRemove : Operation
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="prevF">Предыдущая формула</param>
        /// <param name="arg1">Аргумент операции</param>
        public SubStrRemove(Formula prevF, Formula arg1)
        {
            this.prevF = prevF;
            this.arg1 = arg1;
            this.s = "(" + prevF.s + ") ! " + arg1.s;
        }

        /// <summary>
        /// Подстрока, которую удаляем
        /// </summary>
        public Formula arg1;

        SubStrRemover sr;

        public override string Calculate()
        {
            string x1 = arg1.Calculate();
            string x = prevF.Calculate();
            sr = new SubStrRemover(x1);
            return sr.Remove(x);
        }
    }

    public class SubStrRemover
    {
        /// <summary>
        /// Удаляемая подстрока
        /// </summary>
        string subs;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="subs">Удаляемая подстрока</param>
        public SubStrRemover(string subs)
        {
            this.subs = subs;
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="s">Строка, из которой удаляем</param>
        /// <returns></returns>
        public string Remove(string s)
        {
            s = s.Replace(subs, "");
            return s;
        }
    }
}
