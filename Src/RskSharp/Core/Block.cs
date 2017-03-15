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

        public Block(long number, Hash parentHash)
            : this(new BlockHeader(number, parentHash))
        {
        }

        public BlockHeader Header { get { return this.header; } }

        public long Number { get { return this.header.Number; } }

        public Hash Hash { get { return this.header.Hash; } }

        public Hash ParentHash { get { return this.header.ParentHash; } }

        public Boolean IsGenesis { get { return this.Number == 0; } }

        public Boolean HasParent(Block parent)
        {
            return this.ParentHash != null && this.ParentHash.Equals(parent.Hash);
        }
    }
}

