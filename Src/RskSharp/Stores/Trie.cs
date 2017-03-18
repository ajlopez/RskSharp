namespace RskSharp.Stores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Trie
    {
        private byte[] path;
        private byte[] value;
        private Trie[] leafs;

        public Trie()
        {
        }

        private Trie(byte[] key, byte[] value)
        {
            this.path = key;
            this.value = value;
        }

        public byte[] GetValue(byte[] key)
        {
            return this.value;
        }

        public Trie SetValue(byte[] key, byte[] value)
        {
            return new Trie(key, value);
        }
    }
}
