namespace RskSharp.Tests.Stores
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RskSharp.Stores;

    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void GetUnknownKeyValue()
        {
            Trie trie = new Trie();

            Assert.IsNull(trie.GetValue(new byte[] { 0x01, 0x02, 0x03 }));
        }
    }
}
