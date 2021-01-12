using System;
using System.Collections.Generic;
using System.Collections;
namespace PGA
{
    public class Bit
    {
        public static BitArray lst = new BitArray(4096);

        /// <summary>
        /// BEL Random Number Generator for Binary Mode
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <param name="X"></param>
        public static void BEL(Int64 seed_, Int64 shift_, int Size)
        {
            System.Threading.Tasks.Parallel.Invoke(()=> { 
            System.Threading.Tasks.Task.Factory.StartNew(() => { 
            long size = Size;
            long seed = (11*seed_ + shift_);
            long a = (shift_*5);
            long m = 100;
            long c = (seed_ * 2);
            long p = 1007;
            long q = 1008;
            long X1, Y1, X2, Y2;
            while (size >= 0)
            {
                long s1 = seed, s2 = seed, s3 = seed;
                for (int n = 0; n < (size + 1); n++)
                {
                    s1 = (long)Math.Pow(s1, 2) % m; // BBS
                    s2 = (a * s2 + c) % m;  // LCG
                    X1 = Y1 = s3 * p;
                    s3 = X1;
                    X2 = Y2 = s3 * q;
                    seed = s1 + s2 + X2;
                    if (p < m)
                    {
                        seed = seed % m;
                    }
                    else
                    {
                        seed = seed % p;
                    }
                    if (seed % 2 == 0)
                        lst.Set((int)size--, false);
                    else
                        lst.Set((int)size--, true);
                }
            }
            }).Wait();
            });
        } 
    }
}
