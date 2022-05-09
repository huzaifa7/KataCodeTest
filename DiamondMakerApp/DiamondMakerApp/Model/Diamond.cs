using DiamondMakerApp.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DiamondMakerApp.Model
{
    public class Diamond
    {
        private List<string> rows;
        public Diamond()
        {
            rows = new List<string>();
        }

        public void Create(string inputCharacter)
        {
            if (!DiamondExtension.Alphabets.Contains(inputCharacter))
                return;

            if (IsFirstCharacterInAlphabet(inputCharacter))
            {
                rows.Add(inputCharacter);
                return;
            }
            
            var index = DiamondExtension.Alphabets.IndexOf(inputCharacter);

            var alphabetShortList = DiamondExtension.Alphabets.Take(index+1);

            foreach (var character in alphabetShortList)
            {
                if (IsFirstCharacterInAlphabet(character))
                {
                    rows.Add(character);
                    continue;
                }

                var rowsWithSpacing = DiamondExtension.AddSpacingBetweenCharacter(character, rows.Last().Length);
                rows.Add(rowsWithSpacing);
            }

            var length = GetLengthOfLongestLine(rows);

            var paddedDiamondRows = rows.Select(x => DiamondExtension.AddPaddingAroundCharacters(length, x));

            var reversedPaddedDiamondRows = DiamondExtension.ReverseOutput(paddedDiamondRows);

            rows = paddedDiamondRows.Concat(reversedPaddedDiamondRows).ToList();
        }

        public List<string> Rows()
        {
            return rows;
        }

        private static bool IsFirstCharacterInAlphabet(string inputCharacter)
        {
            return DiamondExtension.Alphabets.First() == inputCharacter;
        }

        private static int GetLengthOfLongestLine(IEnumerable<string> collection)
        {
            return collection.Max(x => x.Length);
        }
    }
}
