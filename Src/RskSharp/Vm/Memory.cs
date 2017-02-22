﻿namespace RskSharp.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class Memory
    {
        private BigInteger blocksize;
        private IDictionary<BigInteger, byte[]> blocks = new Dictionary<BigInteger, byte[]>();

        public Memory()
            : this(1024)
        {
        }

        public Memory(int blocksize)
        {
            this.blocksize = new BigInteger(blocksize);
        }

        public DataWord GetDataWord(DataWord address)
        {
            int offset;
            byte[] bytes = this.GetBlock(address, out offset);

            if (bytes != null) 
            {
                var dbytes = new byte[32];
                Array.Copy(bytes, offset, dbytes, 0, 32);
                return new DataWord(dbytes);
            }

            return DataWord.Zero;
        }

        public void PutBytes(DataWord address, byte[] values)
        {
            int offset;
            byte[] bytes = this.GetOrCreateBlock(address, out offset);

            if (values.Length > this.blocksize - offset)
            {
                int l = (int)this.blocksize - offset;
                Array.Copy(values, 0, bytes, offset, l);
                bytes = this.GetOrCreateBlock(address.Add(new DataWord(l)), out offset);
                Array.Copy(values, l, bytes, offset, values.Length - l);
            }
            else
                Array.Copy(values, 0, bytes, offset, values.Length);
        }

        public byte GetByte(DataWord address)
        {
            int offset;
            byte[] bytes = this.GetBlock(address, out offset);

            if (bytes != null)
                return bytes[offset];

            return 0;
        }

        public void PutByte(DataWord address, byte value)
        {
            int offset;
            byte[] bytes = this.GetOrCreateBlock(address, out offset);

            bytes[offset] = value;
        }

        private byte[] GetBlock(DataWord address, out int offset) 
        {
            var value = address.Value;
            BigInteger remainder = 0;
            var div = BigInteger.DivRem(value, this.blocksize, out remainder);

            offset = (int)remainder;
            
            if (this.blocks.ContainsKey(div))
                return this.blocks[div];

            return null;
        }

        private byte[] GetOrCreateBlock(DataWord address, out int offset) 
        {
            var value = address.Value;
            BigInteger remainder = 0;
            var div = BigInteger.DivRem(value, this.blocksize, out remainder);

            offset = (int)remainder;

            if (this.blocks.ContainsKey(div))
                return this.blocks[div];

            this.blocks[div] = new byte[(int)this.blocksize];

            return this.blocks[div];
        }
    }
}
