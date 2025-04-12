using System;

namespace BagWithCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            do
            {
                Console.Clear();
                Console.WriteLine("please enter number of products:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("please enter weight of bag:");
                int W = Convert.ToInt32(Console.ReadLine());
                int[] v = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("please enter worth of poduct {0}:",i+1);
                    v[i] = Convert.ToInt32(Console.ReadLine());
                }
                int[] w = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("please enter weight of poduct {0}:",i+1);
                    w[i] = Convert.ToInt32(Console.ReadLine());
                }
                int[] c = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("please enter count of poduct {0}:",i+1);
                    c[i] = Convert.ToInt32(Console.ReadLine());
                }
                var v1 = MaxVWithoutCount(n, v, w, W);
                Console.WriteLine("max value without count: " + v1);
                var v2 = MaxVWithCount(n, v, w, c, W);
                Console.WriteLine("max value with count: " + v2);
                Console.WriteLine("Do you want to exit? enter yes or no:");
                str = Console.ReadLine();
            } while (str == "no");
        }
        public static int MaxVWithCount(int n, int[] v, int[] w, int[] c, int W)
        {
            int[,] V = new int[n + 1, W + 1];
            for (int i = 0; i <= W; i++)
            {
                V[0, i] = 0;
            }
            for (int i = 0; i <= n; i++)
            {
                V[i, 0] = 0;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    int count = 1;
                    for (int t = 1; t <= c[i - 1]; t++)
                    {
                        if (j - t * w[i - 1] < 0)
                        {
                            count = t - 1;
                            break;
                        }
                        else
                        {
                            count = t;
                        }
                    }
                    if (j >= w[i - 1] && V[i - 1, j - count * w[i - 1]] + count * v[i - 1] > V[i - 1, j])
                    {
                        V[i, j] = V[i - 1, j - count * w[i - 1]] + count * v[i - 1];
                    }
                    else
                    {
                        V[i, j] = V[i - 1, j];
                    }
                }
            }
            return V[n, W];
        }
        public static int MaxVWithoutCount(int n, int[] v, int[] w, int W)
        {
            int[,] V = new int[n + 1, W + 1];
            for (int i = 0; i <= W; i++)
            {
                V[0, i] = 0;
            }
            for (int i = 0; i <= n; i++)
            {
                V[i, 0] = 0;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    if (j >= w[i - 1] && V[i - 1, j - w[i - 1]] + v[i - 1] > V[i - 1, j])
                    {
                        V[i, j] = V[i - 1, j - w[i - 1]] + v[i - 1];

                    }
                    else
                    {
                        V[i, j] = V[i - 1, j];
                    }
                }
            }
            return V[n, W];
        }
    }
}
