namespace RskSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Block
    {
        private BlockHeader header;

        public Block(BlockHeader header)
        {
            this.header = header;
        }

        public BlockHeader Header { get { return this.header; } }

        public long Number { get { return this.header.Number; } }

        public Hash ParentHash { get { return this.header.ParentHash; } }
    }
}

