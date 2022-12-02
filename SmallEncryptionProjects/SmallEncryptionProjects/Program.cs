using System;

namespace SmallEncryptionProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Maria Rivera1872458~~```()()";
            ASCIIEncrypt test = new ASCIIEncrypt();
            Console.WriteLine(
            "'"+name+"' will encrypt to '" + test.Encrypt(name) + "'.\n" +
            "'" + test.Encrypt(name) + "' will decrypt back to '" + test.decrypt(test.Encrypt(name)) + "'!");
        }
    }
}
