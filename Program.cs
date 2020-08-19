using System;

namespace hesap_makinesi
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           
            girdi(out var islem);
            a(islem,out var operat,out int[] sayilar);
            sonuc(operat,sayilar);

        }

        static void sonuc(string operat, int[] sayilar)
        {
            int cevap = 0;
            int i = 0;
            for (int j = 0; j < operat.Length; j++)
            {
                for (; i < j+1; i++)
                {
                    foreach (var oper in operat)
                    {
                        
                        switch (oper)
                        {
                            
                            case '+':
                                cevap=sayilar[i] + sayilar[i+1];
                                sayilar[i + 1] = cevap;
                                i++;
                                break;
                            case '-':
                                cevap=sayilar[i] - sayilar[i+1];
                                sayilar[i + 1] = cevap;
                                i++;
                                break;
                            case '*':
                                cevap=sayilar[i] * sayilar[i+1];
                                sayilar[i + 1] = cevap;
                                i++;
                                break;
                            case '/':
                                cevap=sayilar[i] / sayilar[i+1];
                                sayilar[i + 1] = cevap;
                                i++;
                                break;
                        }
                    }
                }
            }
            Console.Write(cevap);
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
                    char[] oper ={'+','-','*','/'};
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

        static void a(string islem,out string operat,out int[] sayilar)
        {
            operat = "";
            int a = 0;
            string gecici = "";
            sayilar=new int[10];
            //char[] oper ={'+','-','*','/'};
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