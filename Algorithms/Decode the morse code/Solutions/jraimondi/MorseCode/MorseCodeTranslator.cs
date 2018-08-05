using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCode
{
    public class MorseCodeTranslator
    {
        // I noticed that the dash character was not the same as the minus one
        // I decided to make this configurable since different sources can use different characters for dash/dot
        // TODO all these configurations could be isolated in a MorseTranslatorConfiguration object
        public MorseCodeTranslator(
            char dotCharacter = '.', 
            char dashCharacter = '-', 
            string morseWordSeparator = "   ")
        {
            InitializeMaps(dotCharacter, dashCharacter);

            _morseWordSeparator = morseWordSeparator;
        }

        // I would like these fields to be readonly, but for that I'd need to dump the whole
        // contents of `InitializeMaps` into the constructor. Not worth it.
        private Dictionary<char, string> _charToMorseSymbol;
        private Dictionary<string, char> _morseSymbolToChar;
        private readonly string _morseWordSeparator;

        private void InitializeMaps(char dotCharacter, char dashCharacter)
        {
            // unnecessary variables, but just for readability of the next lines
            var dot = dotCharacter;
            var dash = dashCharacter;

            _charToMorseSymbol = new Dictionary<char, string>()
            {
                {'a', string.Concat(dot, dash)},
                {'b', string.Concat(dash, dot, dot, dot)},
                {'c', string.Concat(dash, dot, dash, dot)},
                {'d', string.Concat(dash, dot, dot)},
                {'e', dot.ToString()},
                {'f', string.Concat(dot, dot, dash, dot)},
                {'g', string.Concat(dash, dash, dot)},
                {'h', string.Concat(dot, dot, dot, dot)},
                {'i', string.Concat(dot, dot)},
                {'j', string.Concat(dot, dash, dash, dash)},
                {'k', string.Concat(dash, dot, dash)},
                {'l', string.Concat(dot, dash, dot, dot)},
                {'m', string.Concat(dash, dash)},
                {'n', string.Concat(dash, dot)},
                {'o', string.Concat(dash, dash, dash)},
                {'p', string.Concat(dot, dash, dash, dot)},
                {'q', string.Concat(dash, dash, dot, dash)},
                {'r', string.Concat(dot, dash, dot)},
                {'s', string.Concat(dot, dot, dot)},
                {'t', string.Concat(dash)},
                {'u', string.Concat(dot, dot, dash)},
                {'v', string.Concat(dot, dot, dot, dash)},
                {'w', string.Concat(dot, dash, dash)},
                {'x', string.Concat(dash, dot, dot, dash)},
                {'y', string.Concat(dash, dot, dash, dash)},
                {'z', string.Concat(dash, dash, dot, dot)},
                {'0', string.Concat(dash, dash, dash, dash, dash)},
                {'1', string.Concat(dot, dash, dash, dash, dash)},
                {'2', string.Concat(dot, dot, dash, dash, dash)},
                {'3', string.Concat(dot, dot, dot, dash, dash)},
                {'4', string.Concat(dot, dot, dot, dot, dash)},
                {'5', string.Concat(dot, dot, dot, dot, dot)},
                {'6', string.Concat(dash, dot, dot, dot, dot)},
                {'7', string.Concat(dash, dash, dot, dot, dot)},
                {'8', string.Concat(dash, dash, dash, dot, dot)},
                {'9', string.Concat(dash, dash, dash, dash, dot)},
                {' ', " " }
            };

            _morseSymbolToChar = _charToMorseSymbol.ToDictionary(
                keySelector: item => item.Value,
                elementSelector: item => item.Key
            );
        }

        public string Encode(string plainTextInput)
        {
            var lowerCaseInput = plainTextInput.ToLowerInvariant();

            var stringsFromChars = lowerCaseInput.ToCharArray()
                .Where(c => _charToMorseSymbol.ContainsKey(c))
                .Select(c => _charToMorseSymbol[c]);

            // TODO this morse symbol separator could be configurable too
            return string.Join(" ", stringsFromChars);
        }

        public string Decode(string morseCodeInput)
        {
            var words = morseCodeInput.Split(new[] { _morseWordSeparator }, StringSplitOptions.RemoveEmptyEntries);

            var decodedWords = words
                .Select(w => w.Trim())
                .Select(DecodeWord);

            return string.Join(" ", decodedWords);
        }

        private string DecodeWord(string morseInputWord)
        {
            // TODO this morse symbol separator could be configurable too
            var morseSymbolsToTranslate = morseInputWord.Split(' ');

            // TODO Resharper warns about a possible multiple enumeration
            // Is there any way to check for the IEnumerable not being empty without enumerating?
            var unrecognizedMorseSymbols = morseSymbolsToTranslate.Where(ms => !_morseSymbolToChar.ContainsKey(ms));
            if (unrecognizedMorseSymbols.Any())
            {
                throw new UndecodableStringException(unrecognizedMorseSymbols);
            }

            var translatedCharacters = morseSymbolsToTranslate
                .Select(morseSymbol => _morseSymbolToChar[morseSymbol])
                .ToArray();

            return new string(translatedCharacters);
        }
    }
}
