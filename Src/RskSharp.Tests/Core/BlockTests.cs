namespace RskSharp.Tests.Core
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RskSharp.Core;

    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void CreateBlockWithHeader()
        {
            BlockHeader header = new BlockHeader(42);
            Block block = new Block(header);

            Assert.AreSame(header, block.Header);
            Assert.AreEqual(42, block.Number);
        }
    }
}
