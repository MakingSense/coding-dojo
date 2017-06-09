using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable once CheckNamespace -- reason: Using same namespace as tested class
namespace MorseCode
{
    [TestClass]
    public class MorseCodeTranslatorTests
    {
        #region Encode
        // This exercise is about decoding, but a Morse decoder would be incomplete without an encoder!
        [TestMethod]
        public void Encode_CanEncodeSingleWords()
        {
            var translator = GetConfiguredMorseCodeTranslator();

            Assert.AreEqual(".... . -.--", translator.Encode("hey"));
            Assert.AreEqual(".--- ..- -.. .", translator.Encode("jude"));
        }

        [TestMethod]
        public void Encode_IgnoresCasing()
        {
            var translator = GetConfiguredMorseCodeTranslator();

            Assert.AreEqual(".--- ..- -.. .", translator.Encode("Jude"));
            Assert.AreEqual(".--- ..- -.. .", translator.Encode("jude"));
            Assert.AreEqual(".--- ..- -.. .", translator.Encode("juDe"));
            Assert.AreEqual(".--- ..- -.. .", translator.Encode("JUDE"));
        }

        [TestMethod]
        public void Encode_IgnoresUnknownCharacters()
        {
            var translator = GetConfiguredMorseCodeTranslator();

            Assert.AreEqual(".--- ..- -.. .", translator.Encode("Jude@"));
            Assert.AreEqual(".--- ..- -.. .", translator.Encode("jude%"));
            Assert.AreEqual(".--- ..- -.. .", translator.Encode("ájuDeá"));
            Assert.AreEqual(".--- ..- -.. .", translator.Encode("';JUDE"));
            Assert.AreEqual(".... . -.-- .--- ..- -.. .", translator.Encode("HeyJude"));
        }

        [TestMethod]
        public void Encode_RespectsSettingsForDotCharacter()
        {
            var translator = GetConfiguredMorseCodeTranslator(dotCharacter: '·');

            Assert.AreEqual("···· · -·-- ·--- ··- -·· ·", translator.Encode("HeyJude"));
        }

        [TestMethod]
        public void Encode_RespectsSettingsForDashCharacter()
        {
            var translator = GetConfiguredMorseCodeTranslator(dashCharacter: '—');

            Assert.AreEqual(".... . —.—— .——— ..— —.. .", translator.Encode("HeyJude"));
        }

        [TestMethod]
        public void Encode_IncludesASeparatorForWords()
        {
            var translator = GetConfiguredMorseCodeTranslator();

            Assert.AreEqual(".... . -.--   .--- ..- -.. .", translator.Encode("Hey Jude"));
        }
        #endregion

        #region Decode
        [TestMethod]
        public void Decode_CanDecodeSingleWords()
        {
            var translator = GetConfiguredMorseCodeTranslator();

            Assert.AreEqual("hey", translator.Decode(".... . -.--"));
            Assert.AreEqual("jude", translator.Decode(".--- ..- -.. ."));
        }

        [TestMethod]
        public void Decode_CanDecodeWholeSentences()
        {
            var translator = GetConfiguredMorseCodeTranslator();

            Assert.AreEqual("hey jude", translator.Decode(".... . -.--   .--- ..- -.. ."));
        }

        [TestMethod]
        public void Decode_RespectsTheSettingForMorseCodeWordSeparator()
        {
            var translator = GetConfiguredMorseCodeTranslator(morseWordSeparator: "//");
            Assert.AreEqual("hey jude", translator.Decode(".... . -.-- // .--- ..- -.. ."));

            translator = GetConfiguredMorseCodeTranslator(morseWordSeparator: "--------");
            Assert.AreEqual("hey jude", translator.Decode(".... . -.-- -------- .--- ..- -.. ."));
        }

        [TestMethod]
        [ExpectedException(typeof(UndecodableStringException))]
        public void Decode_ThrowsUnencodableStringException_WhenItCannotRecognizeMorseSymbols()
        {
            var translator = GetConfiguredMorseCodeTranslator();

            translator.Decode("... --@$#");
        }

        [TestMethod]
        public void Decode_ReturnsTheUnencodableElements_WhenItCannotRecognizeMorseSymbols()
        {
            var translator = GetConfiguredMorseCodeTranslator();

            try
            {
                translator.Decode("... -- @ $ # ........");
            }
            // catching only this exception: all others should make the test fail
            catch (UndecodableStringException use)
            {
                // couldn't use Collection.Assert because it required a non-generic ICollection
                Assert.IsTrue(use.UnrecognizedMorseSymbols.Contains("@"));
                Assert.IsTrue(use.UnrecognizedMorseSymbols.Contains("$"));
                Assert.IsTrue(use.UnrecognizedMorseSymbols.Contains("#"));
                Assert.IsTrue(use.UnrecognizedMorseSymbols.Contains("........"));
            }
        }
        #endregion

        private MorseCodeTranslator GetConfiguredMorseCodeTranslator(
            char dotCharacter = '.',
            char dashCharacter = '-',
            string morseWordSeparator = "   "
        ) => new MorseCodeTranslator(dotCharacter, dashCharacter, morseWordSeparator);
    }
}