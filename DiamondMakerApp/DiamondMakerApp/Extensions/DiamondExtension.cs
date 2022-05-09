using System;
using System.Collections.Generic;
using System.Linq;

namespace DiamondMakerApp.Extensions
{
    public static class DiamondExtension
    {
        public static readonly List<string> Alphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H",
                                                    "I", "J", "K", "L", "M", "N", "O", "P",
                                                    "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public static string AddSpacingBetweenCharacter(string character, int numberOfSpaces)
        {
            var spacing = string.Join("", Enumerable.Repeat(' ', numberOfSpaces));
            return $"{character}{spacing}{character}";
        }

        public static string AddPaddingAroundCharacters(int maxLength, string row)
        {
            var paddingSize = (maxLength - row.Length) / 2;
            var padding = string.Join("", Enumerable.Repeat(' ', paddingSize));
            return $"{padding}{row}{padding}";
        }

        public static IEnumerable<string> ReverseOutput(IEnumerable<string> collection)
        {
            return collection.SkipLast(1).Reverse();
        }
    }
}
