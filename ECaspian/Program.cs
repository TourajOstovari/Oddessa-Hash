using PGA;
using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static System.Collections.ArrayList Array = new ArrayList();
        private static byte[] v1;
        static long Counter = 0;
        static string value = "";
        private static void Main(string[] args)
        {
            System.IO.StreamReader streamReader = new System.IO.StreamReader(@"C:\pass.txt", Encoding.UTF8);
        First:
            Console.Title = "ODESSA HASH FUNCTION DEVELOPED BY MR. TOURAJ OSTOVARI";
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;

            try
            {

                // System.IO.StreamReader streamReader = new System.IO.StreamReader(args[0], Encoding.UTF8);

                value = streamReader.ReadLine();
                v1 = Encoding.UTF8.GetBytes(value);

                //v1 = Encoding.Unicode.GetChars(System.IO.File.ReadAllBytes(file.ToString()));
            }
            catch
            {
                Console.Write("Write your string:\r\n");
                v1 = Encoding.UTF8.GetBytes(Console.ReadLine());
            }
            // System.Threading.Tasks.Parallel.Invoke(() =>
            //{
            //    System.Threading.Tasks.Task.Run(() =>
            //    {

            //System.Threading.Thread thread = new System.Threading.Thread(Calc_Hash);
            //thread.Priority = System.Threading.ThreadPriority.Highest;
            //thread.Start();
            //    }).Wait();
            Calc_Hash();
            //});
            goto First;
            Console.ReadLine();

        }
        public static void Calc_Hash()
        {
            Stopwatch st = new Stopwatch();
            long Sums = 0;

            byte shift = 1;
            int alpha = 1023;


            BitArray A = new BitArray(1024, true);
            BitArray B = new BitArray(1024, false);
            BitArray C = new BitArray(1024, false);
            BitArray D = new BitArray(1024, true);

            BitArray A_ = new BitArray(512, false);
            BitArray B_ = new BitArray(512, false);

            int Index = 0;
            bool A_Time = true;
            bool B_Time = false;
            bool C_Time = false;
            bool D_Time = false;
            bool Jump_ = false;
            int Final_Counter = 1;
            string Temp_Append = "";
            long Counter_Index = 0;
            for (; Counter_Index < v1.Length;)
            {
                byte item = v1[Counter_Index++];
                //Sums += item;
                bool IsAppened_ = false;
                if (++shift == 20) shift = 1;
                string Binary = Convert.ToString(item, 2);

                int Index_ = (Binary.Length - 1);
                // Reverse ham dare rokh mide
                if (A_Time)
                {
                    if (Jump_ == true) { Jump_ = false; Index = 0; }
                    while (Index_ >= 0)
                    {
                        if (IsAppened_ == false)
                        {
                            if (Temp_Append.Length == 0)
                            {
                                if (Binary[Index_] == '1')
                                    A.Set(Index, true);
                                else if (Binary[Index_] == '0')
                                    A.Set(Index, false);
                                Index++; Index_--;
                            }
                            else
                            {
                                for (int i = Temp_Append.Length - 1; i >= 0; i--)
                                {
                                    if (Temp_Append[i] == '1') A.Set(Index++, true); else A.Set(Index++, false);
                                }
                                Temp_Append = "";
                            }
                        }
                        else if (IsAppened_ == true)
                        {
                            if (Binary[Index_] == '1')
                                Temp_Append += "1";
                            else if (Binary[Index_] == '0')
                                Temp_Append += "0";
                            Index_--;

                        }
                        if (Index == alpha)
                        {
                            A_Time = false;
                            B_Time = true;
                            Index = 0;
                            Jump_ = true;
                            if (Index_ >= 0)
                            {
                                IsAppened_ = true;
                            }
                        }
                    }
                }
                else if (B_Time)
                {
                    if (Jump_ == true) { Jump_ = false; Index = 0; }
                    while (Index_ >= 0)
                    {
                        if (IsAppened_ == false)
                        {
                            if (Temp_Append.Length == 0)
                            {
                                if (Binary[Index_] == '1')
                                    B.Set(Index, true);
                                else if (Binary[Index_] == '0')
                                    B.Set(Index, false);
                                Index++; Index_--;
                            }
                            else
                            {
                                for (int i = Temp_Append.Length - 1; i >= 0; i--)
                                {
                                    if (Temp_Append[i] == '1') B.Set(Index++, true); else B.Set(Index++, false);
                                }
                                Temp_Append = "";
                            }
                        }
                        else if (IsAppened_ == true)
                        {
                            if (Binary[Index_] == '1')
                                Temp_Append += "1";
                            else if (Binary[Index_] == '0')
                                Temp_Append += "0";
                            Index_--;

                        }
                        if (Index == alpha)
                        {
                            B_Time = false;
                            C_Time = true;
                            Index = 0;
                            Jump_ = true;
                            if (Index_ >= 0)
                            {
                                IsAppened_ = true;
                            }
                        }
                    }
                }
                else if (C_Time)
                {
                    if (Jump_ == true) { Jump_ = false; Index = 0; }
                    while (Index_ >= 0)
                    {
                        if (IsAppened_ == false)
                        {
                            if (Temp_Append.Length == 0)
                            {
                                if (Binary[Index_] == '1')
                                    C.Set(Index, true);
                                else if (Binary[Index_] == '0')
                                    C.Set(Index, false);
                                Index++; Index_--;
                            }
                            else
                            {
                                for (int i = Temp_Append.Length - 1; i >= 0; i--)
                                {
                                    if (Temp_Append[i] == '1') C.Set(Index++, true); else C.Set(Index++, false);
                                }
                                Temp_Append = "";
                            }
                        }
                        else if (IsAppened_ == true)
                        {
                            if (Binary[Index_] == '1')
                                Temp_Append += "1";
                            else if (Binary[Index_] == '0')
                                Temp_Append += "0";
                            Index_--;

                        }
                        if (Index == alpha)
                        {
                            C_Time = false;
                            D_Time = true;
                            Index = 0;
                            Jump_ = true;
                            if (Index_ >= 0)
                            {
                                IsAppened_ = true;
                            }
                        }
                    }
                }
                else if (D_Time)
                {
                    if (Jump_ == true) { Jump_ = false; Index = 0; }

                    while (Index_ >= 0)
                    {
                        if (IsAppened_ == false)
                        {
                            if (Temp_Append.Length == 0)
                            {
                                if (Binary[Index_] == '1')
                                    D.Set(Index, true);
                                else if (Binary[Index_] == '0')
                                    D.Set(Index, false);
                                Index++; Index_--;
                            }
                            else
                            {
                                for (int i = Temp_Append.Length - 1; i >= 0; i--)
                                {
                                    if (Temp_Append[i] == '1') D.Set(Index++, true); else D.Set(Index++, false);
                                }
                                Temp_Append = "";
                            }
                        }
                        else if (IsAppened_ == true)
                        {
                            if (Binary[Index_] == '1')
                                Temp_Append += "1";
                            else if (Binary[Index_] == '0')
                                Temp_Append += "0";
                            Index_--;

                        }
                        if (Index == alpha)
                        {
                            A_Time = true;
                            D_Time = false;
                            Index = 0;
                            Jump_ = true;
                            if (Index_ >= 0)
                            {
                                IsAppened_ = true;
                            }
                            Final_Counter++;
                        }
                    }
                }
                if (Final_Counter == 12) break;
            }
            st.Start();
            Counter++;
            {
                {
                    System.Security.Cryptography.SHA256 sha = System.Security.Cryptography.SHA256.Create();
                    byte[] temp = sha.ComputeHash(v1);
                    for (int i = 0; i < temp.Length; i++)
                    {
                        Sums += temp[i];
                    }
                }
                {
                    System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                    byte[] temp = md5.ComputeHash(v1);
                    for (int i = 0; i < temp.Length; i++)
                    {
                        Sums += temp[i];
                    }
                }
                for (int i = 1; i <= 80; i++)
                {
                    Bit.lst.Length = 1024;
                    Bit.BEL((Sums * i), (Sums * shift * i), 1023);
                    A = A.And(Bit.lst).LeftShift(2);
                    A = B.Xor(A).RightShift(1);
                    A = C.Xor(A);
                    A = D.Xor(A);
                    BitArray _C_ = new BitArray(1024, false);
                    BitArray _D_ = new BitArray(1024, false);
                    _D_ = (BitArray)D.Clone();
                    D = (BitArray)A.Clone();
                    D = D.LeftShift(1);
                    A = (BitArray)_D_.Clone();
                    A = A.RightShift(1);
                    _C_ = (BitArray)C.Clone();
                    C = (BitArray)B.Clone();
                    C = (BitArray)C.LeftShift(9);
                    B = (BitArray)_C_.Clone();
                    B = (BitArray)B.RightShift(9);

                }
            }
            A = A.Xor(B).Xor(C).And(D);
            {
                int temp = 0;
                for (int i = 0; i < 1024; i++)
                {
                    if (i <= 511 && i >= 0)
                    {
                        A_.Set(temp++, A.Get(i));
                        if (temp == 512)
                            temp = 0;
                    }
                    if (i <= 1023 && i >= 512)
                    {
                        B_.Set(temp++, A.Get(i));
                    }

                }
            }

            {
                System.Security.Cryptography.SHA1 Sha1 = System.Security.Cryptography.SHA1.Create();
                byte[] temp = Sha1.ComputeHash(v1);
                for (int i = 0; i < temp.Length; i++)
                {
                    Sums += temp[i];
                }
            }
            {
                System.Security.Cryptography.SHA512 Sha1 = System.Security.Cryptography.SHA512.Create();
                byte[] temp = Sha1.ComputeHash(v1);
                for (int i = 0; i < temp.Length; i += 2)
                {
                    Sums += temp[i];
                }
                
            }
            {
                for (int i = 1; i <= 5; i++)
                {
                    BitArray temp = new BitArray(512, false);
                    Bit.lst.Length = 512;
                    Bit.BEL((Sums * i), (Sums + shift * (long)Math.Pow(i, 10)), 511);
                    A_ = A_.Xor(B_);
                    A_ = A_.Xor(Bit.lst);
                    temp = (BitArray)B_.Clone();
                    B_ = (BitArray)A_.Clone();
                    A_ = (BitArray)temp.Clone();
                }
                A_ = A_.And(B_);


            }
            Console.WriteLine($"\nString: {value}\n");
            string result = "";
            string temp_ = "";
            Console.WriteLine($"Hash:");
            int Indexer = 0;
            for (int i = 0; i < A_.Count; i++)
            {
                if (A_.Get(i))
                {
                    result += "1";

                }
                else
                {
                    result += "0";

                }
                if (result.Length == 4)
                {
                    result = Convert.ToString(Convert.ToInt32(result, 2), 16);
                    //result = Convert.ToString(Convert.ToInt64(array[Indexer++].ToString(),2) ^ Convert.ToInt32(result,2),16);
                    Console.Write(result);
                    temp_ += result;
                    result = "";
                    //if (Indexer == 255) Indexer = 0;
                }
            }

            if (Array.Contains(temp_))
            {
                collision += 1;
                Console.WriteLine("\n\nCollision Found  " + temp_);
                Console.WriteLine(Array.IndexOf(temp_) + 1);
                Console.WriteLine(Counter);
                Console.WriteLine(Sums);
            }
            else
            {
                Array.Add(temp_);
                Console.WriteLine("\n" + Sums);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Collision Rate: "+collision.ToString());
            temp_ = "";
            st.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nStopwatch:" + st.Elapsed);
        }
        public static int collision = 0;
        public static System.Collections.ArrayList array = new System.Collections.ArrayList();
        public static void SBOX(long Seed, long shift)
        {
            long size = 16112;

            string temp = "";




            long seed = Seed;
            long a = shift;
            long m = 100;
            long c = Seed * 2;
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
                    {
                        size--;
                        temp += "0";
                    }
                    else
                    {
                        size--;
                        temp += "1";
                    }
                    if (temp.Length == 8 && !array.Contains(temp))
                    {
                        array.Add(temp);
                        Console.WriteLine(temp + "\t" + Convert.ToInt32(temp, 2).ToString("X2"));
                        temp = "";
                    }
                    else if (temp.Length == 8 && array.Contains(temp))
                    {
                        Seed *= 2;
                        a *= 2;
                        temp = "";
                    }

                }
            }

        }
    }
}
