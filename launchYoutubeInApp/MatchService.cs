using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace launchYoutubeInApp
{
    public class MatchService
    {
        const string videoIDMatchRegexString = "(?:youtube\\.com\\/(?:[^\\/]+\\/.+\\/|(?:v|e(?:mbed)?)\\/|.*[?&]v=)|youtu\\.be\\/)([^\" &?\\/ ]{11})";

        public const string notFoundVideoID = "noVideoFound";
        Regex rx;

        public MatchService()
        {   
            rx = new Regex(videoIDMatchRegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public string Match(string videoUrl)
        {
            string videoIDToReturn = notFoundVideoID;

            MatchCollection matches = rx.Matches(videoUrl);

            if (matches.Count > 0)
            {
                if (matches[0].Groups.Count > 1)
                {
                    // Because of the nature of the regex string
                    // the video ID will always be in the second group (Index 1).
                    videoIDToReturn = matches[0].Groups[1].Value;

                }
            }

            return videoIDToReturn;
        }
    }
}
