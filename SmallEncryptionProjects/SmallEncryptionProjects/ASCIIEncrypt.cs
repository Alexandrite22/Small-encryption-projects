using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEncryptionProjects
{
    class ASCIIEncrypt
    {
        public ASCIIEncrypt()
        {

        }
        public string Encrypt(string input)
        {
            string inputTemp = input;                           //Holds a temprary instance of the string with the last char removed IF the length of the string was an odd number
            string oddLengthSingleChar = null;                  //Holds the odd numbered char removed from the original string to be added on to the end of the encrypted text
            List<string> tempSectioned = new List<string>();    //Holds the inputTemp after it has been chopped into sections of strings of length 2
            List<string> tempEncrypted = new List<string>();    //Holds the encrypted sections from the original list
            string encryptedString = "";                        //Holds the final encrypted string

            if (input.Length % 2 == 1)                          //checks for an off number of charecters and removes the last one for later use
            {
                oddLengthSingleChar = inputTemp.Substring(inputTemp.Length - 1, 1);
                Console.WriteLine(oddLengthSingleChar);
                inputTemp = input.Substring(0, input.Length - 1);
                Console.WriteLine(inputTemp);
            }
            do
            {
                string chunk = inputTemp.Substring(0, 2);
                inputTemp = inputTemp.Substring(2, inputTemp.Length - 2);
                tempSectioned.Add(chunk);
            } while (inputTemp.Length > 0);
            /*for (int i = 0; i < inputTemp.Length; i += 2)       //parses the even numbered length string into chunks for individual encryption
            {
                string chunk = inputTemp.Substring(i, 2);
                tempSectioned.Add(chunk);
                Console.WriteLine(inputTemp.Substring(i, 2));   
            }*/
            foreach (string chunk in tempSectioned)             //encrypts each individual chunk
            {
                string encryptedChunk = (chunk[0] + "" + (chunk[0] + chunk[1]));
                tempEncrypted.Add(encryptedChunk);
            }
            if (oddLengthSingleChar != null)                    //if there was an odd number of chars, re adds the char back in post encryption
            {
                tempEncrypted.Add(oddLengthSingleChar);
            }
            foreach(string chunk in tempEncrypted)              //rebuilds the string post encryption
            {
                encryptedString += chunk;
            }   
            return encryptedString;                             //returns encrypted string
        }
    }
}
