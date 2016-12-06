using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Workers
{
    public abstract class Worker
    {
        /// <summary>
        /// Зашифровать строку
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public abstract string Encrypt(string s);

        /// <summary>
        /// Расшифровать строку
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public abstract string Decode(string s);

        /// <summary>
        /// Возвращает ключ
        /// </summary>
        /// <returns></returns>
        public abstract string GetKey();
    }
}
