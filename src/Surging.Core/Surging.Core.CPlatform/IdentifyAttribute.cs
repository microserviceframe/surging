﻿using System;

namespace Surging.Core.CPlatform
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class IdentifyAttribute : Attribute
    {
        public IdentifyAttribute(CommunicationProtocol name)
        {
            Name = name;
        }

        public CommunicationProtocol Name { get; set; }
    }
}

