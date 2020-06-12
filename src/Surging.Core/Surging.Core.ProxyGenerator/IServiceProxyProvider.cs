using System.Collections.Generic;
using System.Threading.Tasks;

namespace Surging.Core.ProxyGenerator
{
	/// <summary>
	/// 服务代理提供者接口
	/// </summary>
	public interface IServiceProxyProvider
	{
		Task<T> Invoke<T>(IDictionary<string, object> parameters, string routePath);

		Task<T> Invoke<T>(IDictionary<string, object> parameters, string routePath, string serviceKey);
	}
}
