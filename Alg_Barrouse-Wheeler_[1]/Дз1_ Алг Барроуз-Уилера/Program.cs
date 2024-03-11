using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oruvnwpi23k
{
    internal class Program
    {
        static void Sorter(string[] mas)
        {
            for (int i = 0; i < mas.Length; ++i)
            {
                for (int j = 0; j < mas.Length - 1; ++j)
                {
                    if (String.Compare(mas[j], mas[j + 1]) > 0)
                    {
                        (mas[j], mas[j + 1]) = (mas[j + 1], mas[j]);

                    }
                }
            }
        }

        static void BarrW()
        {
            string s = Console.ReadLine();
            string[] mas = new string[s.Length];
            for (int i = 0; i < s.Length; ++i)
            {
                mas[i] = s.Substring(i, s.Length - i);
            }
            Sorter(mas);
            string s2 = "";
            s = "$" + s;
            for (int i = 0; i < mas.Length; ++i)
            {
                for (int z = 0; z < s.Length; ++z)
                {
                    if (mas[i] == s.Substring(z, s.Length - z))
                    {
                        s2 += s[z - 1];
                    }
                }
            }
            Console.WriteLine(s2 + " ");
            Console.WriteLine(s2.IndexOf("$")); // Прямая

            int[] ARR = new int[123];
            for (int i = 0; i < s2.Length; ++i)
            {
                ARR[Convert.ToByte(s2[i])] += 1;
            }

            int[] a = new int[123];
            int j = Convert.ToByte('$'); // если в качестве конца строки будет "$", а если нет, то заменяем его на s[-1]
            a[j] = 1;
            for (int i = j + 1; i < a.Length; ++i)
            {
                if (ARR[i] != 0)
                {
                    a[i] = a[j] + ARR[j];
                    j = i;
                }
            }
            int[] p = new int[s2.Length];
            for (int i = 0; i < p.Length; ++i)
            {
                p[i] = a[Convert.ToByte(s2[i])];
                a[Convert.ToByte(s2[i])] += 1;
            }
            string s3 = "$";
            int k = s2.IndexOf("$");

            for (int i = 0; i < p.Length; ++i)
            {
                p[i] -= 1;
            }

            for (int i = 0; i < s2.Length - 1; ++i)
            {
                s3 = s2[p[k]] + s3;
                k = p[k];
            }
            Console.WriteLine(s3); // Обратная

        }

        static void Main(string[] args)
        {
            BarrW();
        }
    }
}