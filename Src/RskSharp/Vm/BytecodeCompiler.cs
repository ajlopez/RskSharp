﻿namespace RskSharp.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class BytecodeCompiler
    {
        private IList<byte> bytes = new List<byte>();

        public void Stop()
        {
            this.Compile(Bytecodes.Stop);
        }

        public void Add()
        {
            this.Compile(Bytecodes.Add);
        }

        public void Subtract()
        {
            this.Compile(Bytecodes.Subtract);
        }

        public void Multiply()
        {
            this.Compile(Bytecodes.Multiply);
        }

        public void Divide()
        {
            this.Compile(Bytecodes.Divide);
        }

        public void LessThan()
        {
            this.Compile(Bytecodes.LessThan);
        }

        public void GreaterThan()
        {
            this.Compile(Bytecodes.GreaterThan);
        }

        public void Equal()
        {
            this.Compile(Bytecodes.Equal);
        }

        public void IsZero()
        {
            this.Compile(Bytecodes.IsZero);
        }

        public void And()
        {
            this.Compile(Bytecodes.And);
        }

        public void Or()
        {
            this.Compile(Bytecodes.Or);
        }

        public void Not()
        {
            this.Compile(Bytecodes.Not);
        }

        public void Xor()
        {
            this.Compile(Bytecodes.Xor);
        }

        public void Pop()
        {
            this.Compile(Bytecodes.Pop);
        }

        public void MLoad()
        {
            this.Compile(Bytecodes.MLoad);
        }

        public void MStore()
        {
            this.Compile(Bytecodes.MStore);
        }

        public void MStore8()
        {
            this.Compile(Bytecodes.MStore8);
        }

        public void SLoad()
        {
            this.Compile(Bytecodes.SLoad);
        }

        public void SStore()
        {
            this.Compile(Bytecodes.SStore);
        }

        public void Jump()
        {
            this.Compile(Bytecodes.Jump);
        }

        public void JumpI()
        {
            this.Compile(Bytecodes.JumpI);
        }

        public void Pc()
        {
            this.Compile(Bytecodes.Pc);
        }

        public void Push(int value)
        {
            var bytes = (new BigInteger(value)).ToByteArray().Reverse().ToArray();
            this.CompileAdjust(Bytecodes.Push1, bytes.Length - 1, bytes);
        }

        public void Push(DataWord dw)
        {
            var bytes = dw.Value.ToByteArray().Reverse().ToArray();
            this.CompileAdjust(Bytecodes.Push1, bytes.Length - 1, bytes);
        }

        public void Swap(int n)
        {
            this.CompileAdjust(Bytecodes.Swap1, n - 1);
        }

        public void Dup(int n)
        {
            this.CompileAdjust(Bytecodes.Dup1, n - 1);
        }

        public void Compile(Bytecodes bytecode, params byte[] args)
        {
            this.bytes.Add((byte)bytecode);

            foreach (var b in args)
                this.bytes.Add(b);
        }

        public void CompileAdjust(Bytecodes bytecode, int adjust, params byte[] args)
        {
            this.bytes.Add((byte)(bytecode + adjust));

            foreach (var b in args)
                this.bytes.Add(b);
        }

        public byte[] ToBytes()
        {
            return this.bytes.ToArray();
        }
    }
}
