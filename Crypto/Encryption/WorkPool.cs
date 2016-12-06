using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption.Workers;

namespace Encryption
{
    public class WorkPool
    {
        /// <summary>
        /// Список рабочих
        /// </summary>
        List<Worker> workers;

        public WorkPool(){}

        /// <summary>
        /// Создать пул из n рабочих, равных прототипу w
        /// </summary>
        /// <param name="n">кол-во рабочих</param>
        /// <param name="w">Прототип</param>
        public WorkPool(int n, Worker w)
        {
            workers = new List<Worker>();
            if (n <= 0)
                throw new ArgumentException("Неверные аргументы");
            if (w.GetType().Name == "Cesar")
                for (int i = 0; i < n; i++)
                    workers.Add(new Cesar(w as Cesar));
            else
                if (w.GetType().Name == "Vig")
                    for (int i = 0; i < n; i++)
                        workers.Add(new Vig(w as Vig));
                else
                    throw new ArgumentException("Неверные параметры");
        }

        public string GetKey()
        {
            if (workers.Count == 0)
                throw new ArgumentException("Неверные параметры");
            return workers[0].GetKey();
        }

        public int GetWorkCount()
        {
            return workers.Count;
        }
        
        /// <summary>
        /// Взять рабочего
        /// </summary>
        /// <returns></returns>
        public Worker Acquire()
        {
            if (workers.Count == 0)
            {
                throw new ArgumentOutOfRangeException("В списке нету обьектов");
            }
            var w = workers.First();
            workers.Remove(w);
            return w;
        }

        /// <summary>
        /// Вернуть рабочего
        /// </summary>
        /// <param name="w"></param>
        public void Release(Worker w)
        {
            workers.Add(w);
        }
    }
}
