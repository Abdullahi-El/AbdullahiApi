using System.Text;

public class EncryptionService
{
    // Caesar cipher function for encryption and decryption
    public string CaesarCipher(string input, int shift)
    {
        var result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (char.IsLetter(c))
            {
                char d = char.IsUpper(c) ? 'A' : 'a';
                result[i] = (char)((((c - d) + shift + 26) % 26) + d); // wrap around using modulo
            }
            else
            {
                result[i] = c; // Non-letter characters are not altered
            }
        }

        return new string(result);
    }

    // Rövarspråket encryption function
    public string RovarspraketEncrypt(string input)
    {
        var result = new StringBuilder();
        string consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";

        foreach (char c in input)
        {
            if (consonants.Contains(c))
            {
                result.Append(c);
                result.Append('o');
                result.Append(char.ToLower(c));
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    // Rövarspråket decryption function
    public string RovarspraketDecrypt(string input)
    {
        var result = new StringBuilder();
        int i = 0;

        while (i < input.Length)
        {
            result.Append(input[i]);
            if (char.IsLetter(input[i]) && "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ".Contains(input[i]))
            {
                i += 3; // Skip the 'o' and the repeated consonant
            }
            else
            {
                i++;
            }
        }

        return result.ToString();
    }
}