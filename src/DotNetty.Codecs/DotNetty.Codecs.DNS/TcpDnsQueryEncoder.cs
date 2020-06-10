﻿using DotNetty.Buffers;
using DotNetty.Codecs.DNS.Messages;
using DotNetty.Transport.Channels;

namespace DotNetty.Codecs.DNS
{
    public sealed class TcpDnsQueryEncoder : MessageToByteEncoder<IDnsQuery>
    {
        private readonly DnsQueryEncoder encoder;

        public TcpDnsQueryEncoder() : this(new DefaultDnsRecordEncoder())
        {
        }

        public TcpDnsQueryEncoder(IDnsRecordEncoder recordEncoder)
        {
            encoder = new DnsQueryEncoder(recordEncoder);
        }

        protected override void Encode(IChannelHandlerContext context, IDnsQuery message, IByteBuffer output)
        {
            output.SetWriterIndex(output.WriterIndex + 2);
            encoder.Encode(message, output);
            output.SetShort(0, output.ReadableBytes - 2);
        }

        protected override IByteBuffer AllocateBuffer(IChannelHandlerContext ctx)
        {
            return ctx.Allocator.Buffer(1024);
        }
    }
}
