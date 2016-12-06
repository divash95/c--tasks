using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Workers
{
    public class Cesar:Worker
    {
        /// <summary>
        /// Ключ
        /// </summary>
        int key;

        public Cesar(int k)
        {
            key = k;
        }

        public Cesar(Cesar c)
        {
            this.key = c.key;
        }

        public override string GetKey()
        {
            return key.ToString();
        }

        public override string Encrypt(string s)
        {
            string ns = "";
            int a = (int)'a';
            int a2 = (int)'A';
            int shift;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'a' && s[i] <= 'z')
                {
                    shift = ((int)s[i] - a + key) % 26;
                    if (shift >= 0)
                        ns += (char)(shift + a);
                    else
                        ns += (char)(shift + (int)'z');
                }
                else
                    if (s[i] >= 'A' && s[i] <= 'Z')
                    {
                        shift = ((int)s[i] - a2 + key) % 26;
                        if (shift >= 0)
                            ns += (char)(shift + a2);
                        else
                            ns += (char)(shift + (int)'Z');
                    }
                    else
                        ns += s[i];
            }
            return ns;
        }

        public override string Decode(string s)
        {
            string ns = "";
            int a = (int)'a';
            int a2 = (int)'A';
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= (char)(a) && s[i] <= (char)((int)'z'))
                {
                    int shift = (int)s[i] - a - key % 26;
                    if (shift > 0)
                        ns += (char)(shift + a);
                    else
                        ns += (char)((int)'z' + shift);
                }
                else
                    if (s[i] >= (char)(a2) && s[i] <= (char)((int)'Z'))
                    {
                        int shift = (int)s[i] - a2 - key % 26;
                        if (shift > 0)
                            ns += (char)(shift + a2);
                        else
                            ns += (char)((int)'Z' + shift);
                    }
                    else
                        ns += s[i];
            }
            return ns;
        }
    }
}
