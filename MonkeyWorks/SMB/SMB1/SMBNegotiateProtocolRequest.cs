﻿using System;

namespace MonkeyWorks.SMB.SMB1
{
    class SMBNegotiateProtocolRequest
    {
        private readonly Byte[] lmDialectBytes = { 0x4e, 0x54, 0x20, 0x4c, 0x4d, 0x20, 0x30, 0x2e, 0x31, 0x32, 0x00 };
        private readonly Byte[] twoDialectBytes = { 0x53, 0x4d, 0x42, 0x20, 0x32, 0x2e, 0x30, 0x30, 0x32, 0x00 };
        private readonly Byte[] threeDialectBytes = { 0x53, 0x4d, 0x42, 0x20, 0x32, 0x2e, 0x3f, 0x3f, 0x3f, 0x00 };

        private readonly Byte[] WordCount = { 0x00 };
        private Byte[] ByteCount;
        private readonly Byte[] BufferFormatLM = { 0x02 };
        private Byte[] Name;
        private readonly Byte[] BufferFormat2= { 0x02 };
        private Byte[] Name2;
        private readonly Byte[] BufferFormat3 = { 0x02 };
        private Byte[] Name3;

        internal SMBNegotiateProtocolRequest()
        {
            ByteCount = BitConverter.GetBytes((Int16)(lmDialectBytes.Length + twoDialectBytes.Length + threeDialectBytes.Length + 3));
            Name = lmDialectBytes;
            Name2 = twoDialectBytes;
            Name3 = threeDialectBytes;
        }

        internal Byte[] GetProtocols()
        {
            Byte[] protocols = Combine.combine(WordCount, ByteCount);
            protocols = Combine.combine(protocols, BufferFormatLM);
            protocols = Combine.combine(protocols, Name);
            protocols = Combine.combine(protocols, BufferFormat2);
            protocols = Combine.combine(protocols, Name2);
            protocols = Combine.combine(protocols, BufferFormat3);
            protocols = Combine.combine(protocols, Name3);
            return protocols;
        }
    }
}