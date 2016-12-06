using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption.Workers;

namespace Encryption
{
    public class Crypto
    {
        WorkPool pool = new WorkPool();

        const int n = 26;

        public Dictionary<Tuple<char, char>, char> chArr = new Dictionary<Tuple<char,char>,char>(n * n);

        public  Crypto()
        {
            createArr();
        }

        /// <summary>
        /// Создается массив для Виженера
        /// </summary>
        void createArr()
        {

            int a = (int)'a';
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    char c = (char)((i + j) % n + a);
                    chArr.Add(new Tuple<char, char>((char)(i + a), (char)(j + a)), c);
                }
            }
        }
        /// <summary>
        /// Поменять пул
        /// </summary>
        /// <param name="n">кол-во рабочих</param>
        /// <param name="w">Прототип рабочего</param>
        public void ChangePool(int n, Worker w)
        {
            pool = new WorkPool(n, w);
        }

        /// <summary>
        /// Возвращает ключ
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            return pool.GetKey();
        }

        /// <summary>
        /// Возвращает кол-во рабочих
        /// </summary>
        /// <returns></returns>
        public int GetWorkCount()
        {
            return pool.GetWorkCount();
        }
        /// <summary>
        /// Зашифровать строку
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Encrypt(string s)
        {
            if (s.Length != 0)
            {
                string s1 = "";
                int n = pool.GetWorkCount();
                string[] arrs = divideStr(n, s);
                for (int i = 0; i < arrs.Length; i++)
                {
                    var w = pool.Acquire();
                    s1 += w.Encrypt(arrs[i]);
                    pool.Release(w);
                }
                return s1;
            }
            else return s;
        }

        /// <summary>
        /// Расшифровать строку
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Decode(string s)
        {
            if (s.Length != 0)
            {
                string s1 = "";
                int n = pool.GetWorkCount();
                string[] arrs = divideStr(n, s);
                for (int i = 0; i < arrs.Length; i++)
                {
                    var w = pool.Acquire();
                    s1 += w.Decode(arrs[i]);
                    pool.Release(w);
                }
                return s1;
            }
            else return s;
        }

        /// <summary>
        /// Разделить строку на n частей
        /// </summary>
        /// <param name="n"></param>
        /// <param name="s"></param>
        /// <returns>массив строк</returns>
        string[] divideStr(int n, string s)
        {
            if (n <= 0)
                throw new ArgumentException("Неверные параметры");
            int m = n;
            if (n > s.Length)
                m = 1;
            string[] sarr = new string[m];
            int d = s.Length / m;
            int x = 0;
            for (int i = 0; i < m - 1; i++)
            {
                sarr[i] = s.Substring(x, d);
                x += d;
            }
            if (x < s.Length)
                sarr[m - 1] = s.Substring(x, s.Length - x);
            return sarr;
        }
    }
}
