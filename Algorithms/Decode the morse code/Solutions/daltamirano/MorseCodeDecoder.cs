using System;
using System.Collections.Generic;
using System.Linq;

namespace _2017_06_07
{
    public class MorseCodeDecoder
    {
        private const string RomanWordSeparator = " ";
        private const string MorseCodeLetterSeparator = " ";
        private const string MorseCodeWordSeparator = "   ";
        private const char Dot = '.';
        private const char Dash = '-';

        // Using the resource dictionary
        private readonly Dictionary<char, string> _translator = new Dictionary<char, string>()
        {
            {'a', string.Concat(Dot, Dash)},
            {'b', string.Concat(Dash, Dot, Dot, Dot)},
            {'c', string.Concat(Dash, Dot, Dash, Dot)},
            {'d', string.Concat(Dash, Dot, Dot)},
            {'e', Dot.ToString()},
            {'f', string.Concat(Dot, Dot, Dash, Dot)},
            {'g', string.Concat(Dash, Dash, Dot)},
            {'h', string.Concat(Dot, Dot, Dot, Dot)},
            {'i', string.Concat(Dot, Dot)},
            {'j', string.Concat(Dot, Dash, Dash, Dash)},
            {'k', string.Concat(Dash, Dot, Dash)},
            {'l', string.Concat(Dot, Dash, Dot, Dot)},
            {'m', string.Concat(Dash, Dash)},
            {'n', string.Concat(Dash, Dot)},
            {'o', string.Concat(Dash, Dash, Dash)},
            {'p', string.Concat(Dot, Dash, Dash, Dot)},
            {'q', string.Concat(Dash, Dash, Dot, Dash)},
            {'r', string.Concat(Dot, Dash, Dot)},
            {'s', string.Concat(Dot, Dot, Dot)},
            {'t', string.Concat(Dash)},
            {'u', string.Concat(Dot, Dot, Dash)},
            {'v', string.Concat(Dot, Dot, Dot, Dash)},
            {'w', string.Concat(Dot, Dash, Dash)},
            {'x', string.Concat(Dash, Dot, Dot, Dash)},
            {'y', string.Concat(Dash, Dot, Dash, Dash)},
            {'z', string.Concat(Dash, Dash, Dot, Dot)},
            {'0', string.Concat(Dash, Dash, Dash, Dash, Dash)},
            {'1', string.Concat(Dot, Dash, Dash, Dash, Dash)},
            {'2', string.Concat(Dot, Dot, Dash, Dash, Dash)},
            {'3', string.Concat(Dot, Dot, Dot, Dash, Dash)},
            {'4', string.Concat(Dot, Dot, Dot, Dot, Dash)},
            {'5', string.Concat(Dot, Dot, Dot, Dot, Dot)},
            {'6', string.Concat(Dash, Dot, Dot, Dot, Dot)},
            {'7', string.Concat(Dash, Dash, Dot, Dot, Dot)},
            {'8', string.Concat(Dash, Dash, Dash, Dot, Dot)},
            {'9', string.Concat(Dash, Dash, Dash, Dash, Dot)}
        };

        public List<string> GetWords(string morse)
        {
            return morse.Split(new[] { MorseCodeWordSeparator }, StringSplitOptions.None).ToList();
        }

        public List<string> GetLetters(string morse)
        {
            return morse.Split(new[] { MorseCodeLetterSeparator }, StringSplitOptions.None).ToList();
        }

        public string ReplaceLetter(string morse)
        {
            return _translator.FirstOrDefault(pair => pair.Value == morse).Key.ToString();
        }

        public string DecodeMorse(string morse)
        {
            var result = string.Empty;
            var words = GetWords(morse);
            foreach (var word in words)
            {
                var letters = GetLetters(word);
                result = letters.Select(ReplaceLetter).Aggregate(result, string.Concat);
                result = string.Concat(result, RomanWordSeparator);
            }
            return result.TrimEnd();
        }
    }
}
