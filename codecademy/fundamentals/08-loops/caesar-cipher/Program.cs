using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
      
            Console.Write("What's your secret message?: ");
            string secret = Console.ReadLine();
            char[] secretMessage = secret.ToCharArray();
            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++) {
                char character = secretMessage[i];
                int currentCharPosition = Array.IndexOf(alphabet, character);

                int keyLetterPosition = (currentCharPosition + 3) % alphabet.Length;

                char encryptedChar = alphabet[keyLetterPosition];
                encryptedMessage[i] = encryptedChar;
            }
      
            Console.WriteLine(String.Join("", encryptedMessage));
        }
    }
}