using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Workers
{
    public class Vig : Worker
    {
        /// <summary>
        /// Ключ
        /// </summary>
        string key;

        Dictionary<Tuple<char, char>, char> chArr;

        public Vig(string k, Dictionary<Tuple<char, char>, char> arr)
        {
            chArr = arr;
            key = k.ToLower();
            for (int i = 0; i < k.Length; i++)
            {
                if (k[i]<'a' || k[i] > 'z')
                    throw new ArgumentException("Неверные параметры");
            }
        }

        public Vig(Vig v)
        {
            this.key = v.key;
            this.chArr = v.chArr;
        }

        public override string GetKey()
        {
            return key;
        }
        public override string Encrypt(string s)
        {
            string ns = "";
            Tuple<char, char> t;
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] >= 'a' && s[i] <= 'z') || s[i] >= 'A' && s[i] <= 'Z')
                {
                    if (s[i] >= 'a' && s[i] <= 'z')
                    {
                        t = new Tuple<char, char>(s[i], key[i]);
                        ns += chArr[t];
                    }
                    else
                    {
                        t = new Tuple<char, char>(Char.ToLower(s[i]), key[i]);
                        ns += char.ToUpper(chArr[t]);
                    }
                }
                else
                    ns += s[i];
            }
            return ns;
        }

        public override string Decode(string s)
        {
            string ns = "";
            Tuple<char, char> t;
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] >= 'a' && s[i] <= 'z') || s[i] >= 'A' && s[i] <= 'Z')
                {
                    char j = key[i];
                    if (s[i] >= 'a' && s[i] <= 'z')
                        for (char k = 'a'; k < 'z'; k++)
                        {
                            t = new Tuple<char, char>(j, k);
                            if (chArr[t] == s[i])
                            {
                                ns += k;
                                break;
                            }
                        }
                    else
                        for (char k = 'a'; k < 'z'; k++)
                        {
                            t = new Tuple<char, char>(j, k);
                            if (chArr[t] == char.ToLower(s[i]))
                            {
                                ns += char.ToUpper(k);
                                break;
                            }
                        }
                }
                else
                    ns += s[i];
            }
            return ns;
        }
    }
}
