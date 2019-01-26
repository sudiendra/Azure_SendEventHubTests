using System;
using Microsoft.Azure.EventHubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventHubTests;

namespace EHTUnitTests
{
    [TestClass]
    public class eventhubtester
    {
        public string filePath = null;
        public string key = null;
        [TestMethod]
        public void SecretMethodTest()
        {
        filePath = @"c:\temp\testeventhub1.txt";
        key = Secretlookup.GetKey(filePath);    
        }

        [TestMethod]
        public void ConnectionTestwithEmptyString()
        {
            EventHubClient eventHubClient = Program.BuildConnectionString(string.Empty); 
        }
    }
}
