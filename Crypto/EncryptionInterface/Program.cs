using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using Encryption.Workers;

namespace EncryptionInterface
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            /*Crypto c = new Crypto();
            Vig v = new Vig("ABCDUfdsdsf", c.chArr);
            Cesar ces = new Cesar(5);
            c.ChangePool(5, v);
            string s = c.Encrypt("12A5bdawe'/.123 321 Asd s0.");
            string s1 = c.Decode(s);
            c.ChangePool(10, ces);
            string s2 = c.Encrypt("12A5bdawe'/.123 321 Asd s0.");
            string s3 = c.Decode(s2);*/
        }
    }
}
