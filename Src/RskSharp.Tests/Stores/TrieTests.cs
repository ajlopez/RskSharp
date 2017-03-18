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

        [TestMethod]
        public void SetGetKeyValue()
        {
            Trie trie = new Trie();

            var key = new byte[] { 0x01, 0x02, 0x3 };
            var value = new byte[] { 0x04, 0x05, 0x06 };

            Trie result = trie.SetValue(key, value);

            Assert.IsNotNull(result);
            Assert.AreEqual(value, result.GetValue(key));
        }
    }
}
