using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static string FindLongestVowelSubstring(string input)
    {
        string vowels = "aeiouy";
        var vowelIndexes = input
            .Select((ch, index) => new { ch, index })
            .Where(x => vowels.Contains(x.ch))
            .Select(x => x.index)
            .ToList();

        if (vowelIndexes.Count < 2)
        {
            return string.Empty;
        }

        int start = vowelIndexes.First();
        int end = vowelIndexes.Last();
        return input.Substring(start, end - start + 1);
    }

    static void Main()
    {
        Console.WriteLine("Вход");
        string lines = Console.ReadLine();
        int length = lines.Length;
        int midIndex = length / 2;
        Regex newReg = new Regex(@"[^a-z]", RegexOptions.None);
        MatchCollection matches = newReg.Matches(lines);
        string firstHalf = lines.Substring(0, midIndex);
        string secondHalf = lines.Substring(midIndex);
        string result = ReverseString(firstHalf) + ReverseString(secondHalf);
        var revers = ReverseString(lines) + lines;
        var array = lines.ToCharArray();
        var returns = array.Distinct();

        if (matches.Count > 0)
        {
            foreach (Match mat in matches)
            {
                Console.WriteLine(@"Ошибка, недопустимый символ: " + mat.Value);
            }
        }
        else
        {
            string output = length % 2 == 0 ? result : revers;
            Console.WriteLine($"Выход: {output}");
            foreach (var x in returns)
            {
                Console.WriteLine("{0} повторяется {1} раз(а)", x, output.Count(c => c == x));
            }

            string longestVowelSubstring = FindLongestVowelSubstring(output);
            if (string.IsNullOrEmpty(longestVowelSubstring))
            {
                Console.WriteLine("Ошибка: нет подходящей подстроки.");
            }
            else
            {
                Console.WriteLine($"Самая длинная подстрока, начинающаяся и заканчивающаяся на гласную: {longestVowelSubstring}");
            }
        }
        Console.ReadKey();
    }
}
