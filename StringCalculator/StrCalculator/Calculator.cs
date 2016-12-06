using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrCalculator.Formuls;

namespace StrCalculator
{
    public class Calculator
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Calculator()
        {
            formul = new Constant("");
            vars = new Dictionary<string, string>();
        }
        /// <summary>
        /// Последняя операция
        /// </summary>
        public Formula formul;

        /// <summary>
        /// Словарь переменных
        /// </summary>
        public Dictionary<string, string> vars;

        /// <summary>
        /// Добавляет переменную в список переменных
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Значение</param>
        public void AddVar(string name, string value)
        {
            if (vars.ContainsKey(name) || name == "")
                throw new FormatException();
            else
                vars.Add(name, value);
            
        }

        /// <summary>
        /// Удаляет переменную из списка
        /// </summary>
        /// <param name="name">имя</param>
        public void DelVar(string name)
        {
            vars.Remove(name);
        }

        /// <summary>
        /// Изменяет значение переменной
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Новое значение</param>
        public void ChangeVar(string name, string value)
        {
            if (vars.ContainsKey(name) && vars[name] != value)
                vars[name] = value;
        }
        /// <summary>
        /// Сбросить калькулятор(переменные остаются)
        /// </summary>
        public void Reset()
        {
            formul = new Constant("");
            vars.Clear();
        }

        /// <summary>
        /// Расширить формулу
        /// </summary>
        /// <param name="op">Операция</param>
        public void Extend(Formula op)
        {
            formul = op;
        }

        /// <summary>
        /// Вернутся к педыдущей формуле
        /// </summary>
        public void Prev()
        {
            formul = formul.Prev();
        }

        /// <summary>
        /// Получить строковое представление формулы
        /// </summary>
        /// <returns></returns>
        public string GetStr()
        {
            return formul.s;
        }

        /// <summary>
        /// Вычислить формулу
        /// </summary>
        /// <returns></returns>
        public string Calculate()
        {
            return formul.Calculate();
        }
    }
}
