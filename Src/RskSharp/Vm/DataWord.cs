﻿namespace RskSharp.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class DataWord
    {
        private static DataWord zero = new DataWord(0);
        private static DataWord one = new DataWord(1);
        private static DataWord two = new DataWord(2);
        private static DataWord three = new DataWord(3);

        private byte[] data;

        public DataWord(int num)
        {
            this.data = new byte[32];
            int value = num;

            for (int k = 0; k < 4; k++)
            {
                this.data[k] = (byte)(value & 0x00ff);
                value >>= 8;
            }

            if (num < 0)
                for (int k = 4; k < 32; k++)
                    this.data[k] = (byte)0xff;
        }

        public DataWord(byte[] bytes)
            : this(bytes, 0, bytes.Length)
        {
        }

        public DataWord(byte[] bytes, int offset, int length)
        {
            this.data = new byte[32];

            for (int k = 0; k < length; k++)
                this.data[k] = bytes[length - k - 1 + offset];
        }

        public DataWord(BigInteger value)
            : this(value.ToByteArray(), true)
        {
        }

        private DataWord(byte[] bytes, bool inverse)
        {
            this.data = new byte[32];

            Array.Copy(bytes, 0, this.data, 0, bytes.Length);

            if ((bytes[bytes.Length - 1] & 0x80) != 0)
                for (int k = bytes.Length; k < 32; k++)
                    this.data[k] = 0xff;
        }

        public static DataWord Zero { get { return zero; } }

        public static DataWord One { get { return one; } }

        public static DataWord Two { get { return two; } }

        public static DataWord Three { get { return three; } }

        public byte[] Bytes { get { return this.data.Reverse().ToArray(); } }

        public BigInteger Value { get { return new BigInteger(this.data); } }

        public DataWord Negate()
        {
            return new DataWord(BigInteger.Negate(this.Value));
        }

        public DataWord Add(DataWord dw)
        {
            return new DataWord(BigInteger.Add(this.Value, dw.Value));
        }

        public DataWord Subtract(DataWord dw)
        {
            return new DataWord(BigInteger.Subtract(this.Value, dw.Value));
        }

        public DataWord Multiply(DataWord dw)
        {
            return new DataWord(BigInteger.Multiply(this.Value, dw.Value));
        }

        public DataWord Divide(DataWord dw)
        {
            return new DataWord(BigInteger.Divide(this.Value, dw.Value));
        }

        public DataWord And(DataWord dw)
        {
            var bytes1 = this.Bytes;
            var bytes2 = dw.Bytes;

            var newbytes = new byte[32];

            for (int k = 0; k < 32; k++)
                newbytes[k] = (byte)(bytes1[k] & bytes2[k]);

            return new DataWord(newbytes);
        }

        public DataWord Or(DataWord dw)
        {
            var bytes1 = this.Bytes;
            var bytes2 = dw.Bytes;

            var newbytes = new byte[32];

            for (int k = 0; k < 32; k++)
                newbytes[k] = (byte)(bytes1[k] | bytes2[k]);

            return new DataWord(newbytes);
        }

        public DataWord Xor(DataWord dw)
        {
            var bytes1 = this.Bytes;
            var bytes2 = dw.Bytes;

            var newbytes = new byte[32];

            for (int k = 0; k < 32; k++)
                newbytes[k] = (byte)(bytes1[k] ^ bytes2[k]);

            return new DataWord(newbytes);
        }

        public DataWord Not()
        {
            var bytes = this.Bytes;
            var newbytes = new byte[32];

            for (int k = 0; k < 32; k++)
                newbytes[k] = (byte)(~bytes[k]);

            return new DataWord(newbytes);
        }

        public int Compare(DataWord dw)
        {
            return BigInteger.Compare(this.Value, dw.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is DataWord))
                return false;

            return this.Value.Equals(((DataWord)obj).Value);
        }
    }
}
