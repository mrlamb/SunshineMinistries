using Transportation;
using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Initialize server

                Transport.StartListener();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            while(true)
                {
                }
        }

       }
}
