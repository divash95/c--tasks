using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotationCalc.Notations;

namespace NotationCalc
{
    public class Calculator
    {
        public Calculator(Notation n)
        {
            curNotation = n;
            prevOp = 2;
            res = "0";
        }

        /// <summary>
        /// Система счисления
        /// </summary>
        Notation curNotation;

        /// <summary>
        /// Результат
        /// </summary>
        private string res;

        /// <summary>
        /// Предыдущая операция
        /// </summary>
        int prevOp;

        /// <summary>
        /// Прибавляет число
        /// </summary>
        /// <param name="arg1"></param>
        public void Add(string arg1)
        {
            if (arg1 == "")
                arg1 = "0";
            if (prevOp == 0)
                res = curNotation.Add(arg1, res);
            else
                if (prevOp == 1)
                    res = curNotation.Sub(res, arg1);
                else
                    res = arg1;
            prevOp = 0;
        }

        /// <summary>
        /// Отнимает число
        /// </summary>
        /// <param name="arg1"></param>
        public void Sub(string arg1)
        {
            if (arg1 == "")
                arg1 = "0";
            if (prevOp == 1)
                res = curNotation.Sub(res, arg1);
            else
                if (prevOp == 0)
                    res = curNotation.Add(arg1, res);
                else
                    res = arg1;
            prevOp = 1;
        }

        /// <summary>
        /// Возвращает результат
        /// </summary>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public string Calculate(string arg1)
        {
            if (arg1 == "")
                arg1 = "0";
            string x = "0";
            switch (prevOp)
            {
                case 0:
                    Add(arg1);
                    x = res;
                    break;
                case 1:
                    Sub(arg1);
                    x = res;
                    break;
                default:
                    res = "0";
                    break;
            }
            prevOp = 2;
            return x;
        }

        /// <summary>
        /// Переводит число в десятичную  систему
        /// </summary>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public string ToDec(string arg1)
        {
            return curNotation.ToDec(arg1);
        }

        /// <summary>
        /// Сброс
        /// </summary>
        public void Reset()
        {
            res = "0";
            prevOp = -1;
        }

        /// <summary>
        /// Задать систему счисления
        /// </summary>
        /// <param name="n"></param>
        public void SetNotation(Notation n)
        {
            curNotation = n;
        }

        /// <summary>
        /// Получить систему счисления
        /// </summary>
        public Notation GetNotation()
        {
            return curNotation;
        }


    }
}
