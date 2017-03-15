namespace RskSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockHeader
    {
        private Hash hash;
        private long number;
        private Hash parentHash;

        public BlockHeader(long number)
            : this(number, null)
        {
        }

        public BlockHeader(long number, Hash parentHash)
        {
            this.number = number;
            this.parentHash = parentHash;
            this.hash = new Hash();
        }

        public long Number { get { return this.number; } }

        public Hash ParentHash { get { return this.parentHash; } }

        public Hash Hash { get { return this.hash; } }
    }
}
