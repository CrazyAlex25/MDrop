using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

using MDrop.MagicDrop;

namespace MDrop
{
    public static class HTMLUtils
    {
        private static readonly IHtmlParser parser = new HtmlParser();

        public static async Task<Dictionary<string, string>> GetSteamOpenId(string html)
        {

            /*
           < input type = "hidden" id = "actionInput" name = "action" value = "steam_openid_login" />
           < input type = "hidden" name = "openid.mode" value = "checkid_setup" />
           < input type = "hidden" name = "openidparams" value = "...." />
           < input type = "hidden" name = "nonce" value = ".........." />
           */

            using (var doc = await parser.ParseDocumentAsync(html))
            {
                var checkLogin = doc.QuerySelector("div[class=\"OpenID_UserContainer\"]");
                if (checkLogin == null)
                    return new Dictionary<string, string>();

                var nodes = doc.QuerySelector("form[id=\"openidForm\"]");
                var inputs = nodes.QuerySelectorAll("input[type=\"hidden\"]").Cast<IHtmlInputElement>();

                var openId = inputs.ToDictionary(x => x.Name, x => x.Value);
                return openId;
            }
        }

        public static async Task<(string Username, MagicDropWinner Winner)> GetMagicDropWinner(string html)
        {
            using (var doc = await parser.ParseDocumentAsync(html))
            {
                var currentUserName = string.Empty;
                var UserName = doc.QuerySelector("div[class=\"header_b_user_profile_t_n\"]");
                if (UserName != null)
                {
                    currentUserName = UserName.TextContent.Trim();
                }


                var winnerRow = doc.QuerySelector("div[class=\"vfreecase_table winner free\"] tr");
                if (winnerRow != null)
                {
                    var strings = winnerRow.Children
                        .Where(x => !string.IsNullOrEmpty(x.TextContent))
                        .Select(x => x.TextContent.Trim()).ToArray();

                    var winner = new MagicDropWinner(strings[0], strings[1]);

                    return (currentUserName, winner);
                }
            }
            return default;
        }

    }
}
