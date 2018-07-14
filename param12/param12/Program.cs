using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace param12
{
    class Program
    {
        public static void readNum(out int num, string msg)
        {
            while (true)
            {
                try
                {
                    
                    Console.WriteLine(msg);
                    if (!Int32.TryParse(Console.ReadLine(), out num)) throw new ArgumentException();
                    break;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода, повторите заново: ");
                }
            }
        }

        public static int readNum()
        {
            int num;
            while (true)
            {
                try
                {
                    if (!Int32.TryParse(Console.ReadLine(), out num)) throw new ArgumentException();
                    break;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода, повторите заново: ");
                }
            }
            return num;
        }

        public static void fillArray(int[] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(0, 15);
            }
        }

        public static void printArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write("{0,3}", i);
            }
            Console.WriteLine();
        }

        public static int[] CreateIndex(int [] arr)
        {
            int[] outarr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                outarr[i] = i + 1;
            }
            return outarr;
        }

        static void ShakerSort(int[] myint, int [] index)
        {
            int left = 0,
                right = myint.Length - 1;

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    if (myint[i] > myint[i + 1])
                    {
                        Swap(myint, i, i + 1);
                        Swap(index, i, i + 1);
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (myint[i - 1] > myint[i])
                    {
                        Swap(myint, i - 1, i);
                        Swap(index, i - 1, i);
                    }
                }
                left++;
            }
        }
        
        static void Swap(int[] myint, int i, int j)
        {
            int glass = myint[i];
            myint[i] = myint[j];
            myint[j] = glass;
        }

        public static void param12()
        {
            string msg1 = "Введите размер массива A: ";
            string msg2 = "Введите размер массива B: ";
            string msg3 = "Введите размер массива C: ";
            int a1;
            int b1;
            int c1;
            readNum(out a1, msg1);
            int[] a = new int[a1];
            int[] inda = CreateIndex(a);
            readNum(out b1, msg2);
            int[] b = new int[b1];
            int[] indb = CreateIndex(b);
            readNum(out c1, msg3);
            int[] c = new int[c1];
            int[] indc = CreateIndex(c);
            Console.WriteLine("Массив A:");
            fillArray(a);
            printArray(a);
            printArray(inda);
            Console.WriteLine("Массив B:");
            fillArray(b);
            printArray(b);
            printArray(indb);
            Console.WriteLine("Массив C:");
            fillArray(c);
            printArray(c);
            printArray(indc);
            //
            Console.WriteLine("После сортировки:");
            ShakerSort(a, inda);
            ShakerSort(b, indb);
            ShakerSort(c, indc);
            Console.WriteLine("Массив A:");
            printArray(a);
            printArray(inda);
            Console.WriteLine("Массив B:");
            printArray(b);
            printArray(indb);
            Console.WriteLine("Массив C:");
            printArray(c);
            printArray(indc);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void SplitStr(string s, List<string> ls)
        {
            string pattern = "[а-яa-z0-9]+";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (Match match in r.Matches(s))
                ls.Add(match.Value);
        }

        public static void param41()
        {
            Console.WriteLine("Введите строку: ");
            string s = Console.ReadLine();
            List<string> ls = new List<string>();
            SplitStr(s, ls);
            int cnt = 1;
            Console.WriteLine("Список слов в предложении: ");
            foreach (string i in ls)
            {
                Console.WriteLine("{0}\t{1}", cnt, i);
                cnt++;
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public static int IntFileSize(string s)
        {
            FileStream file;
            try
            {
                int count = 0;
                file = new FileStream(s, FileMode.Open, FileAccess.ReadWrite);
                StreamReader reader = new StreamReader(file);
                string buf = reader.ReadToEnd();
                string pattern = "[0-9]+";
                Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
                foreach (Match match in r.Matches(buf))
                    count++;
                file.Close();
                return count;

            }
            catch(Exception e)
            {
                return -1;
            }
        }

        public static void param48()
        {
            Console.WriteLine("В файле \"notes1.txt\": " + IntFileSize("C:\\Users\\Kero\\source\\practique\\param12\\param12\\notes1.txt") + " чисел");
            Console.WriteLine("В файле \"notes2.txt\": " + IntFileSize("C:\\Users\\Kero\\source\\practique\\param12\\param12\\notes2.txt") + " чисел");
            Console.WriteLine("В файле \"notes3.txt\": " + IntFileSize("C:\\Users\\Kero\\source\\practique\\param12\\param12\\notes3.txt") + " чисел");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public struct TPoint
        {
            public int X { get; set; }
            public int Y { get; set; }

            TPoint(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public class Polygon
        {
            TPoint[] vexel;
            public Polygon(TPoint[] vexel)
            {
                this.vexel = (TPoint[])vexel.Clone();
            }

            static double Dist(TPoint a, TPoint b)
            {
                return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
            }

            static double P(TPoint a, TPoint b, TPoint c)
            {
                return Dist(a, b) + Dist(b, c) + Dist(c, a);
            }

            static double S(TPoint a, TPoint b, TPoint c)
            {
                double p = P(a, b, c)/2d;
                return Math.Sqrt(p * (p - Dist(a, b)) * (p - Dist(a, c)) * (p - Dist(b, c)));
            }

            public double Area()
            {
                double buf = 0;
                for (int i = 2; i < this.vexel.Length -1; i++)
                {
                    buf += S(vexel[0], vexel[i - 1], vexel[i]);
                }
                return buf;
            }
        }

        public static void param70()
        {
            Console.WriteLine("Введите количество вершин: ");
            int n = readNum();
            Console.WriteLine("Введите попарно значения координат для вершин: ");
            TPoint[] mas = new TPoint[n];
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write("X: ");
                mas[i].X = readNum();
                Console.Write("Y: ");
                mas[i].Y = readNum();
            }
            Polygon p = new Polygon(mas);
            Console.WriteLine("Площадь фигуры: " + p.Area());
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public static void menu()
        {
            while (true)
            {
                Console.WriteLine("1. Param 12: Индексный массив");
                Console.WriteLine("2. Param 41: Строка -> Массив слов");
                Console.WriteLine("3. Param 48: Количество целых чисел в файле");
                Console.WriteLine("4. Param 70: Площадь выпуклого многоугольника");
                Console.WriteLine("5. Выход");
                Console.WriteLine("Выберите дейчтвие: ");
                switch (readNum())
                {
                    case 1:
                        param12();
                        Console.Clear();
                        break;
                    case 2:
                        param41();
                        Console.Clear();
                        break;
                    case 3:
                        param48();
                        Console.Clear();
                        break;
                    case 4:
                        param70();
                        Console.Clear();
                        break;
                    case 5:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка, повторите ввод...");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            menu();
        }
    }
}
