# Small-encryption-projects
a series of small manageable proof-of-concept encryptions only for recreational use

12/2/2022
*Adding "encrypt with ASCII addition" 

    ENCRYPTION
    1. Takes a string and breaks the string into pairs of char values.
    2. Adds the ASCII values of both chars together and concatenates the first char value in front of the resulting integer.
    3. Rebuilds the string for display purposes.

    DECRYPTION
    1. Splits the string into pairs of char values their paired integers.
    2. subtracts the ASCII value of the first char from the integer in order to convert the integer back into a char
    3.Rebuilds the original un-encrypted string for display purposes
