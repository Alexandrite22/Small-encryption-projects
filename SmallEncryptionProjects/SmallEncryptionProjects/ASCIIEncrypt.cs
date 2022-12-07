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
                inputTemp = input.Substring(0, input.Length - 1);
            }
            do
            {
                string chunk = inputTemp.Substring(0, 2);
                inputTemp = inputTemp.Substring(2, inputTemp.Length - 2);
                tempSectioned.Add(chunk);
            } while (inputTemp.Length > 0);
            foreach (string chunk in tempSectioned)             //encrypts each individual chunk
            {
                string encryptedNumber = ""+(chunk[0]+chunk[1]);
                if (encryptedNumber.Length == 2)
                {
                    encryptedNumber = '0' + encryptedNumber;
                }
                string encryptedChunk = (chunk[0] + "" + encryptedNumber);
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
        //The encrypted string will always be a length of multiple of four (maybe plus one)
        //each chunk of four will consist of (a single char which ascii value is between 32-126)
        //and an int between 64 (written as 064) and (written as 252)
        //if any of those numbers fall outside of that range the string is invalid and will return (Invalid Encrypted File, check validity)
        public string Decrypt(string input)
        {
            string decryptedString = "";
            if(((input.Length%4) == 0 || (input.Length-1)%4 == 0) == false)
            {
                return "String cannot be decrypted, please input a string of the correct length";
            }
            List<string> chunks = parseToChunks(input);
            if (checkValidity(chunks) == true)
            {
                foreach (string chunk in chunks)
                {
                    decryptedString = decryptedString+decryptChunks(chunk);
                }
                return decryptedString;   
            }
            else
            {
                return "String cannot be decrypted";
            }
        }
        private List<string> parseToChunks(string input)
        {
            List<string> parsedChunks = new List<string>();
            string floatingString = "";
            if (input.Length % 4 != 0)
            {
                floatingString = input[input.Length-1]+"";
                input = input.Substring(0,input.Length-1);
            }
            do
            {
                parsedChunks.Add(input.Substring(0, 4));
                input = input.Substring(4, input.Length - 4);
            } while (input.Length > 0);
            if(floatingString.Length == 1)
            {
                parsedChunks.Add(floatingString);
            }
            return parsedChunks;
        }
        private bool checkValidity(List<string> input)
        {
            foreach(string chunk in input)
            {
                if(chunk.Length == 4)
                {
                    int ASCIIRange = Int32.Parse(chunk.Substring(1,3));
                    if (ASCIIRange < 64 || ASCIIRange > 252)
                    {
                        return false;
                    }
                }    
            }
            return true;
        }
        private string decryptChunks (string chunk)
        {
            if(chunk.Length == 1)
            {
                return chunk;
            }
            string decrypted = chunk[0] + "";
            int ASCIICode = Int32.Parse(chunk.Substring(1, 3)) - chunk[0];
            decrypted = decrypted + (char)ASCIICode;
            return decrypted;
        }

    }
}
