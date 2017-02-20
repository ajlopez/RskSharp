namespace RskSharp.Tests.Core.Builders
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RskSharp.Core.Builders;
    using RskSharp.Core;

    [TestClass]
    public class BlockHeaderBuilderTests
    {
        [TestMethod]
        public void GetBlockZero()
        {
            BlockHeaderBuilder builder = new BlockHeaderBuilder();

            BlockHeader block = builder.Build();

            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.Number);
        }

        [TestMethod]
        public void GetBlockWithNumber()
        {
            BlockHeaderBuilder builder = new BlockHeaderBuilder();

            BlockHeader block = builder.Number(42).Build();

            Assert.IsNotNull(block);
            Assert.AreEqual(42, block.Number);
        }
    }
}
