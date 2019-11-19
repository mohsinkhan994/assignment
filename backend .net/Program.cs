using System;
using System.Text;

namespace question1
{
    class Program
    {
        public static void Main(string[] args)
        {
           try
            {
                throw new NullReferenceException("C");
                Console.WriteLine("A");

            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("B");
            }
            Console.ReadLine();
        }
    }
}
