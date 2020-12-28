using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MDrop.MagicDrop
{
    public class MagicDropWinner
    {
        public string Date { get; } = DateTime.Now.ToString();
        public string Winner { get; } = string.Empty;
        public string Weapon { get; } = string.Empty;
        public string Skin { get; } = string.Empty;
        public string Price { get; } = string.Empty;

        private static Regex regex = new Regex(
            @"(^(?<weapon>[^|]*))(\|(?<skin>[^(]*))(\((?<price>[^)]*)\))",
            RegexOptions.Compiled);

        internal MagicDropWinner(string winner, string skinAndPrice)
        {
            Winner = winner;

            var match = regex.Match(skinAndPrice);
            if (match.Success)
            {
                Weapon = match.Groups["weapon"].Value.Trim();
                Skin = match.Groups["skin"].Value.Trim();
                Price = match.Groups["price"].Value.Trim();
            }
        }
    }
}
