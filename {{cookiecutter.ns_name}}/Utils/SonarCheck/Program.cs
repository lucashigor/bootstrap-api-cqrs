using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SonarCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new Exception("Please inform the path to SonarQubeBuildSummary.md");
            }

            string content = File.ReadAllText(args[0]);

            const string passed = "Passed";
            const string urlPattern = @"\[.*\]\((.*)\)";

            MatchCollection matchPassed = Regex.Matches(content, passed, RegexOptions.IgnoreCase);

            if (matchPassed.Count == 1)
            {
                Console.WriteLine("Sonar check OK");
                return;
            }

            Match match = Regex.Match(content, urlPattern);

            throw new Exception("Sonar check failed, please check " + match.Groups[1].Value);
        }
    }
}
