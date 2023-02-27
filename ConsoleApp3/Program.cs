using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        public class Object
        {
            public string Imya { get; set; }
            public double Znachenie { get; set; }
            public Object() { }
            public Object(string imya, double znachenie)
            {
                Imya = imya;
                Znachenie = znachenie;
            }
        }

        public class Rukzak
        {
            public string Zvet { get; set; }
            public string Brend { get; set; }
            public string Tip { get; set; }
            public double Massa { get; set; }
            public double Obem { get; set; }
            public double Use_Obem { get; set; }

            public List<Object> Objects { get; set; } = new List<Object>();

            public event EventHandler<Object> PackAdd;

            public Rukzak() { }
            public Rukzak(string zvet, string brend, string tip, double massa, double use_obem)
            {
                Zvet = zvet;
                Brend = brend;
                Tip = tip;
                Massa = massa;
                Use_Obem = use_obem;
            }
            public void Init()
            {
                Console.WriteLine("Color");
                Zvet = Console.ReadLine();
                Console.WriteLine("Brand");
                Brend = Console.ReadLine();
                Console.WriteLine("Type");
                Tip = Console.ReadLine();
                Console.WriteLine("Weight");
                Massa = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Sound");
                Use_Obem = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Used Volume");
            }
            public void AddObj(Object obj)
            {
                if (obj.Znachenie + Use_Obem > Use_Obem)
                    throw new Exception("Bigger than a backpack");
                Objects.Add(obj);
                Use_Obem += obj.Znachenie;
                PackAdd?.Invoke(this, obj);
            }
        }
        static void PackChange()
        {
            Console.WriteLine("Backpack created");
        }
        static void PackAdd()
        {
            Console.WriteLine("An item has been added to the backpack");
        }

        delegate string Funciya_1(RainbowColor color);
        delegate int Funciya_3(int[] a);
        delegate int Funciya_4(int[] a);
        delegate void Funciya_5(int[] a);
        delegate bool Funciya_6(string a, string b);
        public enum RainbowColor
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }
        static void Main(string[] args)
        {
            #region Первое заданеи 
            RainbowColor color = RainbowColor.Red;
            Funciya_1 func_1 = delegate (RainbowColor x)
            {
                string buf = "";
                switch (x)
                {
                    case RainbowColor.Red:
                        return buf = "255, 0, 0";
                    case RainbowColor.Orange:
                        return buf = "255, 165, 0";
                    case RainbowColor.Yellow:
                        return buf = "255, 255, 0";
                    case RainbowColor.Green:
                        return buf = "0, 128, 0";
                    case RainbowColor.Blue:
                        return buf = "0, 0, 255";
                    case RainbowColor.Indigo:
                        return buf = "75, 0, 13";
                    case RainbowColor.Violet:
                        return buf = "238, 130, 238";
                    default:
                        return buf = "0, 0, 0";
                }
            };
            Console.WriteLine(func_1(color));
            #endregion

            #region Второе задание 
            Rukzak rukzak = new Rukzak("Black", "Off White", "Canvas", 1.0, 20);
            rukzak.PackAdd += (sender, item) =>
            {
                Console.WriteLine($"An object {item.Imya} added to backpack");
            };
            Object obj = new Object("Laptop", 3.0);
            try
            {
                rukzak.AddObj(obj);
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
            #endregion

            #region Третье задание 
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Funciya_3 func_3 = (int[] x) =>
            {
                int count = 0;
                for (int i = 0; i < x.Length; i++)
                    if (x[i] % 7 == 0 && x[i] != 0)
                        count++;
                return count;
            };
            Console.WriteLine(func_3(arr));
            #endregion

            #region Четвертое задание 
            int[] arr2 = new int[] { 1, 2, 3, 4, 5, 6, -10, -9, -9, -8 };
            Funciya_4 func_4 = (int[] x) =>
            {
                int buf_4 = 0;
                for (int i = 0; i < x.Length; i++)
                    if (x[i] > 0)
                        buf_4++;
                return buf_4;
            };
            Console.WriteLine(func_4(arr2));
            #endregion

            #region Пятое задание 
            Funciya_5 func_5 = (int[] x) =>
            {
                var buf = x.Where(y => y < 0).Distinct();
                foreach (var result in buf)
                    Console.Write(result + " ");
                Console.WriteLine();
            };
            #endregion

            #region Шестое задание 
            string text = "Hi World";
            string search = "Hi";
            Funciya_6 func_6 = (text_1, search_1) =>
            {
                if (text_1.IndexOf(search_1) != -1)
                    return true;
                else
                    return false;
            };
            Console.WriteLine(func_6(text, search));
            #endregion
        }
    }
}