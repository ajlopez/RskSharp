namespace RskSharp.Tests.Core
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RskSharp.Core;

    [TestClass]
    public class BlockHeaderTests
    {
        [TestMethod]
        public void createBlockHeaderWithNumber()
        {
            BlockHeader header = new BlockHeader(42);

            Assert.AreEqual(42, header.Number);
        }
    }
}
