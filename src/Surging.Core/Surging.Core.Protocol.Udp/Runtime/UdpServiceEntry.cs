﻿using System;

namespace Surging.Core.Protocol.Udp.Runtime
{
    public class UdpServiceEntry
    {
        public string Path { get; set; }

        public Type Type { get; set; }

        public UdpBehavior Behavior { get; set; }
    }

}
