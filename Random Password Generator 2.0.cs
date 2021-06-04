using System;
using System.Text;

namespace Random_Password_Generator_2._0
{
    class Program
    {
        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*_";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        static void Main(string[] args)
        {
            int x = 0;
            while (true)
            {
                Console.WriteLine("Character Count:: ");
                string len = Console.ReadLine();

                Int32.TryParse(len, out x);

                Console.WriteLine($"Your password is:: {CreatePassword(x)}");
                Console.WriteLine("Would you like the generate another password? Y/N");
                string ans = Console.ReadLine();
                if(ans.ToLower() == "n")
                {
                    break;
                }
            }

            Console.WriteLine("Enter a Key to exit::");
            Console.Read();
        }
    }
}
