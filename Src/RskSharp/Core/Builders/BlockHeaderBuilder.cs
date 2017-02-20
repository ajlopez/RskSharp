namespace RskSharp.Core.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockHeaderBuilder
    {
        private long number;

        public BlockHeaderBuilder Number(long number)
        {
            this.number = number;

            return this;
        }

        public BlockHeader Build()
        {
            return new BlockHeader(this.number);
        }
    }
}

