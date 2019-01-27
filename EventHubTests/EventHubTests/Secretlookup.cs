using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EventHubTests
{
    public static class Secretlookup
    {
        public static string GetKey(string filePath)
        {
            string key = null;
            if (File.Exists(filePath))
            {
                key = File.ReadAllText(filePath);
            }
            return key;
        }
    }
}
