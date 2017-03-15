namespace RskSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockInfo
    {
        private Block block;

        public BlockInfo(Block block)
        {
            this.block = block;
        }

        public Block Block { get { return this.block; } }
    }
}
