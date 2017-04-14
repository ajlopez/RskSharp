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

        [TestMethod]
        public void SetGetTwoKeyValues()
        {
            var key1 = new byte[] { 0x01, 0x02, 0x3 };
            var value1 = new byte[] { 0x04, 0x05, 0x06 };
            var key2 = new byte[] { 0x07, 0x08, 0x09 };
            var value2 = new byte[] { 0x0a, 0x0b, 0x0c };

            Trie result = new Trie().SetValue(key1, value1).SetValue(key2, value2);

            Assert.IsNotNull(result);
            Assert.AreEqual(value1, result.GetValue(key1));
            Assert.AreEqual(value2, result.GetValue(key2));
        }
    }
}
