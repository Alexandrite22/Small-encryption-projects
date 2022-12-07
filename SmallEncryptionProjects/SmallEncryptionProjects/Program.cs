using System;

namespace SmallEncryptionProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            ASCIIEncrypt Ascii = new ASCIIEncrypt();
            EncryptPrimeFactorReduction PrimeFactor = new EncryptPrimeFactorReduction();

            string name = "Alex Hewson!";
            Console.WriteLine("'"+name+"' Encrypted: "+Ascii.Encrypt(name));
            Console.WriteLine("'" + Ascii.Encrypt(name) + "' Decrypts: " + Ascii.Decrypt(Ascii.Encrypt(name)));

            Console.WriteLine("'"+name+"' Encrypted: "+PrimeFactor.Encrypt(name));

        }
    }
}
