using System;
using System.IO;

namespace Ignateva_Exzam
{
    class Program
    {
        private static int n;

        static void Main(string[] args)
        {
            ValidateStartingPoint();
        }

        internal static void ValidateStartingPoint()
        {
            int n;
            Console.WriteLine("Введите начальную точку маршрута от 1 до 9: ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 9)
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
                ValidateStartingPoint();
            }
            else
            {
                ValidateEndingPoint(n);
            }
        }

        internal static void ValidateEndingPoint(int startPoint)
        {
            int k;
            Console.WriteLine("Введите конечную точку маршрута от 1 до 9: ");
            k = Convert.ToInt32(Console.ReadLine());
            if (k <= 0 || k > 9)
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
                ValidateEndingPoint(startPoint);
            }
            else
            {
                if (k == startPoint)
                {
                    Console.WriteLine("Вы уже на месте");
                }
                else
                {
                    Console.WriteLine("Матрица смежности:");
                    //Print();
                    Console.WriteLine("Средняя скорость на участках:");
                    //averageSpeed();
                }
            }
        }

    private static double[,] Input(out double m)
        {
            m = 0;
            StreamReader f = new StreamReader("test.txt");
            string s;
            double[,] a;
            string[] buf;
            int i = 0;
            while ((s = f.ReadLine()) != null)
            {
                buf = s.Split(' ');
                a = new double[buf.Length, buf.Length];
                for (int j = 0; j < buf.Length; j++)
                {
                    int t = Convert.ToInt32(buf[j]);
                    a[i, j] = t;
                    Console.Write("{0,8}", a[i, j]);
                }
                i++;
                Console.WriteLine();
            }
            return a;
        }

        private static void Print(double[,] a)
        {
            for (int i = 0; i < a.GetLength(0); ++i, Console.WriteLine())
                for (int j = 0; j < a.GetLength(1); ++j)
                    Console.Write("{0,8} ", a[i, j]);

        }

        private static void averageSpeed(double[,] a)
        {
            var random = new Random();

            for (int i = 0; i < a.GetLength(0); ++i, Console.WriteLine())
                for (int j = 0; j < a.GetLength(1); ++j)
                    Console.Write("{0,8} ", random.Next(30, 80));
            Console.WriteLine();
        }

        private static double[] Dijkstra(double[,] a, int v0)
        {
            double[] dist = new double[n];
            bool[] vis = new bool[n];
            int unvis = n;
            int v;

            for (int i = 0; i < n; i++)
                dist[i] = Double.MaxValue;
            dist[v0] = 0.0;

            while (unvis > 0)
            {
                v = -1;
                for (int i = 0; i < n; i++)
                {
                    if (vis[i])
                        continue;
                    if ((v == -1) || (dist[v] > dist[i]))
                        v = i;
                }
                vis[v] = true;
                unvis--;
                for (int i = 0; i < n; i++)
                {
                    if (dist[i] > dist[v] + a[v, i])
                        dist[i] = dist[v] + a[v, i];
                }
            }
            return dist;
        }
    }
}

