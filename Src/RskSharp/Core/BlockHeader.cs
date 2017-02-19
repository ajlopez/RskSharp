namespace RskSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockHeader
    {
        private long number;

        public BlockHeader(long number)
        {
            this.number = number;
        }

        public long Number { get { return this.number; } }
    }
}
