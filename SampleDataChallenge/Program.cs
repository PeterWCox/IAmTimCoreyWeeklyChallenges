using System;

namespace SampleDataChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleData s = new SampleData();

            for (int i=0; i<=10; i++)
            {
                System.Console.WriteLine(s.GenerateRandomDouble(-1000, -1));
            }


        }
    }
}
