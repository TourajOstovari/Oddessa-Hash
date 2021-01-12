using PGA;
using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        private static byte[] v1;
        private static void Main(string[] args)
        {
            First:
            Console.Title = "ODESSA HASH FUNCTION DEVELOPED BY MR. TOURAJ OSTOVARI";
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;

            try
            {

                System.IO.StreamReader streamReader = new System.IO.StreamReader(args[0], Encoding.UTF8);
                //System.IO.StreamReader streamReader = new System.IO.StreamReader(@"C:\Users\Toraj\Downloads\Compressed\Udemy.Deep.dive.into.Windows.Presentation.Foundation.WPF_p30download.com.part5.rar", Encoding.UTF8);

                v1 = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
                //v1 = Encoding.Unicode.GetChars(System.IO.File.ReadAllBytes(file.ToString()));
            }
            catch
            {
                Console.Write("Write your string:\r\n");
                v1 = Encoding.UTF8.GetBytes(Console.ReadLine());
            }
            System.Threading.Tasks.Parallel.Invoke(() =>
           {
               System.Threading.Tasks.Task.Run(() =>
               {

                   System.Threading.Thread thread = new System.Threading.Thread(Calc_Hash);
                   thread.Priority = System.Threading.ThreadPriority.Highest;
                   thread.Start();
               }).Wait();

           });
            Console.ReadLine();
            goto First;
        }
        public static void Calc_Hash()
        {
            Stopwatch st = new Stopwatch();


            byte shift = 1;
            int alpha = 1023;

            st.Start();
            BitArray A = new BitArray(1024, true);
            BitArray B = new BitArray(1024, true);
            BitArray C = new BitArray(1024, true);
            BitArray D = new BitArray(1024, true);

            BitArray A_ = new BitArray(256, false);
            BitArray B_ = new BitArray(256, false);
            BitArray C_ = new BitArray(256, false);
            BitArray D_ = new BitArray(256, false);

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
            long Sums = 0;
            {
                System.Security.Cryptography.SHA256 md5 = System.Security.Cryptography.SHA256.Create();
                byte[] temp = md5.ComputeHash(v1);

                for (int i = 0; i < temp.Length; i++)
                {
                    Sums += temp[i];
                }
                Console.WriteLine((long)Math.Log10(Math.Pow(Sums, shift)) + "\t" + Sums);
                for (int i = 1; i <= (7+(long)Math.Log10(Math.Pow(Sums,shift))); i++)
                {
                    Bit.lst.Length = 1024;
                    Bit.BEL((Sums * i * (long)Math.Log10(Math.Pow(Sums, shift)) ), (Sums + shift), 1023);
                    A = A.And(Bit.lst).LeftShift(2);
                    A = B.Xor(A).RightShift(1);
                    A = C.Xor(A);
                    A = D.Xor(A);
                    BitArray _C_ = new BitArray(1024, false);
                    BitArray _D_ = new BitArray(1024, false);
                    _D_ = (BitArray)D.Clone();
                    D = (BitArray)A.Clone();
                    D = D.LeftShift(19);
                    A = (BitArray)_D_.Clone();
                    A = A.RightShift(32);
                    _C_ = (BitArray)C.Clone();
                    C = (BitArray)B.Clone();
                    C = (BitArray)C.LeftShift(19);
                    B = (BitArray)_C_.Clone();
                    B = (BitArray)B.RightShift(32);

                }
            }
            {
                int temp = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (i <= 255 && i >= 0)
                    {
                        A_.Set(temp++, A.Get(i));
                        if (temp == 256)
                            temp = 0;
                    }
                    if (i <= 511 && i >= 256)
                    {
                        B_.Set(temp++, A.Get(i));
                        if (temp == 256)
                            temp = 0;
                    }
                    if (i <= 767 && i >= 512)
                    {
                        C_.Set(temp++, A.Get(i));
                        if (temp == 256)
                            temp = 0;
                    }
                    if (i <= 1023 && i >= 768)
                    {
                        D_.Set(temp++, A.Get(i));
                    }

                }
            }
            {
                Bit.lst.Length = 256;
                Bit.BEL((Sums * shift * (int)Math.Log10(Math.Pow(Sums, shift)) ), (Sums + shift), 255);
                A_ = A_.Xor(B_);
                C_ = C_.Xor(D_);
                A_ = A_.And(Bit.lst).Not();
                C_ = C_.And(Bit.lst).Not();
                A_ = A_.Xor(C_);

            }

            string result = "";
            Console.WriteLine($"Hash:");
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
                    Console.Write((Convert.ToInt32(result, 2)).ToString("X"));
                    result = "";
                }
            }
            st.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nStopwatch:" + st.Elapsed);
        }
    }
}
