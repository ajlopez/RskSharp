namespace RskSharp.Tests.Core
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RskSharp.Core;

    [TestClass]
    public class BlockHeaderTests
    {
        [TestMethod]
        public void CreateBlockHeaderWithNumber()
        {
            BlockHeader header = new BlockHeader(42);

            Assert.AreEqual(42, header.Number);
        }

        [TestMethod]
        public void CreateBlockHeaderWithNumberAndParentHash()
        {
            Hash parentHash = new Hash();

            BlockHeader header = new BlockHeader(42, parentHash);

            Assert.AreEqual(42, header.Number);
            Assert.AreEqual(parentHash, header.ParentHash);
        }
    }
}
