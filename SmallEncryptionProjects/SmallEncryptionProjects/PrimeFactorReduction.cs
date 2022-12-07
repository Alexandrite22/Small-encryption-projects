using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEncryptionProjects
{
    class EncryptPrimeFactorReduction
    {
        public EncryptPrimeFactorReduction()
        {

        }
        public string Encrypt(string input)
        {
            return ConvertInputToPrimeFactors(ConvertInputToLong(input));
        }
        private long ConvertInputToLong(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                string chunk = "" + (int)input[i];
                if (chunk.Length == 2)
                {
                    chunk = "0" + chunk;
                }
                output = output + (int)input[i];
            }
            return Int64.Parse(output);
        }
        //need to create a function that t
        private string ConvertInputToPrimeFactors(long input)
        {
            List<long> primeNumbers = new List<long>(2);
            List<long> primeFactors = new List<long>();
            string output = "0";
            for (long i = primeNumbers[0]; i < input; i++)
            {
                bool isPrime = true;
                foreach(long primeNum in primeNumbers)
                {
                    if (i % primeNum == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime == true)
                {
                    primeNumbers.Add(i);
                }
            }
            primeNumbers.Reverse();
            foreach(long primeNum in primeNumbers)
            {
                while (input % primeNum == 0)
                {
                    primeFactors.Add(primeNum);
                    input = input / primeNum;
                }
            }
            if (primeFactors.Count == 0)
            {
                return "0"+input.ToString();
            }
            else
            {
                foreach(long factor in primeFactors)
                {
                    output = output+"0"+factor;
                }
                return output;
            }
        }
    }
}
