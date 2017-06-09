using System;
using System.Collections.Generic;

namespace MorseCode
{
    public class UndecodableStringException: Exception
    {
        public UndecodableStringException(IEnumerable<string> unrecognizedMorseSymbols)
        {
            UnrecognizedMorseSymbols = unrecognizedMorseSymbols;
        }

        // we just need to enumerate these -- IEnumerable<T> will be enough
        public IEnumerable<string> UnrecognizedMorseSymbols { get; }
    }
}
