using System;
using System.Linq;

namespace hesap_makinesi
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           
            girdi(out var islem);
            a(islem,out var operat,out double[] sayilar);
            sonuc(operat,sayilar);
            Main(args);
        }

        static void sonuc(string operat, double[] sayilar)
        {
            for (int j = 0; j < operat.Length; j++)
            {
                if (operat[j] == '^')
                {
                    sayilar[j] = Math.Pow(sayilar[j], sayilar[j + 1]);
                    for (int k = j + 1; k < sayilar.Length - 1; k++)
                    {
                        sayilar[k] = sayilar[k + 1];
                    }
                    var list = operat.ToList();
                    list.Remove('^');
                    operat = string.Concat(list);
                    j--;
                }
            }
            
            for (int j = 0; j < operat.Length; j++)
            {
                if (operat[j] == '*'||operat[j]=='/')
                {
                    if (operat[j]=='*')
                    {
                        sayilar[j]  = sayilar[j] * sayilar[j + 1];
                        var list = operat.ToList();
                        list.Remove('*');
                        operat = string.Concat(list);
                    }
                    else
                    {
                        sayilar[j] = sayilar[j] / sayilar[j + 1];
                        var list = operat.ToList();
                        list.Remove('/');
                        operat = string.Concat(list);
                    }

                    for (int k = j + 1; k < sayilar.Length - 1; k++)
                    {
                        sayilar[k] = sayilar[k + 1];
                    }
                    j--;
                }
            }
            for (int j = 0; j < operat.Length; j++)
            {
                if (operat[j] == '+'||operat[j]=='-')
                {
                    if (operat[j]=='+')
                    {
                        sayilar[j]  = sayilar[j] + sayilar[j + 1];
                        var list = operat.ToList();
                        list.Remove('+');
                        operat = string.Concat(list);
                    }
                    else
                    {
                        sayilar[j] = sayilar[j] - sayilar[j + 1];
                        var list = operat.ToList();
                        list.Remove('-');
                        operat = string.Concat(list);
                    }

                    for (int k = j + 1; k < sayilar.Length - 1; k++)
                    {
                        sayilar[k] = sayilar[k + 1];
                    }
                    j--;
                }
            }
            Console.WriteLine("cevap="+sayilar[0]);
        }

        private static void girdi(out string islem)
        {
            bool kontrol = true;
            islem = "";
            while (kontrol)
            {
                Console.WriteLine("işleminizi giriniz:");
                islem = Console.ReadLine();
                
                if (!char.IsNumber(islem[0]))
                {
                    continue;
                }
                foreach (var girdi in islem)
                { 
                    char[] oper ={'+','-','*','/','^'};
                    if (!char.IsNumber(girdi))
                    {
                        foreach (var ope in oper)
                        {
                            if (girdi == ope)
                            {
                                kontrol = false;
                                break;
                            }
                            else
                                kontrol = true;
                        }
                    }
                    else
                        kontrol = false;
                    if (kontrol)
                    {
                        break;
                    }
                }
            }
            if (!char.IsNumber(islem[islem.Length-1]))
            {
                Console.Write("eksik giridiniz devamını giriniz\n"+islem);
                string gecici = Console.ReadLine();
                islem=string.Concat(islem, gecici);
            }
        }

        static void a(string islem,out string operat,out double[] sayilar)
        {
            operat = "";
            int a = 0;
            string gecici = "";
            sayilar = new double[islem.Length];
            for (int j = 0; j < islem.Length; j++)
            {
                if (!char.IsNumber(islem[j]))
                {
                    operat = string.Concat(operat, islem[j]);
                    sayilar[a] = Convert.ToInt32(gecici);
                    a++;
                    gecici = "";
                }
                else
                    gecici = string.Concat(gecici, islem[j]);
                
            }
            sayilar[a] = Convert.ToInt32(gecici);
        }
    }
}