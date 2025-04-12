using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BagWithDoubleWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;double W = 17.8;
            //Worth
            double[] v = { 10, 40, 30, 50 };
            //Weight
            double[] w = { 5.2, 4.1, 6.3, 3.7 };
            Max(n, v, w, W);
        }
        public static void Max(int n, double[] v, double[] w, double W)
        {
            string str = "";
            double sum = 0;
            double[] nesbat = new double[v.Length];
            double[] pickedItems = new double[v.Length];
            double wsum = 0;
            int index = 0;
            while (index < v.Length)
            {
                nesbat[index] = v[index] / w[index];
                pickedItems[index] = 0;
                index++;
            }
            int c = 1;
            while (wsum < W && c<=n)
            {
                int best = 0;
                index = 0;
                while (index < v.Length)
                {
                    if (pickedItems[index] == 0 && nesbat[best] < nesbat[index])
                    {
                        best = index;
                    }
                    index++;
                }
                if (wsum + w[best] <= W)
                {
                    str = str + "product(" + best.ToString()+ ") Has been picked completely"+"\n";
                    sum += v[best];
                    wsum += w[best];
                    pickedItems[best] = 1;
                    nesbat[best] = -1;
                }
                else
                {
                    pickedItems[best] = v[best] * (W - wsum) / w[best];
                    str = str + "product(" + best.ToString() +") Has been picked with %" + (pickedItems[best] / v[best] * 100).ToString()+"\n";
                    sum = sum + (v[best] * (W - wsum) / w[best]);
                    wsum = W;
                }
                c++;
            }
            str += "Whole value = " + sum.ToString()  ;
            Console.WriteLine(str);
        }
    }
}
