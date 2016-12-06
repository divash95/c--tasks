using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrCalculator.Formuls
{
    //Абстрактная операция
    public abstract class Operation:Formula
    {
        /// <summary>
        /// Хранит формулу, к которй применяется операция
        /// </summary>
        protected Formula prevF;

        /// <summary>
        /// Возвращает формулу, к которй применяется операция
        /// </summary>
        /// <returns></returns>
        public override Formula Prev()
        {
            return prevF;
        }
    }
}
