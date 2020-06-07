﻿using Autofac;
using System;
using System.Collections.Generic;

namespace Surging.Core.CPlatform.Engines
{
	public interface IServiceEngineBuilder
    {
        void Build(ContainerBuilder serviceContainer);

        ValueTuple<List<Type>, IEnumerable<string>>? ReBuild(ContainerBuilder serviceContainer);
    }
}
