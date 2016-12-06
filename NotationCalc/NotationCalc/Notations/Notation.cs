using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationCalc.Notations
{
    public abstract class Notation
    {
        /// <summary>
        /// Таблица сложения
        /// </summary>
        protected char[,] arrAdd;

        /// <summary>
        /// Таблица переходов при сложении
        /// </summary>
        protected int[,] arrAdd2;

        /// <summary>
        /// Таблица вычитания
        /// </summary>
        protected char[,] arrSub;

        /// <summary>
        /// Таблица переходов при вычитании
        /// </summary>
        protected int[,] arrSub2;

        /// <summary>
        /// Алфавит
        /// </summary>
        public Dictionary<char, int> alphabet;

        /// <summary>
        /// Основание
        /// </summary>
        public int bs;

        /// <summary>
        /// Вычисляет сумму
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public string Add(string arg1, string arg2)
        {
            string res = "";
            if (arg1[0] == '-')
                if (arg2[0] == '-')
                    res = posSub("0", posAdd(arg1.Substring(1, arg1.Length - 1), arg2.Substring(1, arg2.Length - 1)));
                else
                    res = posSub(arg2, arg1.Substring(1, arg1.Length - 1));
            else
                if (arg2[0] == '-')
                    res = posSub(arg1, arg2.Substring(1, arg2.Length - 1));
                else
                    res = posAdd(arg1, arg2);
            return res;
        }

        /// <summary>
        /// Вычисляет вычитание
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public string Sub(string arg1, string arg2)
        {
            string res = "";
            if (arg1[0] == '-')
                if (arg2[0] == '-')
                    res = posSub(arg2.Substring(1, arg2.Length - 1), arg1.Substring(1, arg1.Length - 1));
                else
                    res = posSub("0", posAdd(arg1.Substring(1, arg1.Length - 1), arg2));
            else
                if (arg2[0] == '-')
                    res = posAdd(arg1, arg2.Substring(1, arg2.Length - 1));
                else
                    res = posSub(arg1, arg2);
            return res;
        }

        /// <summary>
        /// Вычисляет сумму положительных чисел
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        string posAdd(string arg1, string arg2)
        {
            int xlen;
            if (arg1.Length >= arg2.Length)
            {
                xlen = arg1.Length - arg2.Length;
                for (int i = 0; i < xlen; i++)
                    arg2 = "0" + arg2;
            }
            else
            {
                xlen = arg2.Length - arg1.Length;
                for (int i = 0; i < xlen; i++)
                    arg1 = "0" + arg1;
            }
            string res = "";
            int m = 0;
            for (int i = arg1.Length - 1; i >= 0; i--)
            {
                int x = alphabet[arg1[i]];
                res = arrAdd[alphabet[arg1[i]], alphabet[arrAdd[alphabet[arg2[i]], m]]] + res;
                if (arrAdd2[alphabet[arg1[i]], alphabet[arrAdd[alphabet[arg2[i]], m]]] == 1 || arrAdd2[alphabet[arg2[i]], m] == 1)
                    m = 1;
                else
                    m = 0;
            }
            if (m == 1)
                res = '1' + res;
            return res;
        }

        /// <summary>
        /// Вычисляет вычитание положительных чисел
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        string posSub(string arg1, string arg2)
        {
            int xlen;
            int sgn = 0;
            if (arg1.Length >= arg2.Length)
            {
                xlen = arg1.Length - arg2.Length;
                for (int i = 0; i < xlen; i++)
                    arg2 = "0" + arg2;
            }
            else
            {
                string x = arg1;
                arg1 = arg2;
                arg2 = x;
                xlen = arg1.Length - arg2.Length;
                for (int i = 0; i < xlen; i++)
                    arg2 = "0" + arg2;
                sgn = 1;
            }
            string res = "";
            int m = 0;
            for (int i = arg1.Length - 1; i >= 0; i--)
            {
                res = arrSub[alphabet[arrSub[alphabet[arg1[i]], m]], alphabet[arg2[i]]] + res;
                if (arrSub2[alphabet[arrSub[alphabet[arg1[i]], m]], alphabet[arg2[i]]] == 1 || arrSub2[alphabet[arg1[i]], m] == 1)
                    m = 1;
                else
                    m = 0;
            }
            if (m == 1)
            {
                res = posSub(arg2, arg1);
                sgn = 1;
            }
            while (res[0] == '0' && res.Length != 1)
            {
                res = res.Substring(1, res.Length - 1);
            }
            if (sgn == 1)
                res = '-' + res;
            return res;
        }

        /// <summary>
        /// Переводит число в десятичную систему
        /// </summary>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public string ToDec(string arg1)
        {
            if (bs == 10)
                return arg1;
            string res = "";
            int sgn = 0;
            if (arg1[0] == '-')
            {
                sgn = 1;
                arg1 = arg1.Substring(1, arg1.Length - 1);
            }
            long x = 0;
            long pow = 1;
            for (int i = arg1.Length - 1; i >= 0; i--)
            {
                x += alphabet[arg1[i]] * pow;
                pow *= bs;
            }
            res = x.ToString();
            if (sgn == 1)
                res = "-" + res;
            return res;
        }

        /// <summary>
        /// Переводит число из десятичной системы
        /// </summary>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public string FromDec(string arg1)
        {
            if (bs == 10)
                return arg1;
            string res = "";
            int sgn = 0;
            if (arg1[0] == '-')
            {
                sgn = 1;
                arg1 = arg1.Substring(1, arg1.Length - 1);
            }
            long x;
            Int64.TryParse(arg1, out x);
            if (x == 0)
                res = "0";
            while (x != 0)
            {
                res = alphabet.First(y => y.Value == (x % bs)).Key + res;
                x /= bs;
            }
            if (sgn == 1)
                res = "-" + res;
            return res;
        }

        /// <summary>
        /// Создает таблицы сложния
        /// </summary>
        protected void createArrsAdd()
        {
            arrAdd = new char[bs, bs];
            arrAdd2 = new int[bs, bs];
            for (int i = 0; i < bs; i++)
                for (int j = 0; j < bs; j++)
                {
                    arrAdd[i, j] = alphabet.First(x => x.Value == ((i + j) % bs)).Key;
                    arrAdd2[i, j] = ((i + j) / bs);
                }

        }

        /// <summary>
        /// Создает таблицы вычитания
        /// </summary>
        protected void createArrsSub()
        {
            arrSub = new char[bs, bs];
            arrSub2 = new int[bs, bs];
            for (int i = 0; i < bs; i++)
                for (int j = 0; j < bs; j++)
                {
                    arrSub[i, j] = alphabet.First(x => x.Value == ((i + bs - j) % bs)).Key;
                    if (((i + bs - j) / bs) == 1)
                        arrSub2[i, j] = 0;
                    else
                        arrSub2[i, j] = 1;
                }
        }

    }
}
