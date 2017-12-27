using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2017_06_07.Tests
{
    [TestClass]
    public class MorseCodeTests
    {
        private MorseCodeDecoder _morseCodeDecoderKata;
        private const string MorseCodeLetter = "....";
        private const string MorseCodeWordWithThreeLetters = ".... . -.--";
        private const string TwoMorseCodeWords = ".... . -.--   .--- ..- -.. .";

        private const string TestString = ".... . -.--   .--- ..- -.. .";
        private const string ResultString = "hey jude";

        [TestInitialize]
        public void Initialize()
        {
            _morseCodeDecoderKata = new MorseCodeDecoder();
        }

        // First test, doing TDD, so I'll work from test to implementation
        // Should get two words
        [TestMethod]
        public void Should_Return_Two_Words()
        {
            var words = _morseCodeDecoderKata.GetWords(TwoMorseCodeWords);
            Assert.IsTrue(words.Count == 2);
        }

        // Second test, bit like the first one, but with letters this time
        [TestMethod]
        public void Should_Return_Word_With_Three_Letters()
        {
            var letters = _morseCodeDecoderKata.GetLetters(MorseCodeWordWithThreeLetters);
            Assert.IsTrue(letters.Count == 3);
        }

        // Having a morse letter, I should get the roman letter
        [TestMethod]
        public void Should_Return_Letter_For_MorseCodeLetter()
        {
            var letter = _morseCodeDecoderKata.ReplaceLetter(MorseCodeLetter);
            Assert.IsTrue(Regex.Matches(letter, @"[a-z]").Count == 1);
            Assert.IsTrue(letter == "h");
        }

        // Once we have the other tests, we convert the entire morse code
        [TestMethod]
        public void Should_Convert_MorseCode_To_Letters()
        {
            var decodedMorse = _morseCodeDecoderKata.DecodeMorse(TestString);
            Assert.IsTrue(decodedMorse == ResultString);
        }
    }
}
