using System;

namespace SmallEncryptionProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            ASCIIEncrypt test = new ASCIIEncrypt();
            Console.WriteLine(test.Encrypt("Alexander Hewson!"));
        }
    }
}
