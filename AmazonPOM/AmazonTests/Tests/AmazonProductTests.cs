using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonPOM.AmazonTests.Tests
{
    internal class AmazonProductTests : PageTest
    {
        Dictionary<string, string> Properties;
        string? currdir;
        private void ReadConfigSettings()
        {
            Properties = new Dictionary<string, string>();
            currdir = Directory.GetParent(@"../../../")?.FullName;

            string fileName = currdir + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains('='))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    Properties[key] = value;
                }
            }
        }
    }
}
