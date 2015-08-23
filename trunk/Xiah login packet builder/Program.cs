using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string PacketID = "01 44"; // Login PacketID
            string[] Packet = PacketID.Split(' ');

            string Account;
            string Password;

            Console.WriteLine("Account ID: ");
            Account = Console.ReadLine();
            byte[] account = ASCIIEncoding.ASCII.GetBytes(Account);
            int val = account.Length;

            Console.WriteLine("Password: ");
            Password = Console.ReadLine();
            byte[] password = ASCIIEncoding.ASCII.GetBytes(Password);
            int pal = password.Length;
            int test = pal;
            int Length = val + pal + Packet.Length + 14;

            byte neekeri = Convert.ToByte(Length);

            Console.Write("Packet: " + Packet[0] + " " + Packet[1] + " " + neekeri.ToString("X") + " 00 0" + Convert.ToByte(account.Length + 1) + " 00");

            // Need to add packet length here

            for (int a = 0; a < val; a++)
            {
                // Account loop \\
                Console.Write(" " + account[a].ToString("X"));
            }

            Console.Write(" 00 0" + Convert.ToByte(test + 1) + " 00");

            for (int i = 0; i < pal; i++)
            {           
                Console.Write(" " + password[i].ToString("X"));
            }

            Console.Write(" 00 AC 01 00 00 02 00 30 00\n");
        }
    }
}
